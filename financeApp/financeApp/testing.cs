﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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


        /// <summary>
        /// Testing that Start of week will return the start of the week regardless of which day is passed
        /// </summary>
        [TestMethod]
        public void testGetStartOfWeek()
        {
            DateTime targetDate = new DateTime(2018, 1, 7);

            Assert.AreEqual(common.getStartOfWeek(new DateTime(2018, 1, 7)), targetDate);
            Assert.AreEqual(common.getStartOfWeek(new DateTime(2018, 1, 9)), targetDate);
            Assert.AreEqual(common.getStartOfWeek(new DateTime(2018, 1, 12)), targetDate);

            Assert.AreNotEqual(common.getStartOfWeek(new DateTime(2018, 1, 5)), targetDate);
            Assert.AreNotEqual(common.getStartOfWeek(new DateTime(2018, 1, 14)), targetDate);
            Assert.AreNotEqual(common.getStartOfWeek(new DateTime(2018, 1, 15)), targetDate);
            Assert.AreNotEqual(common.getStartOfWeek(new DateTime(2017, 1, 7)), targetDate);

            /* Test the transition between Years/months */
            targetDate = new DateTime(2017, 12, 31);
            Assert.AreEqual(common.getStartOfWeek(new DateTime(2018, 1, 1)), targetDate);
        }

        /// <summary>
        /// Testing that getEndOfWeek returns the expected end of week for all input values
        /// </summary>
        [TestMethod]
        public void testGetEndOfWeek()
        {
            DateTime targetDate = new DateTime(2018, 2, 10);

            Assert.AreEqual(common.getEndOfWeek(new DateTime(2018, 2, 7)), targetDate);
            Assert.AreEqual(common.getEndOfWeek(new DateTime(2018, 2, 9)), targetDate);
            Assert.AreEqual(common.getEndOfWeek(new DateTime(2018, 2, 10)), targetDate);

            Assert.AreNotEqual(common.getEndOfWeek(new DateTime(2018, 2, 2)), targetDate);
            Assert.AreNotEqual(common.getEndOfWeek(new DateTime(2018, 2, 14)), targetDate);
            Assert.AreNotEqual(common.getEndOfWeek(new DateTime(2018, 2, 15)), targetDate);
            Assert.AreNotEqual(common.getEndOfWeek(new DateTime(2017, 2, 7)), targetDate);

            /* Test the transition between Years/months */
            targetDate = new DateTime(2019, 1, 5);
            Assert.AreEqual(common.getEndOfWeek(new DateTime(2018, 12, 31)), targetDate);
        }

        /// <summary>
        /// test getting the full month name
        /// </summary>
        [TestMethod]
        public void testGetMonthName()
        {
            Assert.AreEqual(common.getMonthName(1), "January");
            Assert.AreEqual(common.getMonthName(12), "December");

            Assert.AreNotEqual(common.getMonthName(1), "Jan");
            //still need to text for Expected exceptions
        }

        /// <summary>
        /// Test the bounds and return values for getting flows within a date range
        /// </summary>
        [TestMethod]
        public void testDataWithinRange()
        {
            List<cashFlow> testFlows = new List<cashFlow>();
            DateTime targetLowerBound = new DateTime(2018, 2, 1);
            DateTime targetUpperBound = new DateTime(2018, 2, 28);

            /* create the IN RANGE flows */
            cashFlow inRangeFlow1 = new cashFlow();
            cashFlow inRangeFlow2 = new cashFlow();
            cashFlow inRangeFlow3 = new cashFlow();

            inRangeFlow1.flowDate = new DateTime(2018, 2, 1);
            inRangeFlow2.flowDate = new DateTime(2018, 2, 22);
            inRangeFlow3.flowDate = new DateTime(2018, 2, 28);

            testFlows.Add(inRangeFlow1);
            testFlows.Add(inRangeFlow2);
            testFlows.Add(inRangeFlow3);

            /* create the OUT OF RANGE flows */
            cashFlow outOfRangeFlow1 = new cashFlow();
            cashFlow outOfRangeFlow2 = new cashFlow();

            outOfRangeFlow1.flowDate = new DateTime(2018, 1, 7);
            outOfRangeFlow1.flowDate = new DateTime(2018, 3, 22);

            testFlows.Add(outOfRangeFlow1);
            testFlows.Add(outOfRangeFlow2);

            /* run Tests against the flows */
            List<cashFlow> filteredSet = common.getCashFlowsWithinRange(testFlows, targetLowerBound, targetUpperBound);

            Assert.IsTrue(filteredSet.Contains(inRangeFlow1));
            Assert.IsTrue(filteredSet.Contains(inRangeFlow2));
            Assert.IsTrue(filteredSet.Contains(inRangeFlow3));

            Assert.IsFalse(filteredSet.Contains(outOfRangeFlow1));
            Assert.IsFalse(filteredSet.Contains(outOfRangeFlow2));
        }

        /// <summary>
        /// Testing the parameters for the isDate method
        /// </summary>
        [TestMethod]
        public void testIsDate()
        {

            Assert.IsTrue(common.isDate("01/01/2018"));
            Assert.IsTrue(common.isDate("01/01/2018 12:30 PM"));
            Assert.IsTrue(common.isDate("January 1, 2018"));
            Assert.IsTrue(common.isDate("January 1, 2018 12:30 PM"));
            Assert.IsTrue(common.isDate("January 1, 2018 23:30"));
            Assert.IsTrue(common.isDate("12:30 PM"));
            Assert.IsTrue(common.isDate("23:30"));

            Assert.IsFalse(common.isDate("Totally a Date"));
            Assert.IsFalse(common.isDate("01/32/2018"));
            Assert.IsFalse(common.isDate("-1/01/2018"));
            Assert.IsFalse(common.isDate("January 1st, 2018"));
            Assert.IsFalse(common.isDate("January 1.0, 2018"));
            Assert.IsFalse(common.isDate("Totally NOT a Date"));
            Assert.IsFalse(common.isDate("24:30"));
            Assert.IsFalse(common.isDate("20:77"));

            /* it's weird, but this ["January -1, 2018"] will parse as a DateTime.
             * it'll become "January 1, 2018", and behave normally from that point on. 
             * Negative dates aren't a thing, so this should be acceptable behavior */
            Assert.IsTrue(common.isDate("January -1, 2018"));

            /* Similarly, the AM/PM specifies a 12 Hour format, yet ["14:30 PM"] parses fine.
             * It becomes "02:30 PM", and behaves normally after that point.
             * Really odd behavior, but it's kinda correct.
             * 
             * ["14:30 AM"] corresponds to no existing time, and fails appropriately. */
            Assert.IsFalse(common.isDate("14:30 AM"));
            Assert.IsTrue(common.isDate("14:30 PM"));
        }

        /// <summary>
        /// Testing values for the isNumeric function
        /// </summary>
        [TestMethod]
        public void testIsNumeric()
        {
            Assert.IsTrue(common.isNumeric("10"));
            Assert.IsTrue(common.isNumeric("0.10"));
            Assert.IsTrue(common.isNumeric("10.00"));
            Assert.IsTrue(common.isNumeric("10.001"));
            Assert.IsTrue(common.isNumeric("10,000"));
            Assert.IsTrue(common.isNumeric("+10"));
            Assert.IsTrue(common.isNumeric("-10"));
            Assert.IsTrue(common.isNumeric("  1  "));
            Assert.IsTrue(common.isNumeric("10,0,00"));

            Assert.IsFalse(common.isNumeric("10a"));
            Assert.IsFalse(common.isNumeric("A"));
            Assert.IsFalse(common.isNumeric("10-"));
            Assert.IsFalse(common.isNumeric("$10"));
            Assert.IsFalse(common.isNumeric("one"));
            Assert.IsFalse(common.isNumeric(""));
            Assert.IsFalse(common.isNumeric("10-"));
            Assert.IsFalse(common.isNumeric("--10"));
            Assert.IsFalse(common.isNumeric("++10"));
            Assert.IsFalse(common.isNumeric("-  10"));
            Assert.IsFalse(common.isNumeric("+  10"));
        }

    }

}
