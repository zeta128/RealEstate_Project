using Abp.Linq.Expressions;
using Ardalis.Specification;
using PropertiesApi.Domain.DTOs;
using System.Linq.Expressions;

namespace PropertiesApi.Application.Common.Specifications
{
    public static class SpecificationExtensions
    {
        public static IOrderedSpecificationBuilder<TEntity>? OrderBy<TEntity>(
            this ISpecificationBuilder<TEntity> specificationBuilder,
            string nombreCampo, string direccionOrdenamiento)
        {
            var partesCampo = nombreCampo.Split('.');

            var parametro = Expression.Parameter(typeof(TEntity));

            Expression expresion = parametro;

            foreach (var parteCampo in partesCampo)
            {
                var propiedad = expresion.Type.GetProperties()
                    .FirstOrDefault(p => p.Name.Equals(parteCampo, StringComparison.OrdinalIgnoreCase));

                if (propiedad is null) return null;

                if (propiedad.GetGetMethod()?.IsVirtual == true)
                {
                    expresion = Expression.Property(expresion, propiedad);
                }
                else
                {
                    expresion = Expression.PropertyOrField(expresion, propiedad.Name);
                }
            }

            var conversion = Expression.Convert(expresion, typeof(object));
            var lambda = Expression.Lambda<Func<TEntity, object?>>(conversion, parametro);

            return direccionOrdenamiento.ToLower().Equals("desc") ?
                specificationBuilder.OrderByDescending(lambda, true) : specificationBuilder.OrderBy(lambda, true);
        }

        public static ISpecificationBuilder<TEntity> Search<TEntity>(
                    this ISpecificationBuilder<TEntity> specificationBuilder,
                    List<FilterDto> filtros,
                    bool searchGroup = true) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var predicate = PredicateBuilder.New<TEntity>(false);

            foreach (var filtro in filtros)
            {
                var searchTermExpression = Expression.Constant(filtro.ValueFilter);
                var property = Expression.Property(parameter, filtro.FieldFilter);
                var containsMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!;
                var containsCall = Expression.Call(property, containsMethod, searchTermExpression);
                var lambda = Expression.Lambda<Func<TEntity, bool>>(containsCall, parameter);
                predicate = predicate.And(lambda);
            }

            return specificationBuilder.Where(predicate, searchGroup);
        }

    }
}
