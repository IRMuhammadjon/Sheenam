//===========================================================
//Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//==========================================================


using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;
using Xeptions;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private delegate ValueTask<Guest> ReturnGuestFunction();

        private async ValueTask<Guest> TryCatch(ReturnGuestFunction returnGuestFunction)
        {
            try
            {
                return await returnGuestFunction();
            }
            catch (NullGuestException nullGuestException)
            {
                throw CreatAndLogValidationExcaption(nullGuestException);
            }
        }


        private GuestvalidationException CreatAndLogValidationExcaption(Xeption exeption)
        {
            var guestValidationException =
                new GuestvalidationException(exeption);

            this.loggingBroker.LogError(guestValidationException);

            return guestValidationException;
        }

    }
}
