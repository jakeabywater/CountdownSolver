namespace NewNumbersRound
{
    public class NumbersRoundMain
    {
        public static void NumbersRoundNew()
        {
            //add input validation
            Console.WriteLine("Enter 6 numbers, separated by commas;");
            string numbers = Console.ReadLine();
            Console.WriteLine("Enter the target number");
            string targetNumber = Console.ReadLine();
            List<string> numbersList = numbers.Split(',').ToList();
            if (numbersList.Contains(targetNumber.ToString()))
            {
                Console.WriteLine($"The target can be reached through the calculation {targetNumber}.");
            }
        }
    }
    public class Maintanance
    {
        public static void NumbersRoundFileGenerator()
        {
            List<string> numbersSubstitutes = new List<string> { "a", "b", "c", "d", "e", "f" };
            List<List<string>> permutations = new List<List<String>>(Permutations(numbersSubstitutes));
        }

        public static List<List<string>> Permutations(List<string> numbers)
        {
            List<List<string>> permutations = new List<List<string>>();
            permutations.AddRange(GeneratePermutations(numbers, 6));
            permutations.AddRange(GeneratePermutations(numbers, 5));
            permutations.AddRange(GeneratePermutations(numbers, 4));
            permutations.AddRange(GeneratePermutations(numbers, 3));
            permutations.AddRange(GeneratePermutations(numbers, 2));
            return permutations;
        }

        

        private static List<List<string>> GeneratePermutations(List<string> numbers, int length)
        {
            List<List<string>> permutations = new List<List<string>>();
            GeneratePermutationsRecursive(numbers, new List<string>(), permutations, length);
            return permutations;
        }

        private static void GeneratePermutationsRecursive(List<string> numbers, List<string> current, List<List<string>> permutations, int length)
        {
            if (current.Count == length)
            {
                permutations.Add(new List<string>(current));
                return;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!current.Contains(numbers[i]))
                {
                    current.Add(numbers[i]);
                    GeneratePermutationsRecursive(numbers, current, permutations, length);
                    current.RemoveAt(current.Count - 1);
                }

            }
        }
        public static void Test2()
        {
            List<string> numbers = new List<string> { "a", "b", "c", "d", "e", "f" };
            HashSet<string> results = new HashSet<string>();
            for (int i = 1; i <= numbers.Count; i++)
            {
                results.UnionWith(GenerateBracketPermutations(numbers, i));
            }

            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }
        public static List<string> GenerateBracketPermutations(List<string> numbers, int length)
        {
            List<string> results = new List<string>();
            GenerateBracketPermutationsRecursive(numbers, new List<string>(), results, length);
            return results;
        }

        private static void GenerateBracketPermutationsRecursive(List<string> numbers, List<string> list, List<string> results, int length)
        {
            throw new NotImplementedException();
        }
    }
}