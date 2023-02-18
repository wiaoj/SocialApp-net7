using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BuildingBlocks.Persistence.EntityFrameworkCore.Conventions;
public class SnakeCaseConvention : IEntityTypeAddedConvention {
    public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext<IConventionEntityTypeBuilder> context) {

        List<IConventionProperty> properties = entityTypeBuilder.Metadata.GetProperties().ToList();

        properties.ForEach(property => {
            property.SetColumnName(CamelCaseToSnakeCase(property.Name));
        });

        //foreach(var property in properties) {
        //    property.SetColumnName(CamelCaseToSnakeCase(property.Name));
        //}
    }

    private static String CamelCaseToSnakeCase(String propertyName) {
        return String.Concat(
            propertyName.Select(
                (x, index) => index > 0 && Char.IsUpper(x) ? $"_{x}" : $"{x}")
            ).ToLowerInvariant();
    }
}