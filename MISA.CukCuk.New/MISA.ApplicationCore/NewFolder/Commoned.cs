using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.NewFolder
{
    public class Commoned
    {
        public DynamicParameters GetParam(object entity)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = propertyValue.ToString();
                }
                if (property.PropertyType == typeof(string) && propertyValue != null)
                    if (propertyValue.ToString() == "")
                        propertyValue = null;
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            return dynamicParameters;
        }
    }
}
