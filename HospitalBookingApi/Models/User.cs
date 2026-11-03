namespace HospitalBookingApi.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    // Navigation Property
    public ICollection<AppointmentSlot> BookedSlots { get; set; } = new List<AppointmentSlot>();
}
