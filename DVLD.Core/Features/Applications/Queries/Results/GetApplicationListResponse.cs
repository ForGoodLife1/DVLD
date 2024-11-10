namespace DVLD.Core.Features.Applications.Queries.Results
{
    public class GetApplicationListResponse
    {
        public int ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationStatus { get; set; }
        public decimal PaidFees { get; set; }
    }
}
