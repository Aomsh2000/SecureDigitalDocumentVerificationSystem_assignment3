public class VerificationLog
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public string VerifiedBy { get; set; } // Can be a username or ID of the verifier
    public DateTime Timestamp { get; set; }
    public string Status { get; set; } // e.g., Verified, Rejected

    public Document Document { get; set; }
}
