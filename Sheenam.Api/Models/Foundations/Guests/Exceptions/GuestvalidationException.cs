//===========================================================
//Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//==========================================================



using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions
{
    public class GuestvalidationException :Xeption
    {
        public GuestvalidationException(Xeption innerException)
        :base(message:"Guest validation error occurred,fix the errors  and try again",
             innerException)
        {}
    }
}
