namespace CarBuilderCSHARP.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int WheelId { get; set; }
    public Wheels Wheel { get; set; } // Store related Wheel
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; } // Store related Technology
    public int PaintId { get; set; }
    public PaintColor Paint { get; set; } // Store related Paint
    public int InteriorId { get; set; }
    public Interior Interior { get; set; } // Store related Interior
}