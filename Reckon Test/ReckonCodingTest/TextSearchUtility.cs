using System.Collections.Generic;
using System.Linq;

namespace ReckonCodingTest
{
    public class TextSearchUtility
    {
        private const string NoOutput = "<No Output>";

        /// <summary>
        /// Finds all the occurrences of a particular
        /// set of characters in a string.
        /// </summary>
        /// <param name="textToSearch">Actual Text to search</param>
        /// <param name="subText">Sub text to be searched in textToSearch</param>
        /// <returns>Returns the indexes in a srting format.</returns>
        public string Find(string textToSearch, string subText)
        {
            if (string.IsNullOrEmpty(textToSearch) || string.IsNullOrEmpty(subText)) 
                return NoOutput;

            var lowertextToSearch = textToSearch.ToLowerInvariant();
            var lowerSubText = subText.ToLowerInvariant();
            var output = string.Empty;
            var indexes = new List<int>();

            for (var index = 0; index <= lowertextToSearch.Length; index += lowerSubText.Length)
            {
                index = FindIndex(indexes.Any() ? indexes.Last() + subText.Length : 0, 
                                 lowerSubText,
                                 lowertextToSearch);

                if (index == -1)
                    break;
                indexes.Add(index);
            }

            if (indexes.Count <= 0) return NoOutput;
            
            for (var i = 0; i < indexes.Count; i++)
            {
                output += (indexes[i] + 1).ToString();
                if (i < indexes.Count - 1)
                {
                    output += ", ";
                }
            }
            return output;
        }

        /// <summary>
        /// Method that returns starting index of subText in textToSearch
        /// </summary>
        /// <param name="startIndex">start index from where text search should begin</param>
        /// <param name="subText">Sub text to be searched in textToSearch</param>
        /// <param name="textToSearch">Actual Text to search</param>
        /// <returns>first index of subText occurance</returns>
        private int FindIndex(int startIndex, string subText, string textToSearch)
        {
            var index = -1;
            var textToSearchIndex = 0;
            
            if (string.IsNullOrEmpty(subText) || string.IsNullOrEmpty(textToSearch))
                return -1;

            for (var subtextIndex = startIndex; subtextIndex < textToSearch.Length; subtextIndex++)
            {
                if (subText[textToSearchIndex] == textToSearch[subtextIndex])
                {
                    if (textToSearchIndex == 0)
                        index = subtextIndex;
            
                    textToSearchIndex++;
                    if (textToSearchIndex >= subText.Length)
                        return index;
                }
                else
                {
                    textToSearchIndex = 0;
                    
                    if (index >= 0)
                        subtextIndex = index;
                    index = -1;
                }
            }
            
            return -1;
        }
    }
}
