namespace PropertiesApi.Domain.Options.Pagination;

public class Paged<TEntity> : List<TEntity>
{
    public MetaData MetaData { get; set; }

    public Paged(IEnumerable<TEntity> prmListaElementos, int prmTotalDeRegistros, int? prmNumeroDeFilas, int? prmNumeroDePagina)
    {
        MetaData = new MetaData
        {
            TotalDeRegistros = prmTotalDeRegistros,
            TamanoPagina = prmNumeroDeFilas ?? ValuesByDefaultPaged.NumberFiles_ByDefault,
            PaginaActual = prmNumeroDePagina ?? ValuesByDefaultPaged.NumberPage_ByDefault,
            PaginasTotales = (int)Math.Ceiling(prmTotalDeRegistros / (double)(prmNumeroDeFilas ?? ValuesByDefaultPaged.NumberFiles_ByDefault)),
            RegistrosDevueltoPorLaPagina = prmListaElementos.ToList().Count
        };
        AddRange(prmListaElementos);
    }
}
