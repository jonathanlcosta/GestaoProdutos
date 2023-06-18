using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Produtos.Request;
using Quartz;
using Serilog.Context;

namespace GestaoProdutos.Jobs.Produtos
{
    public class ProdutosJob : IJob
    {
        
    private readonly ILogger<ProdutosJob> logger;
    private readonly IProdutosAppServico produtosAppServico;

        public ProdutosJob(ILogger<ProdutosJob> logger, IProdutosAppServico produtosAppServico)
        {
            this.logger = logger;
            this.produtosAppServico = produtosAppServico;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (LogContext.PushProperty("TransactionId", context.FireInstanceId))
            using (LogContext.PushProperty("Job", context.JobDetail.JobType.FullName))
            {

                try
                {
                    var quantidadeProdutos = produtosAppServico.Listar(new ProdutoListarRequest()).Total;

                    this.logger.LogInformation("Temos {quantidadeProdutos} Produtos!", quantidadeProdutos);
                 
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                }

                await Task.CompletedTask;
            }
        }
    }
}