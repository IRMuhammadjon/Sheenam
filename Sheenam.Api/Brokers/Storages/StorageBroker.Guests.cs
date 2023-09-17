//===========================================================
//Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//==========================================================




using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }
        public async ValueTask<Guest> GetBrokerAsync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);
            
            EntityEntry<Guest> guastEntityEntry = 
                await broker.Guests.AddAsync(guest);

            await broker.SaveChangesAsync();

            return guastEntityEntry.Entity;
        }

    }
}
