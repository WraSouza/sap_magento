using System.Reflection;
using SAP_MAGENTO.Controllers.SAPControllers;
using SAP_MAGENTO.Helpers;
using SAP_MAGENTO.Models.SAPModels;
using SAP_MAGENTO.Repositories.SAPRepositories.SAPItemsRepository;
using SAP_MAGENTO.Repositories.SAPRepository.SAPItemRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.Configure<LoginSAP>(builder.Configuration.GetSection("SAPLogin"));

builder.Services.AddSingleton<ISAPItemsRepository, SAPItemsRepository>();
builder.Services.AddSingleton<LoginSAP>();
builder.Services.AddSingleton<LoginHelper>();

builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen(opt => 
{
    opt.SwaggerDoc("v1", new () { Title = "API SAP Magento", Version = "v1" });
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("")
.BusinessPartnerEndpoint()
.WithTags("SAP - Business Partner");

app.MapGroup("")
.ItemEndpoint()
.WithTags("SAP - Item");

app.UseHttpsRedirection();

app.Run();

