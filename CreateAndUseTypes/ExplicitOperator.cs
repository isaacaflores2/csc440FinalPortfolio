using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{  
    class ExplicitOperator
    {
        //P9: Implementing an implicit and explicit conversion operator
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 2, Page: 110, Listing 2-24

        #region Original source code
        //This example shows how to use the implicit and explicit conversion operator
        public static void RunOriginalExample()
        {
            Money m = new Money(42.42M);
            
            //Use implicit operator to convert Money object to decimal
            decimal amount = m;
            
            //Use explicit operator to converty Money object to integer
            int truncatedAmount = (int)m;

            Console.WriteLine($"Decimal amount {amount} and truncatedAmount {truncatedAmount}");
        }

        public class Money
        {
            public Money(decimal amount)
            {
                Amount = amount;
            }

            public decimal Amount { get; set; }

            //Static method used to provide the Amount property during an implicit conversion
            public static implicit operator decimal(Money money)
            {
                return money.Amount;
            }

            //Static method used to provide the Amount property during an explicit conversion
            public static explicit operator int (Money money)
            {
                return (int)money.Amount;
            }
        }

        #endregion

        #region Modified code  

        public static void RunModifiedExample()
        {
            Account account = new Account("Savings", 42.56M);
            string myAccount = account;
            Console.WriteLine(myAccount);
        }

        //This class extends the Money Class
        public class Account : Money
        {
            public Account(string name, decimal amount): base(amount)
            {
                Name = name; 
            }

            //We add a Name property
            public string Name { get; set; }

            //Provide the implicit operator function to convert the Account class to a string
            public static implicit operator string(Account account)
            {
                Console.WriteLine("Implicit operator called");
                return account.ToString();
            }

            //Override the ToString function to show the Name and Amount property as a String
            public override string ToString()
            {
                Console.WriteLine("ToString method called");
                return $"Account: {Name} - {Amount}";
            }
        }

        #endregion

        #region Code output
        /*
            Decimal amount 42.42 and truncatedAmount 42
            Implicit operator called
            ToString method called
            Account: Savings - 42.56
         */
        #endregion
    }
}

