using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext , IStorageBroker
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

        public ValueTask<Guest> GetBrokerAsync(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
