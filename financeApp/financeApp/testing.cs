using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace unitTests
{

    /// <summary>
    /// This class containes all the automated tests for the project
    /// The full suite should be run whenever there is a change to the project
    /// </summary>
    [TestClass]
    public class testSuite
    {
       

        /// <summary>
        /// Test to make sure the Testing Framework is working.
        /// If this test fails, we have bigger problems.
        /// </summary>
        [TestMethod]
        public void sanityTest()
        {
            Assert.IsTrue(true);
            Assert.IsFalse(false);
            Assert.IsNull(null);
            Assert.AreEqual(true, true);
        }

        /// <summary>
        /// Testing the basic functionality of determining if a flow is overdue
        /// </summary>
        [TestMethod]
        public void testOverdueCashflows()
        {
            cashFlow testFlow = new cashFlow();

            testFlow.dueDate = DateTime.Now.AddDays(-1);
            Assert.IsTrue(testFlow.isOverDue());
            
            testFlow.dueDate = DateTime.Now.AddSeconds(-1);
            Assert.IsTrue(testFlow.isOverDue());

            testFlow.dueDate = DateTime.Now.AddDays(+1);
            Assert.IsFalse(testFlow.isOverDue());

            testFlow.dueDate = DateTime.Now.AddSeconds(+1);
            Assert.IsFalse(testFlow.isOverDue());
        }


        /// <summary>
        /// Testing that getting an account's cashFlows returns
        /// all flows associated with all profiles on that account
        /// </summary>
        [TestMethod]
        public void testGetAccountCashFlows()
        {
            userAccount testAccount = new userAccount();
            fundingProfile testProfile = new fundingProfile();
            cashFlow testFlow = new cashFlow();

            fundingProfile testProfile2 = new fundingProfile();
            cashFlow testFlow2 = new cashFlow();

            testFlow.name = "Test Flow 1";
            testFlow2.name = "Test Flow 2";

            testProfile.cashFlows.Add(testFlow);
            testProfile2.cashFlows.Add(testFlow2);

            testAccount.profiles.Add(testProfile);
            testAccount.profiles.Add(testProfile2);

            Assert.IsTrue(testAccount.getAccountCashFlows().Contains(testFlow));
            Assert.IsTrue(testAccount.getAccountCashFlows().Contains(testFlow2));
            
        }

    }

}
