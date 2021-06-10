using System;
using System.Collections.Generic;
using System.Data.Entity;
using Faker;
using parcialdpwa.Models;

namespace parcialdpwa.DAL
{
    public class DiscInitializer : DropCreateDatabaseIfModelChanges<DiscContext>
    {
        protected override void Seed(DiscContext context)
        {
            var empleados = new List<Empleado>
            {
                new Empleado
                {
                    Nombres = Name.First(), Apellidos = Name.Last(), Direccion = Address.UsState(),
                    login = Internet.UserName(), clave = "admin"
                }
            };

            empleados.ForEach(e => context.Empleados.Add(e));
            context.SaveChanges();

            var artistas = new List<Artista>
            {
                new Artista
                {
                    Nombre = Name.First(),
                    Apellido = Name.Last(),
                    LugarDeNacimiento = Address.UsState(),
                    FechaDeNacimiento = Identification.DateOfBirth()
                },
                new Artista
                {
                    Nombre = Name.First(),
                    Apellido = Name.Last(),
                    LugarDeNacimiento = Address.UsState(),
                    FechaDeNacimiento = Identification.DateOfBirth()
                },
                new Artista
                {
                    Nombre = Name.First(),
                    Apellido = Name.Last(),
                    LugarDeNacimiento = Address.UsState(),
                    FechaDeNacimiento = Identification.DateOfBirth()
                },
                new Artista
                {
                    Nombre = Name.First(),
                    Apellido = Name.Last(),
                    LugarDeNacimiento = Address.UsState(),
                    FechaDeNacimiento = Identification.DateOfBirth()
                }
            };
            artistas.ForEach(a => context.Artistas.Add(a));
            context.SaveChanges();

            var categorias = new List<Categoria>
            {
                new Categoria
                {
                    Cat = "Salsa"
                },
                new Categoria
                {
                    Cat = "Cumbia"
                },
                new Categoria
                {
                    Cat = "Texmex"
                },
                new Categoria
                {
                    Cat = "Banda"
                }
            };
            categorias.ForEach(c => context.Categorias.Add(c));
            context.SaveChanges();

            var discos = new List<Disco>
            {
                new Disco
                {
                    CategoriaID = 1,
                    ArtistaID = 1,
                    Fecha = Identification.DateOfBirth(),
                    Formato = Formato.CDDA,
                    Ncanciones = 3,
                    Titulo = Company.Name(),
                    Precio = 10.25M,
                    Imagen = "1.png",
                    Observaciones = "Bueno",
                },
                new Disco
                {
                    CategoriaID = 2,
                    ArtistaID = 1,
                    Fecha = Identification.DateOfBirth(),
                    Formato = Formato.CDDA,
                    Ncanciones = 3,
                    Titulo = Company.Name(),
                    Precio = 1.25M,
                    Imagen = "1.png",
                    Observaciones = "Muy Bueno"
                },
                new Disco
                {
                    CategoriaID = 3,
                    ArtistaID = 2,
                    Fecha = Identification.DateOfBirth(),
                    Formato = Formato.CDR,
                    Ncanciones = 3,
                    Titulo = Company.Name(),
                    Precio = 24.25M,
                    Imagen = "1.png",
                    Observaciones = "Regular"
                },
                new Disco
                {
                    CategoriaID = 4,
                    ArtistaID = 3,
                    Fecha = Identification.DateOfBirth(),
                    Formato = Formato.CDRW,
                    Ncanciones = 2,
                    Titulo = Company.Name(),
                    Precio = 13.25M,
                    Imagen = "1.png",
                    Observaciones = "Excelente"
                }
            };

            discos.ForEach(d => context.Discos.Add(d));
            context.SaveChanges();

            Random rmdn = new Random();
            var canciones = new List<Cancion>
            {
                new Cancion
                {
                    Numero = 1,
                    DiscoID = 1,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 2,
                    DiscoID = 1,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 3,
                    DiscoID = 1,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 1,
                    DiscoID = 2,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 2,
                    DiscoID = 2,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 3,
                    DiscoID = 2,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 1,
                    DiscoID = 3,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 2,
                    DiscoID = 3,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 3,
                    DiscoID = 3,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 1,
                    DiscoID = 4,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                },
                new Cancion
                {
                    Numero = 2,
                    DiscoID = 4,
                    cancion = Name.First(),
                    Tiempo = TimeSpan.FromMinutes(rmdn.Next(1,10)).Add(TimeSpan.FromSeconds(rmdn.Next(1,59)))
                }
            };
            canciones.ForEach(c => context.Canciones.Add(c));
            context.SaveChanges();

            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    Nombres = Name.First(),
                    Apellidos = Name.Last(),
                    Direccion = Address.UsState()
                },
                new Cliente
                {
                    Nombres = Name.First(),
                    Apellidos = Name.Last(),
                    Direccion = Address.UsState()
                },
                new Cliente
                {
                    Nombres = Name.First(),
                    Apellidos = Name.Last(),
                    Direccion = Address.UsState()
                }
            };

            clientes.ForEach(c => context.Clientes.Add(c));
            context.SaveChanges();
        }
    }
}