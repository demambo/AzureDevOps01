using Xunit;
using Microsoft.EntityFrameworkCore;
using AzureDevOps01.Context;



public class ProductoTests
{
    [Fact]
    public void VerificarSiHayDatosEnLaBaseDeDatos()
    {
        /*
        // Configurar el servicio de DbContext para pruebas
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql("server=dmmbmysql.mysql.database.azure.com;database=Despensa;port=3306;uid=redbrow;password=PSanabria*2023",
                    ServerVersion.Parse("8.0.34-mysql")))
            .BuildServiceProvider();
        */
        // Configurar el servicio de DbContext para pruebas
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json") // Ajusta la ubicación del archivo si es necesario
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("conexion"),
                    ServerVersion.Parse("8.0.34-mysql")))
            .BuildServiceProvider();


        /*
        // Crear una instancia del DbContext para pruebas
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Agregar un producto de ejemplo a la base de datos de prueba
            context.Producto.Add(new Producto { Id = 21, Nombre = "Producto de prueba" }); // Cambiar a Id = 20 que no exista
            context.SaveChanges();
        }
        */
        // Verifica si hay datos en la base de datos
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            
            var productos = context.Producto.ToList();

           
            Assert.True(productos.Any());
        }
    }

    [Fact]
    public void ValidarCantidadDeProductosMayorACero()
    {
        /*
        // Configurar el servicio de DbContext para pruebas
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql("server=dmmbmysql.mysql.database.azure.com;database=Despensa;port=3306;uid=redbrow;password=PSanabria*2023",
                    ServerVersion.Parse("8.0.34-mysql")))
            .BuildServiceProvider();
        */
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json") // Ajusta la ubicación del archivo si es necesario
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("conexion"),
                    ServerVersion.Parse("8.0.34-mysql")))
            .BuildServiceProvider();
        /*
        // Crear una instancia del DbContext para pruebas
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Agregar productos de ejemplo a la base de datos de prueba
            context.Producto.Add(new Producto { Id = 30, Nombre = "Producto 1" });
            context.Producto.Add(new Producto { Id = 40, Nombre = "Producto 2" });
            context.SaveChanges();
        }
        */

        // Verifica que la cantidad de productos sea mayor a cero
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            
            var cantidadProductos = context.Producto.Count();

            
            Assert.True(cantidadProductos == 0);
        }
    }
}
