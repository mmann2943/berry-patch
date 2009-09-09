using System.Text.RegularExpressions;

namespace BerryPatch.Repository.T4Helpers
{
    public class T4PropertyNameHelper
    {
        private static Regex regex = new Regex("[a-z]+", RegexOptions.ExplicitCapture);
        private static string TransformMatch(Match match)
        {
            var newString = match.Value[0].ToString().ToUpper() + match.Value.Substring(1, match.Value.Length - 1);
            return newString;
        }

        public string Process(string stringToTransform)
        {
            var newString = regex.Replace(stringToTransform, TransformMatch);
            return newString.Replace("_", "");
        }
    }
}