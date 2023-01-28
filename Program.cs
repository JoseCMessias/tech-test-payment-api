using tech_test_payment_api.Context;
using tech_test_payment_api.Enum;
using tech_test_payment_api.Helpers;
using tech_test_payment_api.Repositories;
using tech_test_payment_api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<VendaContext>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

StateMachine.Process(StatusVenda.AguardandoPagamento,
    new List<StatusVenda> { StatusVenda.PagamentoAprovado, StatusVenda.Cancelado}
    );

StateMachine.Process(StatusVenda.PagamentoAprovado,
    new List<StatusVenda> { StatusVenda.EnviadoTransportadora, StatusVenda.Cancelado }
    );

StateMachine.Process(StatusVenda.EnviadoTransportadora,
    new List<StatusVenda> { StatusVenda.Entregue}
    );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
