namespace AcmeUI
{
    using System;

    using AcmeBL;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors and Destructors

        public MainWindow()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        // TAKE ONE
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder();
        }

        // TAKE THREE - putting place order in its own method, now do rundown
        // Clear purpose - Yes
        // Good name - Yes
        // Focused code - Yes (placing order)
        // Short lenght - Yes
        // Automated test - not yet
        private static void PlaceOrder()
        {
            var customer = new Customer();

            // Populate customer instance
            var order = new Order();

            // TAKE FOUR - take these out. we can use params instead
            // Populate order instance
            //bool allowSplitOrders = true;
            //bool emailReceipt = true;

            var payment = new Payment();
            // Populate payment

            // TAKE ONE 
            // Listing all methods in Button_Click ...

            // TAKE TWO - new service class handeling processing order
            var processService = new ProcessService();

            // TAKE FOUR - adding params instead of specifying allowSplitOrder var etc
            processService.PlaceOrder(customer, order, payment, allowSplitOrders: false, emailReceipt: false);
        }

        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var customer = new Customer();

            // TAKE ONE
            // Exception handling

            try
            {
                var result = customer.CalculatePercentOfGoalSteps(this.TextBox1.Text, this.TextBox2.Text);
                this.Result.Text = result.ToString();
            }
                // Catch specific excpetions
            catch (ArgumentException ex)
            {
                // THROW - throws error up the chain, to global exception handler
                // this is wrong
                //throw;

                // TAKE TWO
                // always do something when catching exceptions
                // Log exception

            }

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Result_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

    }
}