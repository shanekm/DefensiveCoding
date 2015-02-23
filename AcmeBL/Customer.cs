namespace AcmeBL
{
    using Acme.Common;
    using System;

    public class Customer
    {
        #region Public Properties

        public int CustomerId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #endregion

        #region Public Methods and Operators

        // OVERVIEW
        // clear purpose - 2 methods (one validating (string input), another calculating)
        // good name - yes
        // focused - yes
        // sthort lenght - yes
        // can be tested - yes
        // preductable result - yes
        public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        {
            // TAKE ONE - this errors out when dividing by 0
            // return (Convert.ToDecimal(actualSteps) / Convert.ToDecimal(goalSteps)) * 100;

            // TAKE TWO - validation
            // checking this everytime - to make it easier write unit tests
            decimal result = 0;
            decimal goalStepsCount = 0;

            // decimal.TryParse(goalSteps, out goalStepsCount);
            decimal actualStepsCount = 0;

            // decimal.TryParse(actualSteps, out actualStepsCount);

            // if (goalStepsCount > 0)
            // {
            // result = (actualStepsCount / goalStepsCount) * 100;
            // }

            // TAKE THREE - fail fast
            if (string.IsNullOrWhiteSpace(goalSteps))
            {
                throw new ArgumentException("Goal steps must be entered", "gloalSteps");
            }

            if (string.IsNullOrWhiteSpace(actualSteps))
            {
                throw new ArgumentException("Actual steps must be entered", "gloalSteps");
            }

            if (!decimal.TryParse(goalSteps, out goalStepsCount))
            {
                throw new ArgumentException("Goal must me numeric!", "goalSteps");
            }

            decimal.TryParse(actualSteps, out actualStepsCount);

            return this.CalculatePercentOfGoalSteps(goalStepsCount, actualStepsCount);
        }

        // TAKE FOUR - method overloading
        public decimal CalculatePercentOfGoalSteps(decimal goalStepCount, decimal actualStepCount)
        {
            if (goalStepCount <= 0)
            {
                throw new ArgumentException("Goal must be greater than 0", "goalSteps");
            }

            return (actualStepCount / goalStepCount) * 100;
        }

        //public bool ValidateEmail()
        //{
        //    var valid = true;
        //    if (string.IsNullOrEmpty(this.Email))
        //    {
        //        valid = false;
        //    }

        //    return valid;
        //}

        // TAKE TWO - returning more than one value, return deatiled messages
        // returning a message
        //public bool ValidateEmail(ref string message)
        //{
        //    var valid = true;
        //    if (string.IsNullOrEmpty(this.Email)) 
        //    {
        //        valid = false;
        //        message = "Email address is null";
        //    }

        //    return valid;
        //}

        // TAKE THREE - OUT keyword (better than ref as it doesn't have to initialized)
        //public bool ValidateEmail(out string message)
        //{
        //    var valid = true;
        //    if (string.IsNullOrEmpty(this.Email))
        //    {
        //        valid = false;
        //        message = "Email address is null";
        //    }

        //    return valid;
        //}

        // TAKE FOUR - out/ref are code smells. use Tuble instead
        //public Tuple<bool, string> ValidateEmail()
        //{
        //    Tuple<bool, string> result = Tuple.Create(true, "");

        //    if (string.IsNullOrEmpty(this.Email))
        //    {
        //        result = Tuple.Create(false, "Email address is null");
        //    }

        //    return result;
        //}

        // TAKE FIVE - returning OperationResult custom object
        public OperationResult ValidateEmail()
        {
            OperationResult op = new OperationResult();

            if (string.IsNullOrEmpty(this.Email))
            {
                op.AddMessage("Email address is null");
                op.Success = false;
            }

            return op;
        }

        #endregion
    }
}