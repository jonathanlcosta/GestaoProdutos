using CrystalQuartz.AspNetCore;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GestaoProdutos.Aplicacao.Produtos.Profiles;
using GestaoProdutos.Aplicacao.Produtos.Servicos;
using GestaoProdutos.Dominio.Produtos.Servicos;
using GestaoProdutos.Infra.Produtos;
using GestaoProdutos.Infra.Produtos.Mapeamentos;
using GestaoProdutos.Jobs.Factorys;
using GestaoProdutos.Jobs.Listeners;
using GestaoProdutos.Jobs.Produtos;
using NHibernate;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddSingleton<ISessionFactory>(factory =>
{
    return Fluently.Configure()
        .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
        .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ProdutosMap>())
        .BuildSessionFactory();
});

builder.Services.AddScoped<NHibernate.ISession>(factory =>
{
    var sessionFactory = factory.GetService<ISessionFactory>();
    return sessionFactory.OpenSession();
});

builder.Services.AddScoped<ITransaction>(factory =>
{
    var session = factory.GetService<NHibernate.ISession>();
    return session.BeginTransaction();
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddSingleton<IJobFactory, ScheduledJobFactory>();
builder.Services.AddSingleton<IJobListener, LogsJobListener>();
builder.Services.AddTransient<ProdutosJob>();

builder.Services.AddAutoMapper(typeof(ProdutosProfile));

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProdutosAppServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProdutosServico>()
    .AddClasses()
        .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProdutosRepositorio>()
    .AddClasses()
        .AsImplementedInterfaces()
            .WithScopedLifetime());

var schedulerFactory = new StdSchedulerFactory();
var scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
scheduler.JobFactory = builder.Services.BuildServiceProvider().GetService<IJobFactory>();

scheduler.ListenerManager.AddJobListener(builder.Services.BuildServiceProvider().GetService<IJobListener>(), GroupMatcher<JobKey>.AnyGroup());

var produtos = JobBuilder.Create<ProdutosJob>()
    .WithIdentity("ProdutosJob", "Produtos")
    .WithDescription("Relatório de Produtos atrasadas")
    .StoreDurably()
    .UsingJobData("ConnectionString", connectionString)
    .Build();

await scheduler.ScheduleJob(produtos, TriggerBuilder.Create().WithCronSchedule("0 * * ? * *").Build());

await scheduler.Start();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCrystalQuartz(() => scheduler);

app.UseAuthorization();

app.MapControllers();

app.Run();
