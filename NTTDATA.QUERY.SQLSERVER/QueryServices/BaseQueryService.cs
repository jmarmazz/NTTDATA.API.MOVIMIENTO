using Microsoft.Extensions.DependencyInjection;

namespace NTTDATA.QUERY.SQLSERVER.QueryServices
{
    public abstract class BaseQueryService
    {
        protected readonly IServiceScopeFactory serviceScopeFactory;

        internal BaseQueryService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
    }
}
