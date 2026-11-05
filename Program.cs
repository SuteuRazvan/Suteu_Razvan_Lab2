using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Suteu_Razvan_Lab2;
using Suteu_Razvan_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Conexiunea pentru contextul existent al aplicației (Cărți, Membri, Împrumuturi)
builder.Services.AddDbContext<Suteu_Razvan_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Suteu_Razvan_Lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Suteu_Razvan_Lab2Context' not found.")));

// 2. Conexiunea pentru contextul Identity (creat la pasul 15)
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Suteu_Razvan_Lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Suteu_Razvan_Lab2Context' not found.")));

// 3. Înregistrarea Identity cu IdentityUser (nu ApplicationUser)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();