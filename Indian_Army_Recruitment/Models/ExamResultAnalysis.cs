namespace Indian_Army_Recruitment.Models
{
    public class ExamResultAnalysis
    {
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int TotalParticipants { get; set; }
        public int PassedCandidates { get; set; }
        public double PassPercentage => TotalParticipants == 0
            ? 0
            : (double)PassedCandidates / TotalParticipants * 100;
    }
}
