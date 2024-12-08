using Indian_Army_Recruitment.Data;
using Microsoft.Extensions.Configuration;
using Indian_Army_Recruitment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using Indian_Army_Recruitment.Services.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Indian_Army_Recruitment.Repositories.Repos;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Repositories.ReposInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
var builder = WebApplication.CreateBuilder(args);
var jwtval = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtval["Key"]);
// Add services to the container.
//Authentication
builder.Services.AddAuthentication(i =>
{
    i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(i =>
{
    i.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtval["Issuer"],
        ValidAudience = jwtval["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

//Authorization
builder.Services.AddAuthorization(i =>
{
    i.AddPolicy("AdminOnly", j => j.RequireRole("Admin"));
    i.AddPolicy("RecruiterOnly", j => j.RequireRole("Recruiter"));
    i.AddPolicy("HealthOfficeOnly", j => j.RequireRole("HealthOfficer"));
    i.AddPolicy("ArmyOfficials", j => j.RequireRole("HealthOfficer","Recruiter","Admin"));
});

builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDocumentVerificationRepository, DocumentVerificationRepository>();
builder.Services.AddScoped<IRequiredDocumentRepository, RequiredDocumentRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITrainingProgramRepository, TrainingProgramRepository>();
builder.Services.AddScoped<IVacancyExamRepository, VacancyExamRepository>();
builder.Services.AddScoped<IVacancyExamResultRepository, VacancyExamResultRepository>();
builder.Services.AddScoped<IVacancyRepository, VacancyRepository>();
builder.Services.AddScoped<ICandidateDocumentRepository, CandidateDocumentRepository>();
builder.Services.AddScoped<ICandidateProfileRepository, CandidateProfileRepository>();
builder.Services.AddScoped<ICandidateDocumentService, CandidateDocumentService>();
builder.Services.AddScoped<ICandidateProfileService, CandidateProfileService>();
builder.Services.AddScoped<IApplicationService , ApplicationService>();
builder.Services.AddScoped<IVacancyExamService, VacancyExamService>();
builder.Services.AddScoped<IVacancyService, VacancyService>();
builder.Services.AddScoped<IRequiredDocumentService, RequiredDocumentService>();
builder.Services.AddScoped<ITrainingProgramService, TrainingProgramService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IVacancyExamResultService, VacancyExamResultService>();
builder.Services.AddScoped<IVacancyAnalysisService, VacancyAnalysisService>();
builder.Services.AddScoped<IPlatformAccessService, PlatformAccessService>();
builder.Services.AddScoped<IPlatformAccessRepository, PlatformAccessRepository>();
builder.Services.AddTransient<IEmailService, EmailService>();
//EF
builder.Services.AddDbContext<ApplicationDbContext>(i => i.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
