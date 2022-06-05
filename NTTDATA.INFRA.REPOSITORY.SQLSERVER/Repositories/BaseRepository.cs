using Microsoft.Extensions.DependencyInjection;

namespace NTTDATA.INFRA.REPOSITORY.SQLSERVER.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IServiceScopeFactory serviceScopeFactory;

        internal BaseRepository(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
    }
}
