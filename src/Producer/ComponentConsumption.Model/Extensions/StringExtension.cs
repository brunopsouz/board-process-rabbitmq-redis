using System.Diagnostics.CodeAnalysis;

namespace ComponentConsumption.Model
{
    public static class StringExtension
    {
        /// <summary>
        /// Checks if the string is not null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        
        // Método não é nulo, ou seja, deve retornar verdadeiro.
        // [NotNullWhen(true)] = indica que o método retornará um valor não nulo quando retornar true.
        // Eu garanto que se a função NotEmpty retornar true, eu garato que "value" nao será nulo. 
        public static bool NotEmpty([NotNullWhen(true)] this string? value) => string.IsNullOrWhiteSpace(value).IsFalse();
    }
}
