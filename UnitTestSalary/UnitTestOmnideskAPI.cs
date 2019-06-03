using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salary.Model;
using Salary.OmnideskAPI;

namespace UnitTestSalary
{
    [TestClass]
    public class UnitTestOmnideskAPI
    {
        private readonly OmnideskAPI api = new OmnideskAPI("https://b2bfamily.omnidesk.ru", "nkazakov@b2bfamily.com", "049ba38380d92596e9fad30b5");

        [TestMethod]
        public void TestGetAllStaffs()
        {
            #region Arrange

            List<Staff> staffs = new List<Staff>();

            #endregion

            #region Action

            staffs = api.GetAllStaffs();

            #endregion

            #region Output

            staffs.ForEach(s =>
            {
                Console.WriteLine("{0} {1} {2} {3} ({4})", s.StaffId, s.StaffFullName, s.Active, s.Status, s.CreatedAt);
            });

            #endregion
        }

        [TestMethod]
        public void TestGetCases()
        {
            #region Arrange

            int staffId = 10451;
            DateTime fromDate = new DateTime(2019, 5, 1);
            DateTime toDate = new DateTime(2019, 5, 31);
            List<Case> cases = new List<Case>();

            #endregion

            #region Action

            cases = api.GetCasesRange(staffId, fromDate, toDate);

            #endregion

            #region Output

            cases.ForEach(c =>
            {
                OutputCase(c);
            });

            #endregion
        }

        [TestMethod]
        public void TestGetMessagesByCaseId()
        {
            #region Arrange

            int caseId = 6117208;
            List<Message> messages = new List<Message>();

            #endregion

            #region Action

            messages = api.GetMessagesByCaseId(caseId);

            #endregion

            #region Output

            messages.ForEach(m =>
            {
                Console.WriteLine("message_id: {0} " +
                                  "user_id: {1} " +
                                  "staff_id: {2} " +
                                  "content: {3} " +
                                  "content_html: {4} " +
                                  "attachments: {5} " +
                                  "note: {6} " +
                                  "sent_via_rule: {7} " +
                                  "created_at: {8}",
                                  m.MessageId,
                                  m.UserId,
                                  m.StaffId,
                                  m.Content,
                                  m.ContentHtml,
                                  m.Attachments,
                                  m.Note,
                                  m.SentViaRule,
                                  m.GetCreateAt());
            });

            #endregion
        }

        [TestMethod]
        public void TestGetReportForAllStaffByRange()
        {
            #region Arrange

            DateTime fromDate = new DateTime(2019, 5, 1);
            DateTime toDate = new DateTime(2019, 5, 31);
            List<Case> cases = new List<Case>();

            #endregion

            #region Output

            api.GetAllStaffs().ForEach(s =>
            {
                Console.WriteLine("\n{0} {1} {2} {3} ({4})", s.StaffId, s.StaffFullName, s.Active, s.Status, s.CreatedAt);
                cases.Clear();
                cases = api.GetCasesRange(s.StaffId, fromDate, toDate);
                Console.WriteLine("Count cases:{0} (from {1} to {2})\n", cases.Count, fromDate.ToShortDateString(), toDate.ToShortDateString());
                if (cases.Count > 0)
                {
                    cases.ForEach(c =>
                    {
                        OutputCase(c);
                    });
                }
            });

            #endregion
        }

        [TestMethod]
        public void TestGetStatisticsAllStaffs()
        {
            #region Arrange

            DateTime fromDate = new DateTime(2019, 5, 1);
            DateTime toDate = new DateTime(2019, 5, 31);
            List<StatStaff> staffs = new List<StatStaff>();

            #endregion

            #region Action

            staffs = api.GetStatisticsAllStaffs(fromDate, toDate);

            #endregion

            #region Output

            staffs.ForEach(s =>
            {
                Console.WriteLine("staff_id: {0} " +
                                  "staff_name: {1} " +
                                  "cases_with_first_reply: {2} " +
                                  "first_reply_speed: {3} " +
                                  "total_amount_of_replies: {4} " +
                                  "closed_cases: {5} " +
                                  "closing_speed: {6} " +
                                  "average_rating: {7}",
                                  s.StaffId,
                                  s.StaffName,
                                  s.CasesWithFirstReply,
                                  s.FirstReplySpeed,
                                  s.TotalAmountOfReplies,
                                  s.ClosedCases,
                                  s.ClosingSpeed,
                                  s.AverageRating);
            });

            #endregion
        }

        #region Methods

        private void OutputCase(Case c)
        {
            Console.WriteLine("\tstaff_id: {0} " +
                                          "date: {1} " +
                                          "channel: {2} " +
                                          "case_id: {3} " +
                                          "closing_speed: {4} " +
                                          "status {5}",
                                          c.StaffId,
                                          c.CreatedAt,
                                          c.Channel,
                                          c.CaseId,
                                          c.ClosingSpeed,
                                          c.Status);
        }

        #endregion
    }
}
