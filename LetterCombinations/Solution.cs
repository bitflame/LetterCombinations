using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinations
{
    class Solution { 
    
      public IEnumerable<Char []> linqCartisian(Char [] a, Char []b)
        {
            Char[] result = new Char[] { };
            var product = from first in a from second in b select new[] { first, second };
            return product;
        } 
        //From https://stackoverflow.com/a/4424005 
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
        {
            var accum = new List<T[]>();
            var list = sequences.ToList();
            if (list.Count > 0)
            {
                var enumStack = new Stack<IEnumerator<T>>();
                var itemStack = new Stack<T>();
                int index = list.Count - 1;
                var enumerator = list[index].GetEnumerator();
                while (true)
                    if (enumerator.MoveNext())
                    {
                        itemStack.Push(enumerator.Current);
                        if (index == 0)
                        {
                            accum.Add(itemStack.ToArray());
                            itemStack.Pop();
                        }
                        else
                        {
                            enumStack.Push(enumerator);
                            enumerator = list[--index].GetEnumerator();
                        }
                    }
                    else
                    {
                        if (++index == list.Count)
                            break;
                        itemStack.Pop();
                        enumerator = enumStack.Pop();
                    }
            }
            return accum;
        }

        public List<String> LetterCombinations(string digits)
        {
            List<String> result = new List<String>();
            if ((digits == null) || (digits==""))
            {
                return result;
            }
            Dictionary<Char, Char[]> letterMap = new Dictionary<Char, Char[]>();
            letterMap.Add('0', new Char[] { });
            letterMap.Add('1', new Char[] { });
            letterMap.Add('2', new Char[] { 'a', 'b', 'c' });
            letterMap.Add('3', new Char[] { 'd', 'e', 'f' });
            letterMap.Add('4', new Char[] { 'g', 'h', 'i' });
            letterMap.Add('5', new Char[] { 'j', 'k', 'l' });
            letterMap.Add('6', new Char[] { 'm', 'n', 'o' });
            letterMap.Add('7', new Char[] { 'p', 'q', 'r','s' });
            letterMap.Add('8', new Char[] { 't', 'u', 'v' });
            letterMap.Add('9', new Char[] { 'w', 'x','y','z' });
            StringBuilder sb = new StringBuilder();

            letterCombinationsHelper(digits, sb, letterMap, result);
            return result;
        }
        private void letterCombinationsHelper(String digits, StringBuilder sb, Dictionary<Char, Char[]> letterMap, List<String> result)
        {
            if (sb.Length == digits.Length)
            {
                result.Add(sb.ToString());
                return;
            }
            char[] digiChars = digits.ToCharArray();
            for (int i = 0; i < digiChars.Length; i++)
            {
                letterMap.TryGetValue(digiChars[i], out char[] letters);
                sb.Append(letters);
                letterCombinationsHelper(digits, sb, letterMap, result);
                sb.Remove(sb.Length, sb.Length);
            }
        }
    }
}
