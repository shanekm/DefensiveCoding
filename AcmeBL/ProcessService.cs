namespace AcmeBL
{
    using System;

    using Acme.Common;

    // TAKE TWO
    // Service class
    // Provides operations for "order process"
    public class ProcessService
    {
        // TAKE THREE - moving dependencies to constructor
        #region Properties

        private CustomerRepository customerRepository { get; set; }

        private EmailLibrary emailLibrary { get; set; }

        private InventoryRepository inventoryRepository { get; set; }

        private OrderRepository orderRepository { get; set; }

        #endregion

        #region Public Methods and Operators


        // TAKE FOUR
        // return OperationResult from here
        public OperationResult PlaceOrder(
            Customer customer, 
            Order order, 
            Payment payment, 
            bool allowSplitOrders, 
            bool emailReceipt)
        {
            // ADD GUARD CLAUSES
            if (customer == null) throw new ArgumentNullException("customer instance is null");
            //...
            
            // TAKE THREE - moving dependencies to constructor
            // var customerRepository = new CustomerRepository();
            this.customerRepository.Add(customer);

            // var orderRepository = new OrderRepository();
            this.orderRepository.Add(order);

            // var inverntoryRepository = new InventoryRepository();
            this.inventoryRepository.OrderItems(order, allowSplitOrders);

            payment.ProcessPayment();

            if (emailReceipt)
            {
                // TAKE FOUR - ref keyword (REF - code smell)
                // Adding isValid return value - REF keyword for message
                //string message;
                //var isValid = customer.ValidateEmail(ref message);
                //var isValid = customer.ValidateEmail(out message);

                // TAKE FIVE - using Tuple<,>
                //var isValid = customer.ValidateEmail();
                //if (isValid.Item1)
                //{
                //    this.customerRepository.Update();
                //    this.emailLibrary.SendEmail(customer.Email, "Here is your receipt!");
                //}

                // TAKE SIX - using custom class OperationResult
                var isValid = customer.ValidateEmail();
                if (isValid.Success)
                {
                    this.customerRepository.Update();
                    this.emailLibrary.SendEmail(customer.Email, "Here is your receipt!");
                }
            }
        }

        #endregion
    }
}