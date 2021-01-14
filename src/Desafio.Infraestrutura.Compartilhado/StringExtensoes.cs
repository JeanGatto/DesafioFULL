using System.Text.RegularExpressions;

namespace Desafio.Infraestrutura.Compartilhado
{
    public static class StringExtensoes
    {
        private static readonly Regex SomenteNumerosExpressaoRegular
            = new Regex("[^0-9]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string SomenteNumeros(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return texto;
            }

            return SomenteNumerosExpressaoRegular.Replace(texto, string.Empty);
        }
    }
}