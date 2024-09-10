using System;
using PortafolioNet6.Models;

namespace PortafolioNet6.Servicios
{

    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }

    public class RepositorioProyectos : IRepositorioProyectos
	{

        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
        {
            new Proyecto {Titulo = "Amazon", Descripcion = "E-commerce realizado con Asp .Net Core", Link = "https://amazon.com", ImagenUrl = "/imagenes/amazon.png"},
            new Proyecto {Titulo = "New York Times", Descripcion = "Página de noticias en React", Link = "https://nytimes.com", ImagenUrl = "/imagenes/nyt.png"},
            new Proyecto {Titulo = "Reddit", Descripcion = "Red Social para compartir entre comunidades", Link = "https://reddit.com", ImagenUrl = "/imagenes/reddit.png"},
            new Proyecto {Titulo = "Steam", Descripcion = "Tienda en linea para comprar video juegos", Link = "https://store.steampowered.com", ImagenUrl = "/imagenes/steam.png"}
        };
        }

    }
}

