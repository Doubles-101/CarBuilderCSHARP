using CarBuilderCSHARP.Models;
using CarBuilderCSHARP.Models.DTOs;

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
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
}

app.UseHttpsRedirection();


// GET Wheels
app.MapGet("/wheels", () => 
{
    return wheels.Select(t => new WheelsDTO
    {
        Id = t.Id,
        Price = t.Price,
        Style = t.Style
    });
});



// GET Technologies
app.MapGet("/technologies", () => 
{
    return technologies.Select(t => new TechnologyDTO
    {
        Id = t.Id,
        Price = t.Price,
        Package = t.Package
    });
});



// GET Interiors
app.MapGet("/interiors", () => 
{
    return interiors.Select(t => new InteriorDTO
    {
        Id = t.Id,
        Price = t.Price,
        Material = t.Material
    });
});



// GET Paints
app.MapGet("/paintcolors", () => 
{
    return paintColors.Select(t => new PaintColorDTO
    {
        Id = t.Id,
        Price = t.Price,
        Color = t.Color
    });
});


// GET Orders
app.MapGet("/orders", () =>
{
    return orders.Select(o => new OrderDTO
    {
        Id = o.Id,
        Timestamp = o.Timestamp,
        WheelId = o.WheelId,
        TechnologyId = o.TechnologyId,
        PaintId = o.PaintId,
        InteriorId = o.InteriorId,
        // Optionally include full details of related data
        Wheel = wheels.FirstOrDefault(w => w.Id == o.WheelId),
        Technology = technologies.FirstOrDefault(t => t.Id == o.TechnologyId),
        Paint = paintColors.FirstOrDefault(p => p.Id == o.PaintId),
        Interior = interiors.FirstOrDefault(i => i.Id == o.InteriorId)
    });
});



// POST Create Order
app.MapPost("/orders", (OrderDTO newOrder) =>
{
    // Generate a new ID by finding the max ID in the collection
    int newId = orders.Any() ? orders.Max(o => o.Id) + 1 : 1;

    // Create a new order with server-side timestamp
    var order = new Order
    {
        Id = newId,
        Timestamp = DateTime.Now, // Set the current timestamp
        WheelId = newOrder.WheelId,
        TechnologyId = newOrder.TechnologyId,
        PaintId = newOrder.PaintId,
        InteriorId = newOrder.InteriorId
    };

    // Add the order to the collection
    orders.Add(order);

    // Return the newly created order
    return Results.Created($"/orders/{newId}", order);
});


// This API communicates with car-builder client application!


app.Run();
