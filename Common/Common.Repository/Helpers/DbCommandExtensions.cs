using System.Data;

namespace Common.Repository.Helpers
{
    public static class DbCommandExtensions
    {
        public static void AddParameterWithValue(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
    }
}