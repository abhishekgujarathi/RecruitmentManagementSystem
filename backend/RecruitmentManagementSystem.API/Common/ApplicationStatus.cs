namespace RecruitmentManagementSystem.API.Common
{
    public static class ApplicationStatus
    {
        //innit
        public const string Applied = "Applied";

        // underReview when assigned
        public const string UnderReview = "UnderReview";
        // when resume seslected
        public const string Shortlisted = "Shortlisted";

        // test status
        public const string TestScheduled = "TestScheduled";
        public const string TestPassed = "TestPassed";
        // interviw status
        public const string InterviewInProgress = "InterviewInProgress";
        public const string InterviewCompleted = "InterviewCompleted";

        // last finals
        public const string Rejected = "Rejected";
        public const string Hired = "Hired";

        // if on hold anytime need note
        public const string OnHold = "OnHold";

        // final state of any application
        public static readonly HashSet<string> FinalStatuses = new()
        {
            Rejected,
            Hired
        };

        // from 1state to another,  rules
        public static readonly Dictionary<string, string[]> AllowedTransitions = new()
        {
            [Applied] = new[] { UnderReview, OnHold },

            [UnderReview] = new[] { Shortlisted, Rejected, OnHold },

            [Shortlisted] = new[] { TestScheduled, Rejected, OnHold },

            [TestScheduled] = new[] { TestPassed, Rejected, OnHold },

            [TestPassed] = new[] { InterviewInProgress, OnHold },

            [InterviewInProgress] = new[] { InterviewCompleted, Rejected, OnHold },

            [InterviewCompleted] = new[] { Hired, Rejected, OnHold },

            // onhold can resume to previous logical stage
            [OnHold] = new[] { Applied, UnderReview, Shortlisted, TestPassed, TestScheduled, InterviewInProgress, InterviewCompleted }
        };
    }

}
