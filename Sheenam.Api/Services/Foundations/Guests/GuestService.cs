﻿//===========================================================
//Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//==========================================================

using Sheenam.Api.Brokers.Loggings;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public partial class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }
        // Exeption Noise Cancell
        public  ValueTask<Guest> AddGuestAsync(Guest guest) =>
            TryCatch(async () =>
        {
            ValidationGuestNotNoll(guest);

            return await this.storageBroker.InsertGuestAsync(guest);
        });

    }
}
