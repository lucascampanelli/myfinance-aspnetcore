using myfinance_aspnetcore_infra;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Adicionando o serviço de contexto do banco de dados do Entity Framework
builder.Services.AddDbContext<MyFinanceDbContext>();


// Constrói p contêiner da aplicação
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redireciona para o HTTPS
app.UseHttpsRedirection();

// Utiliza arquivos estáticos, permitindo o acesso ao "wwwroot"
app.UseStaticFiles();

// Utiliza roteamento
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Sobe a aplicação
app.Run();
