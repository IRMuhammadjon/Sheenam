using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext
    {
        private readonly IConfiguration configuration;
        public StorageBroker(IConfiguration configuration) 
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connetionString = 
                        this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connetionString);
        }

        public override void Dispose() { }
        

    }
}
