var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();
app.MapGet("/{DoughBallsAmuot}/{DoughBallWeight}", (int DoughBallsAmuot,int DoughBallWeight) =>
{
    if (DoughBallsAmuot <= 0 || DoughBallWeight <= 0)
        throw new ArgumentException();
    int TotalDoughWeight = DoughBallWeight * DoughBallsAmuot;
    double flour = TotalDoughWeight / 1.65;
    string recipe = $"""
        Ingredients:
        -{Math.Round(flour,2)}g flour,
        -{Math.Round(flour*0.62,2)}g water,
        -{Math.Round(flour*0.03,2)}g salt,
        -yeast (according to the pacage insctrucion)
           
        1.  Combine {Math.Round(flour * 0.2,2)}g of flour and {Math.Round(flour * 0.2,2)}g of water with yeast,
        mix well and leave it covered in refrigerator for at least 24h (max 72h).
        2.  Add rest of water and flour, and add all salt, mix well and knead the dough.
        3.  Let rest the dough for while and cut the dough into balls.
        4.  Let them rest for at least 30 min.
        5.  Preheat the oven to 250 degrees celsius (Or maximum temperature of your oven).
        If you have baking stone you can use it, or you can preheat your baking sheet.
        6.  Flatten the dough ball, and stretch out into a round, add pizza sause.
        7.  Brush the dough top with olive oil.
        8.  Bake it for 2-3 min, then remove it from oven, and add mozzarella and your favorite ingredients.
        9.  Put it again in the oven until the cheese is melted.
    """;
    return recipe;
});
app.Run();
