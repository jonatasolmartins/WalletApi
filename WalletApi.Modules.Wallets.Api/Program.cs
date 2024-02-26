using ModularMonolith.Shared.Database;
using WalletApi.Modules.Wallets.Api;
using WalletApi.Modules.Wallets.Application;
using Wolverine;
using Wolverine.RabbitMQ;
using Extensions = WalletApi.Modules.Wallets.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.Configure<PostgresConfig>(builder.Configuration.GetSection(PostgresConfig.ConfigName));

builder.Host.UseWolverine(opts =>
{
    var rabbitMqSettings = builder.Configuration.GetSection(RabbitMqSettings.ConfigName).Get<RabbitMqSettings>();
    
    opts.UseRabbitMq(new Uri(rabbitMqSettings.ConnectionString));
    opts.Discovery.IncludeAssembly(typeof(Extensions).Assembly);
    
    opts.PublishAllMessages().ToRabbitQueue("wallet");
    
    opts.ListenToRabbitQueue("owner");
    opts.ListenToRabbitQueue("wallet");
});


builder.Services.AddHttpClient<UsersModuleApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5227");
});


builder.Services.AddWalletsModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseWalletsModule();

app.Run();