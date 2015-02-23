namespace AcmeBL
{
    using System;
    using System.ComponentModel;

    public class Payment
    {
        #region Enums

        public enum PaymentTypeOption
        {
            CreadiCard = 1, 

            PayPal = 2
        }

        #endregion

        #region Public Properties

        public int PaymentType { get; set; }

        #endregion

        // Enums - use enums when possibble instead of 1, 2, 3 (payment type)
        #region Public Methods and Operators

        public void ProcessPayment()
        {
            // CODE SMELL - Enum.IsDefined - uses relfection
            //if (!Enum.IsDefined(typeof(PaymentTypeOption), this.PaymentType))
            //{
            //    throw new InvalidEnumArgumentException("Payment type not defined");   
            //}

            // USE try/parse instead
            PaymentTypeOption paymentTypeOption
            if (!Enum.TryParse(PaymentType.ToString(), out paymentTypeOption))
            {
                throw new InvalidEnumArgumentException();   
            }

            // Remove this casting now
            //switch ((PaymentTypeOption)this.PaymentType)
            switch (paymentTypeOption)
            {
                case PaymentTypeOption.CreadiCard:

                    // Process CC
                    break;
                case PaymentTypeOption.PayPal:

                    // Process PayPal
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        #endregion
    }
}