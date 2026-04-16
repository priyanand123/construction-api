using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Application.Mappings;
using ConstructionBilling.Application.Services;
using ConstructionBilling.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Interfaces;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add AutoMapper and configure mapping profiles
services.AddAutoMapper(typeof(MappingProfile));
services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
services.AddScoped<ILabourService, LabourService>();
services.AddScoped<ILabourRepository, LabourRepository>();
services.AddScoped<IUnitService, UnitService>();
services.AddScoped<IUnitRepository, UnitRepository>();
services.AddScoped<IDieselService, DieselService>();
services.AddScoped<IDieselRepository, DieselRepository>();
services.AddScoped<ITripService, TripService>();
services.AddScoped<ITripRepository, TripRepository>();
services.AddScoped<IRawMaterialService, RawMaterialService>();
services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();
services.AddScoped<IPurchaseDetailService, PurchaseDetailService>();
services.AddScoped<IPurchaseDetailRepository, PurchaseDetailRepository>();
services.AddScoped<IRoleService, RoleService > ();
services.AddScoped<IRoleRepository,RoleRepository>();
services.AddScoped<IDataBaseConnection, DataBaseConnection>();
services.AddScoped<IMachineLogDetailService, MachineLogDetailService>();
services.AddScoped<IMachineLogDetailRepository, MachineLogDetailRepository>();
services.AddScoped<IMaterialHistoryService, MaterialHistoryService>();
services.AddScoped<IMaterialHistoryRepository, MaterialHistoryRepository>();
services.AddScoped<IStockService, StockService>();
services.AddScoped<IStockRepository,StockRepository>();
services.AddScoped<IAttachmentService, AttachmentService>();
services.AddScoped<IAttachmentRepository,AttachmentRepository>();
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IBillingRepository,BillingRepository>();
services.AddScoped<IBillingService, BillingService>();
services.AddScoped<ICompanyDetailsService, CompanyDetailsService>();
services.AddScoped<ICompanyDetailsRepository, CompanyDetailsRepository>();
services.AddScoped<IBillingDetailsWithoutGSTService, BillingDetailsWithoutGSTService>();
services.AddScoped<IBillingDetailsWithoutGSTRepository, BillingDetailsWithoutGSTRepository>();
services.AddControllers();
services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

services.AddLocalization();
services.AddMvc();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Construction.API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Construction.API Authorization",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Construction.Service.API v1"));

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.UseCors("MyAllowSpecificOrigins");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
