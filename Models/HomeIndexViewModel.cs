using System;
namespace PortafolioNet6.Models
{
	public class HomeIndexViewModel
	{
        public IEnumerable<Proyecto> Proyectos { get; set; }
        public Persona Persona { get; set; }
    }
}

