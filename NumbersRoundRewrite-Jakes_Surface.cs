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
            permutations.AddRange(PermutationsOfLength6(numbers));
            permutations.AddRange(PermutationsOfLength5(numbers));
            permutations.AddRange(PermutationsOfLength4(numbers));
            permutations.AddRange(PermutationsOfLength3(numbers));
            permutations.AddRange(PermutationsOfLength2(numbers));
            return permutations;
        }

        private static List<List<string>> PermutationsOfLength6(List<string> numbers)
        {
            return GeneratePermutations(numbers, 6);
        }

        private static List<List<string>> PermutationsOfLength5(List<string> numbers)
        {
            return GeneratePermutations(numbers, 5);
        }

        private static List<List<string>> PermutationsOfLength4(List<string> numbers)
        {
            return GeneratePermutations(numbers, 4);
        }

        private static List<List<string>> PermutationsOfLength3(List<string> numbers)
        {
            return GeneratePermutations(numbers, 3);
        }

        private static List<List<string>> PermutationsOfLength2(List<string> numbers)
        {
            return GeneratePermutations(numbers, 2);
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
            List<string> results = new List<string>();
            for (int i = 4; i>0; i--)
            {
                results.AddRange(GenerateBracketPermutations(numbers, i));
            }
           
            
            
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        private static List<string> GenerateBracketPermutations(List<string> numbers, int maxDepth)
        {
            List<string> results = new List<string>();
            GeneratePermutationsRecursive(numbers, 0, numbers.Count - 1, results, 0, maxDepth);
            return results;
        }

        private static void GeneratePermutationsRecursive(List<string> numbers, int start, int end, List<string> results, int currentDepth, int maxDepth)
        {
            if (start == end)
            {
                results.Add(numbers[start]);
                return;
            }

            for (int i = start; i < end; i++)
            {
                List<string> left = new List<string>();
                List<string> right = new List<string>();

                for (int j = start; j <= i; j++)
                {
                    left.Add(numbers[j]);
                }

                for (int j = i + 1; j <= end; j++)
                {
                    right.Add(numbers[j]);
                }

                List<string> leftPermutations = GenerateBracketPermutations(left, maxDepth);
                List<string> rightPermutations = GenerateBracketPermutations(right, maxDepth);

                foreach (var leftPerm in leftPermutations)
                {
                    foreach (var rightPerm in rightPermutations)
                    {
                        string result = $"({leftPerm},{rightPerm})";
                        results.Add(result);
                        if (currentDepth < maxDepth)
                        {
                            GeneratePermutationsRecursive(new List<string> { result }, 0, 0, results, currentDepth + 1, maxDepth);
                        }
                    }
                }
            }
        }
    }
}

