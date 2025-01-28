using System.ComponentModel;

namespace PropertiesApi.Domain.Enums
{
    public enum ValuesByDefaultEnum
    {
        [Description("Value by default for the column or filter IdOwner")]
        IdOwner,
        [Description("Value by default  for the asc action that indicates the ascending order of a query")]
        asc,
        [Description("Value by default  for the desc action that indicates the descending order of a query")]
        desc,
        [Description("Value by default for the column address")]
        address,
    }
}
