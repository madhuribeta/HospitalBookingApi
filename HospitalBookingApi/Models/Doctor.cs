namespace HospitalBookingApi.Models;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    
    // Foreign Key
    public int ClinicId { get; set; }
    public Clinic? Clinic { get; set; }
    
    // Navigation Property
    public ICollection<AppointmentSlot> AppointmentSlots { get; set; } = new List<AppointmentSlot>();
}
