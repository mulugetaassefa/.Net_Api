using AdvisoryApp.DataBaseSetting;
using AdvisoryApp.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configration to map admin  database setting to interface for dependancy injection

builder.Services.Configure<AdminDataBaseSettings>
    (builder.Configuration.GetSection(nameof(AdminDataBaseSettings)));

builder.Services.AddSingleton<IAdminDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<AdminDataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("AdminDatabaseSettings:ConnectionString")));


// configration to map Advisor database setting to interface for dependancy injection

builder.Services.Configure<AdvisorDataBaseSettings>(
                builder.Configuration.GetSection(nameof(AdvisorDataBaseSettings)));

builder.Services.AddSingleton<IAdvisorDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<AdvisorDataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("AdvisorDatabaseSettings:ConnectionString")));

// configration to map student  database setting to interface for dependancy injection 
builder.Services.Configure<StudentDataBaseSettings>(
                builder.Configuration.GetSection(nameof(StudentDataBaseSettings)));

builder.Services.AddSingleton<IStudentDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<StudentDataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("StudentDatabaseSettings:ConnectionString")));

// configration to map appointment  database setting to interface for dependancy injection 
builder.Services.Configure<AppointmentDataBaseSettings>(
                builder.Configuration.GetSection(nameof(AppointmentDataBaseSettings)));

builder.Services.AddSingleton<IAppointmentDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<AppointmentDataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("AppointmentDatabaseSettings:ConnectionString")));



// configration to map chat  database setting to interface for dependancy injectionn 
builder.Services.Configure<ChatDataBaseSettings>(
                builder.Configuration.GetSection(nameof(ChatDataBaseSettings)));

builder.Services.AddSingleton<IChatDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ChatDataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("ChatDatabaseSettings:ConnectionString")));



// configration to map post  database setting to interface for dependancy injectionn 
builder.Services.Configure<PostDataBaseSettings>(
                builder.Configuration.GetSection(nameof(PostDataBaseSettings)));

builder.Services.AddSingleton<IpostDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<PostDataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("PostDatabaseSettings:ConnectionString")));


builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<IAppointmentServices, AppointmentServices>();
builder.Services.AddScoped<IPostServices, PostServices>();
builder.Services.AddScoped<IChatServices, ChatServices>();
builder.Services.AddScoped<IAdvisorServices, AdvisorServices>();

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

app.Run();
