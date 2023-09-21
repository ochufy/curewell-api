namespace curewellAPI_DAL.DTOs
{
  public class SurgeryDto
  {
    public int SurgeryId { get; set; }
    public int DoctorId { get; set; }
    public DateTime SurgeryDate { get; set; }
    public decimal StartTime { get; set; }
    public decimal EndTime { get; set; }
    public string SurgeryCategory { get; set; } = null!;
  }
}
