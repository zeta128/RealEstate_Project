namespace PropertiesApi.Domain.Options.Pagination;

public class Paginado<TEntity> : List<TEntity>
{
    public MetaData MetaData { get; set; }

    public Paginado(IEnumerable<TEntity> prmListaElementos, int prmTotalDeRegistros, int? prmNumeroDeFilas, int? prmNumeroDePagina)
    {
        MetaData = new MetaData
        {
            TotalDeRegistros = prmTotalDeRegistros,
            TamanoPagina = prmNumeroDeFilas ?? ValoresPorDefectoPaginado.NumeroDeFilas_PorDefecto,
            PaginaActual = prmNumeroDePagina ?? ValoresPorDefectoPaginado.NumeroDePagina_PorDefecto,
            PaginasTotales = (int)Math.Ceiling(prmTotalDeRegistros / (double)(prmNumeroDeFilas ?? ValoresPorDefectoPaginado.NumeroDeFilas_PorDefecto)),
            RegiostrosDevueltoPorLaPagina = prmListaElementos.ToList().Count
        };
        AddRange(prmListaElementos);
    }
}
