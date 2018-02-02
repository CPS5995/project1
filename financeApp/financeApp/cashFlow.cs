using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    /// <summary>
    /// Class for user CashFlows
    /// A cashflow contains all the parts of a single transaction
    /// The amount, due date, etc...
    /// </summary>
    public class cashFlow
    {

        public string name { get; set; }
        public double amount { get; set; }
        public DateTime dueDate { get; set; }

        /* Constructors */
        public cashFlow() { }

        public cashFlow(string name, double amount, DateTime dueDate)
        {
            this.name = name;
            this.amount = amount;
            this.dueDate = dueDate;
        }
        /* End Constructors */



        /// <summary>
        /// Indicates if the flow is overdue
        /// a flow is "overdue" if it's dueDate is less than the current date
        /// </summary>
        /// <returns></returns>
        public bool isOverDue()
        {
            return (this.dueDate - DateTime.Now).TotalDays < 0;
        }

    }//end class

