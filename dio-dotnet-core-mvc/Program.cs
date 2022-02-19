//Entenda as mudan�as do .net5 para o .net 6: https://www.youtube.com/watch?v=rCHs9oEKKpM
//Ignore o que ele fala depois do minuto 4:21, pelo menos para esse projeto.
using dio_dotnet_core_mvc.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container. --> substitui o antigo m�todo ConfigureServices do .Net 5 e anteriores
//Perceba que a �nica diferen�a do corpo do m�todo � a utiliza��o do objeto "build.Services" ao inv�s de "services"
//Al�m disso n�o h� a necessidade de se criar um m�todo, os servi�os s�o colocados nesse "container"
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>
    (options  => options.UseSqlServer
    (@"Server = localhost\MSSQLSERVER01; Database = dbteste; Trusted_Connection = True"));


//======================================================= fim do container de services
//=========================================================                                 PRECISO FAZER O SCAFFOLDS! N�O TA FUNFANDO!

var app = builder.Build();

// Configure the HTTP request pipeline.
//Outra mudan�a � a var�vel app, que agora � instanciada e recebe as atribui���es diretamete na classe Program.cs
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
