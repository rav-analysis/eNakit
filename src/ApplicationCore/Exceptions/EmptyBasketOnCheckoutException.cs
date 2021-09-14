using System;

namespace Microsoft.eShopWeb.ApplicationCore.Exceptions
{
    public class EmptyBasketOnCheckoutException : Exception
    {
        public EmptyBasketOnCheckoutException()
            : base($"Ne možete uraditi potvrdu sa praznom korpom!")
        {
        }

        protected EmptyBasketOnCheckoutException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public EmptyBasketOnCheckoutException(string message) : base(message)
        {
        }

        public EmptyBasketOnCheckoutException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
