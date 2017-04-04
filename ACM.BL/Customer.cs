using Acme.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{


    public class Customer : EntityBase, ILoggable
    {
        public Customer() : this(0)
        {

        }

        public Customer(int customerID)
        {
            this.CustomerID = customerID;
            AddressList = new List<Address>(); // this is so the address list is empty instead of null
        }
        //Properties

        public List<Address> AddressList { get; set; }
        public CustomerType CustomerTypeID { get; set; }

        public decimal CalculatePercentOfGoalStep(string goalSteps, string actualSteps)
        {
            #region// Try 5 - Final // This uses a fail fast to inform the user something went wrong immediately [like wrong input type]

            
           

            if (string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentException("Goal must be entered", "goalSteps");
            if (string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentException("Actual steps must be entered", "actualSteps");

            decimal goalStepCount = 0;
            if (!decimal.TryParse(goalSteps, out goalStepCount)) throw new ArgumentException("Goal must be numeric.");

            decimal actualStepCount = 0;
            if (!decimal.TryParse(actualSteps, out actualStepCount)) throw new ArgumentException("Actual steps must be numeric.", "actualSteps");

            return CalculatePercentOfGoalStep(goalStepCount, actualStepCount);
            #endregion

            #region// Try 4 // Ok, this looks way more robust. However the user still doesn't know what wrong he did

            //decimal result = 0;

            //decimal goalStepCount = 0;
            //decimal.TryParse(goalSteps, out goalStepCount);

            //decimal actualStepCount = 0;
            //decimal.TryParse(actualSteps, out actualStepCount);

            //if (goalStepCount > 0)
            //{
            //    result = ((actualStepCount / goalStepCount) * 100);
            //}

            //return result;
            #endregion

            #region// Try 3 // Even better but will crash and burn when goal field has input and actual steps is blank

            //decimal result = 0;

            //decimal goalStepCount = 0;
            //decimal.TryParse(goalSteps,out goalStepCount);

            //if (goalStepCount > 0)
            //{
            //    result = ((Convert.ToDecimal(actualSteps) / goalStepCount) * 100);
            //}

            //return result;
            #endregion

            #region // Try 2 // Better, but will crash at empty string
            //decimal result = 0;

            //var goalStepCount = Convert.ToDecimal(goalSteps);

            //if(goalStepCount > 0)
            //{
            //    result = ((Convert.ToDecimal(actualSteps) / goalStepCount) * 100);
            //}

            //return result;
            #endregion

            #region // Try1 // PRoblems? if we get goalSteps = 0 then we get dividebyzero
            //return (Convert.ToDecimal(actualSteps) / Convert.ToDecimal(goalSteps)) * 100;
            #endregion
        }

        public decimal CalculatePercentOfGoalStep(decimal goalSteps, decimal actualSteps)
        {
            if (goalSteps <= 0) throw new ArgumentException("Goal must be greater than 0", "goalSteps");

            return Math.Round(((actualSteps / goalSteps) * 100), 2);
        }

        public static int InstanceCount { get; set; }
        private string _lastName; //backing field for LastName
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public int CustomerID { get; private set; }
        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }

        #region // OperationResult ValidateEmail() - Return multiple values, by an OperationResult object
        public OperationResult ValidateEmail()
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(this.EmailAddress))
            {
                result.Success = false;
                result.AddMessage("Email address is empty or null");
            }
            if (result.Success)
            {
                var isValidFormat = true;
                // code here, with regexp

                if (!isValidFormat)
                {
                    result.Success = false;
                    result.AddMessage("Email address is in invalid format");
                }

            }
            if (result.Success)
            {
                var isRealDomain = true;
                // code for confirming domain

                if (!isRealDomain)
                {
                    result.Success = false;
                    result.AddMessage("Email address does not include a valid domain");
                }
            }
            return result;
        }
        #endregion

        #region // Tuple<bool,string> ValidateEmail() - Return multiple values //tried ref and out, but tuple seems best 
        /*
        public Tuple<bool,string> ValidateEmail(ref string message)
        {
            Tuple<bool, string> result = Tuple.Create(true,"OK");

            if (string.IsNullOrWhiteSpace(this.EmailAddress))
            {
                result = Tuple.Create(false,"Email address is empty or null");
            }
            if (result.Item1)
            {
                var isValidFormat = true;
                // code here, with regexp

                if (!isValidFormat)
                {
                    result = Tuple.Create(false, "Email address is in invalid format");
                }

            }
            if (result.Item1)
            {
                var isRealDomain = true;
                // code for confirming domain

                if (!isRealDomain)
                {
                    result = Tuple.Create(false, "Email address does not include a valid domain");
                }
            }     
            return result;
        }   
        */
        #endregion

        #region // void ValidateEmail() - Return exception version
        /*
        public void ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(this.EmailAddress)) throw new ArgumentException("Email address is null");

            var isValidFormat = true;
            // code here, with regexp

            if (!isValidFormat) throw new ArgumentException("Email address is in invalid format");
       

            var isRealDomain = true;
            // code for confirming domain

            if (!isRealDomain) throw new ArgumentException("Email address does not include a valid domain");
        
            // -- Send an email receipt --
            // If the user requested a receipt
            // Get the customer data
            // Ensure a valid email address was provided.
            // If not,
            // request an email address from the user.
        }
        */
        #endregion
        #region //bool ValidateEmail() - Return value version
        /*
        public bool ValidateEmail()
        {
            var valid = true;

            if (string.IsNullOrWhiteSpace(this.EmailAddress))
            {
                valid = false;
            }

            var isValidFormat = true;
            // code here, with regexp

            if (!isValidFormat)
            {
                valid = false;
            }

            var isRealDomain = true;
            // code for confirming domain

            if (!isRealDomain)
            {
                valid = false;
            }

            return valid;

            // -- Send an email receipt --
            // If the user requested a receipt
            // Get the customer data
            // Ensure a valid email address was provided.
            // If not,
            // request an email address from the user.
        }
        */
        #endregion
        public List<Invoice> InvoiceList { get; set; }

        // Methods


        protected override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }
        /// <summary>
        /// Doesn't check address list, assumes these are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            Customer rhs = obj as Customer;

            //var listSEQ = (IStructuralEquatable)this.addressList;
            bool AreAddressListsEqual = true; //temporary, since I can't make structural comparison work :/

            return this.CustomerID == rhs.CustomerID && this.LastName == rhs.LastName && this.FirstName == rhs.FirstName && this.EmailAddress == rhs.EmailAddress && AreAddressListsEqual;

        }
        public override int GetHashCode()
        {
            return this.CustomerID.GetHashCode() ^ this.LastName.GetHashCode() ^ this.FirstName.GetHashCode() ^ this.EmailAddress.GetHashCode(); //^ this.addressList.GetHashCode();
        }

        public override string ToString()
        {
            return FullName;
        }

        public string Log()
        {
            var logString = $"{this.CustomerID}: {this.FullName} Email: {this.EmailAddress} Status: {this.EntityState.ToString()}";

            return logString;
        }
    }
}
