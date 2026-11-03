namespace HospitalBookingApi.Models;

public class Clinic
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    // Navigation Property
    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
