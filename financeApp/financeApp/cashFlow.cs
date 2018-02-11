using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum cashFlowType
{
    income,
    expense
};

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
        public DateTime flowDate { get; set; } //invoice date? pay date?
        public cashFlowType flowType { get; set; }

        /* Constructors */
        public cashFlow() { }

        public cashFlow(string name, double amount, DateTime dueDate, DateTime flowDate, cashFlowType flowType)
        {
            this.name = name;
            this.amount = amount;
            this.dueDate = dueDate;
            this.flowDate = flowDate;
            this.flowType = flowType;
        }
        /* End Constructors */



        /// <summary>
        /// Indicates if the flow is overdue
        /// a flow is "overdue" if it's dueDate is less than the current date
        /// </summary>
        /// <returns></returns>
        public bool isOverDue()
        {
        
        /* This has To-the-second granularity 
         * That is, it will id a transaction as overdue
         * if it is even ONE SECOND past its due date */
        return (this.dueDate - DateTime.Now).TotalSeconds < 0;
        }

    }//end class

