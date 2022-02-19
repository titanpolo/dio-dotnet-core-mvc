//Entenda as mudanças do .net5 para o .net 6: https://www.youtube.com/watch?v=rCHs9oEKKpM
//Ignore o que ele fala depois do minuto 4:21, pelo menos para esse projeto.
using dio_dotnet_core_mvc.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container. --> substitui o antigo método ConfigureServices do .Net 5 e anteriores
//Perceba que a única diferença do corpo do método é a utilização do objeto "build.Services" ao invés de "services"
//Além disso não há a necessidade de se criar um método, os serviços são colocados nesse "container"
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>
    (options  => options.UseSqlServer
    (@"Server = localhost\MSSQLSERVER01; Database = dbteste; Trusted_Connection = True"));


//======================================================= fim do container de services
//=========================================================                                 PRECISO FAZER O SCAFFOLDS! NÃO TA FUNFANDO!

var app = builder.Build();

// Configure the HTTP request pipeline.
//Outra mudança é a varável app, que agora é instanciada e recebe as atribuiçções diretamete na classe Program.cs
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
