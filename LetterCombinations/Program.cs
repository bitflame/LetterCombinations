using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            Char [] firstLetters = { 'a','b','c'};
            Char [] secondLetters = { 'd','e','f'};
            Solution firstCombos = new Solution();
            foreach (var item in firstCombos.linqCartisian(firstLetters,secondLetters))
            {
                foreach (var item2 in item)
                {
                    Console.Write(item2);
                }
                Console.Write(',');
            }
            //firstCombos.CartesianProduct<List<String>>(letters);
            Console.ReadLine();
        }
    }
}
