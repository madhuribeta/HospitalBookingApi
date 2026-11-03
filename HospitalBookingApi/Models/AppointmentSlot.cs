namespace HospitalBookingApi.Models;

public class AppointmentSlot
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsBooked { get; set; }

    // Foreign Keys
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    public int? BookedByUserId { get; set; }
    public User? BookedByUser { get; set; }
}
