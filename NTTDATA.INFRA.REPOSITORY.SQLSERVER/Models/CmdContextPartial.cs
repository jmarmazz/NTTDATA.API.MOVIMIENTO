using Microsoft.EntityFrameworkCore;

namespace NTTDATA.INFRA.REPOSITORY.SQLSERVER.Models
{
    public sealed partial class CmdContext
    {

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}