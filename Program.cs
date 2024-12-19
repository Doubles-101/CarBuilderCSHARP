using CarBuilderCSHARP.Models;

// Paint Colors
List<PaintColor> paintColors = new List<PaintColor>
{
    new PaintColor { Id = 1, Price = 500.00m, Color = "Silver" },
    new PaintColor { Id = 2, Price = 600.00m, Color = "Midnight Blue" },
    new PaintColor { Id = 3, Price = 700.00m, Color = "Firebrick Red" },
    new PaintColor { Id = 4, Price = 650.00m, Color = "Spring Green" }
};

// Interiors
List<Interior> interiors = new List<Interior>
{
    new Interior { Id = 1, Price = 800.00m, Material = "Beige Fabric" },
    new Interior { Id = 2, Price = 850.00m, Material = "Charcoal Fabric" },
    new Interior { Id = 3, Price = 1200.00m, Material = "White Leather" },
    new Interior { Id = 4, Price = 1250.00m, Material = "Black Leather" }
};

// Technology Packages
List<Technology> technologies = new List<Technology>
{
    new Technology { Id = 1, Price = 1000.00m, Package = "Basic Package (basic sound system)" },
    new Technology { Id = 2, Price = 1500.00m, Package = "Navigation Package (includes integrated navigation controls)" },
    new Technology { Id = 3, Price = 2000.00m, Package = "Visibility Package (includes side and rear cameras)" },
    new Technology { Id = 4, Price = 3000.00m, Package = "Ultra Package (includes navigation and visibility packages)" }
};

// Wheels
List<Wheels> wheels = new List<Wheels>
{
    new Wheels { Id = 1, Price = 400.00m, Style = "17-inch Pair Radial" },
    new Wheels { Id = 2, Price = 450.00m, Style = "17-inch Pair Radial Black" },
    new Wheels { Id = 3, Price = 500.00m, Style = "18-inch Pair Spoke Silver" },
    new Wheels { Id = 4, Price = 550.00m, Style = "18-inch Pair Spoke Black" }
};

// Orders (initially empty)
List<Order> orders = new List<Order>();





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();
