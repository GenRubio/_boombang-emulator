namespace boombang_emulator.src.Models
{
    internal class ParameterValidator
    {
        public bool ValidateParameter<T>(object parameterValue)
        {
            // Verificar si el parámetro es nulo
            if (parameterValue == null)
            {
                throw new ArgumentNullException(nameof(parameterValue), "El parámetro no puede ser nulo.");
            }

            // Verificar si el parámetro es del tipo esperado
            if (!(parameterValue is T))
            {
                throw new ArgumentException($"El parámetro debe ser del tipo {typeof(T).Name}.");
            }

            return true;
        }
    }
}
