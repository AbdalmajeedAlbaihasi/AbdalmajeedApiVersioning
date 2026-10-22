using Asp.Versioning;
using Business;
using DataAccess;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Controllers
builder.Services.AddControllers();

// 2. Register Layer Services
builder.Services.AddScoped<ProductDataAccess>();
builder.Services.AddScoped<ProductBusiness>();

// 3. Configure API Versioning & ApiExplorer
builder.Services.AddApiVersioning(options =>
{
options.DefaultApiVersion = new ApiVersion(1, 0); 
    options.AssumeDefaultVersionWhenUnspecified = false; 
options.ReportApiVersions = true;
options.ApiVersionReader = new UrlSegmentApiVersionReader(); 
})
.AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// 4. Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // تعريف الإصدار الأول V1
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Products API - V1",
        Version = "v1"
    });

    // تعريف الإصدار الثاني V2
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Products API - V2",
        Version = "v2"
    });

    // حل تضارب أسماء الـ DTOs المتشابهة بين V1 و V2
    options.CustomSchemaIds(type => type.FullName);
});

var app = builder.Build();

// 5. Configure HTTP Pipeline & Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // إضافة القائمة المنسدلة للتنقل بين الإصدارات في Swagger UI
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "V2");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();