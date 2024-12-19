namespace CarBuilderCSHARP.Models.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int WheelId { get; set; }
    public Wheels Wheel { get; set; } // Include full details if needed
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; } // Include full details if needed
    public int PaintId { get; set; }
    public PaintColor Paint { get; set; } // Include full details if needed
    public int InteriorId { get; set; }
    public Interior Interior { get; set; } // Include full details if needed
}