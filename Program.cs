var builder = WebApplication.CreateBuilder(args);


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

app.MapGet("/escolha", (float preco) =>
{
    float precoIdeal = (preco * 70) / 100;

    return Results.Ok($"Se o preço do alcool for menor que {precoIdeal}, abastece com alcool.");
});

app.MapGet("/precoKM", (float precoGasolina, float mediaKM) =>
{
    float valorKM = precoGasolina / mediaKM;

    return Results.Ok($"Custo por km é {valorKM.ToString("F2")}.");

});

app.Run();
