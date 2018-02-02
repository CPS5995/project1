using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/// <summary>
/// Class for funding profiles
/// A funding profile is a collection of cash flows
/// i.e. a "Business" vs "personal", or 
/// </summary>
    public class fundingProfile
    {
        public string name { get; set;}
        public List<cashFlow> cashFlows = new List<cashFlow>();

        //Default constructor
        public fundingProfile() { }


        /// <summary>
        /// Returns a list of all Overdue cash flows
        /// </summary>
        /// <returns></returns>
        public List<cashFlow> getOverdueFlows()
        {
            return this.cashFlows.Where(x => x.isOverDue()).ToList();
        }
        

    }

