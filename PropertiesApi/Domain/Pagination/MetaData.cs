namespace PropertiesApi.Domain.Options.Pagination
{
    public class MetaData
    {
        public int PaginaActual { get; set; }
        public int PaginasTotales { get; set; }
        public int? TamanoPagina { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegistrosDevueltoPorLaPagina { get; set; }
        public bool PuedeRetroceder => PaginaActual > 1;
        public bool PuedeAvanzar => PaginaActual < PaginasTotales;
    }
}
