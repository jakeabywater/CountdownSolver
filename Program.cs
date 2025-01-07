using NCalc;
internal class Program
{
    private static void Main(string[] args)
    {
        List<string> testList = new List<string> { ",", "a", ",", "b", ",", "c", ",", "d", ",", "e", ",", "f", "," };
        SolverHelpers.OperatorPermutationsLength6Rewrite(testList);
        Maintainance.NumberPermutationFileGenerator();
        Maintainance.TextFileGenerator();
        RunSolver();

    }

    private static void RunSolver()
    {
        bool runAgain = true;
        while (runAgain)
        {
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("** Countdown Solver v1.0");
            Console.WriteLine("** By jakeabywater");
            Console.WriteLine("** https://github.com/jakeabywater/CountdownSolver");
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("** Welcome to the Countdown Word Round Solver");
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("");
            Console.WriteLine("Enter W to solve the words round, or N to solve the numbers round.");

            bool gameChosen = false;
            while (!gameChosen)
            {
                string gameType = Console.ReadLine().ToUpper();
                if (gameType == "W")
                {
                    gameChosen = true;
                    Solvers.WordRoundSolver();
                }
                else if (gameType == "N")
                {
                    gameChosen = true;
                    Solvers.NumberRoundSolver();
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter W for the Words Round, or N for the Numbers Round.");
                }
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Would you like to use the solver again? (Y/N)");

            bool validInput = false;
            while (!validInput)
            {
                string input = Console.ReadLine();
                if (input.Length == 1)
                {
                    if (input.ToUpper() == "Y")
                    {
                        validInput = true;
                        Console.Clear();
                    }
                    else if (input.ToUpper() == "N")
                    {
                        validInput = true;
                        runAgain = false;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Thanks for using the solver!");
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("Please enter either Y or N.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter either Y or N.");
                }
            }
        }
    }
}
internal class Solvers
{
    public static void WordRoundSolver()
    {
        // take an input of 9 comma separated characters with error handling
        Console.WriteLine("Enter the 9 characters given:");
    try9CharactersAgain:;
        string characters = Console.ReadLine().ToLower();
        bool isAlpha = characters.All(char.IsAsciiLetter);
        if (characters.Length != 9 || !isAlpha)
        {
            Console.WriteLine("You must enter 9 characters. Try again:");
            goto try9CharactersAgain;
        }

        Console.WriteLine("What is the shortest word length you want to try? Enter a number between 1 and 9. (6 is what we reccomend).");
    tryLengthToCheckAgain:;
        if (!int.TryParse(Console.ReadLine(), out int lengthToCheck) || lengthToCheck < 1 || lengthToCheck > 9)
        {
            Console.WriteLine("You must enter a number between 1 and 9. What is the shortest word length you want to try? 6 is what we reccomend.");
            goto tryLengthToCheckAgain;
        }



        string orderedCharacers = new string(characters.OrderBy(c => c).ToArray());
        Dictionary<string, string> resultDictionary = new Dictionary<string, string>();

        //read in the dictionary of words
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string destinationTextFilePath9 = Path.Combine(currentDirectory, "9LetterWords.txt");
        string destinationTextFilePath8 = Path.Combine(currentDirectory, "8LetterWords.txt");
        string destinationTextFilePath7 = Path.Combine(currentDirectory, "7LetterWords.txt");
        string destinationTextFilePath6 = Path.Combine(currentDirectory, "6LetterWords.txt");
        string destinationTextFilePath5 = Path.Combine(currentDirectory, "5LetterWords.txt");
        string destinationTextFilePath4 = Path.Combine(currentDirectory, "4LetterWords.txt");
        string destinationTextFilePath3 = Path.Combine(currentDirectory, "3LetterWords.txt");
        string destinationTextFilePath2 = Path.Combine(currentDirectory, "2LetterWords.txt");
        string destinationTextFilePath1 = Path.Combine(currentDirectory, "1LetterWords.txt");

        Dictionary<string, string> dictionaryOf9LetterWords = File.ReadAllLines(destinationTextFilePath9)
        .Select(line => line.Split(' ', 2))
        .ToDictionary(parts => parts[0], parts => parts[1]);
        Dictionary<string, string> dictionaryOf8LetterWords = File.ReadAllLines(destinationTextFilePath8)
            .Select(line => line.Split(' ', 2))
            .ToDictionary(parts => parts[0], parts => parts[1]);
        Dictionary<string, string> dictionaryOf7LetterWords = File.ReadAllLines(destinationTextFilePath7)
            .Select(line => line.Split(' ', 2))
            .ToDictionary(parts => parts[0], parts => parts[1]);
        Dictionary<string, string> dictionaryOf6LetterWords = File.ReadAllLines(destinationTextFilePath6)
            .Select(line => line.Split(' ', 2))
            .ToDictionary(parts => parts[0], parts => parts[1]);
        Dictionary<string, string> dictionaryOf5LetterWords = File.ReadAllLines(destinationTextFilePath5)
            .Select(line => line.Split(' ', 2))
            .ToDictionary(parts => parts[0], parts => parts[1]);
        Dictionary<string, string> dictionaryOf4LetterWords = File.ReadAllLines(destinationTextFilePath4)
            .Select(line => line.Split(' ', 2))
            .ToDictionary(parts => parts[0], parts => parts[1]);
        Dictionary<string, string> dictionaryOf3LetterWords = File.ReadAllLines(destinationTextFilePath3)
            .Select(line => line.Split(' ', 2))
            .ToDictionary(parts => parts[0], parts => parts[1]);
        Dictionary<string, string> dictionaryOf2LetterWords = File.ReadAllLines(destinationTextFilePath2)
            .Select(line => line.Split(' ', 2))
            .ToDictionary(parts => parts[0], parts => parts[1]);
        Dictionary<string, string> dictionaryOf1LetterWords = File.ReadAllLines(destinationTextFilePath1)
            .Select(line => line.Split(' ', 2))
            .ToDictionary(parts => parts[0], parts => parts[1]);

        //now do each permutation of missing characters

        bool wordFound = false;

        if (dictionaryOf9LetterWords.ContainsValue(orderedCharacers) && lengthToCheck <= 9)
        {
            //return all keys where the value is characters and add these to the result dictionary without using linear search
            resultDictionary = dictionaryOf9LetterWords.Where(x => x.Value == orderedCharacers).ToDictionary(x => x.Key, x => x.Value);
            wordFound = true;
        }
        if (!wordFound && lengthToCheck <= 8)
        {
            for (int i = 0; i < 9; i++)
            {
                string eightCharacters = orderedCharacers;
                eightCharacters = eightCharacters.Remove(i, 1);

                if (dictionaryOf8LetterWords.ContainsValue(eightCharacters))
                {
                    //return all keys where the value is characters and add these to the result dictionary without using linear search
                    resultDictionary = dictionaryOf8LetterWords.Where(x => x.Value == eightCharacters).ToDictionary(x => x.Key, x => x.Value);
                    wordFound = true;
                }
            }
        }
        if (!wordFound && lengthToCheck <= 7)
        {
            //each possible 7 letter word
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string sevenCharacters = orderedCharacers;
                    sevenCharacters = sevenCharacters.Remove(i, 1);
                    sevenCharacters = sevenCharacters.Remove(j, 1);
                    if (sevenCharacters.Length == 7)
                    {
                        if (dictionaryOf7LetterWords.ContainsValue(sevenCharacters))
                        {
                            // Loop through each entry in the dictionary of 7-letter words.
                            foreach (KeyValuePair<string, string> entry in dictionaryOf7LetterWords)
                            {
                                // If the value matches the characters we are looking for
                                if (entry.Value == sevenCharacters)
                                {
                                    if (!resultDictionary.ContainsKey(entry.Key))
                                    {
                                        // Add the key-value pair to resultDictionary
                                        resultDictionary.Add(entry.Key, entry.Value);
                                    }
                                }
                            }
                            wordFound = true;
                        }
                    }
                }
            }
        }
        if (lengthToCheck <= 6)
        {
            //each possible 6 letter word
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        string sixCharacters = orderedCharacers;
                        sixCharacters = sixCharacters.Remove(i, 1);
                        sixCharacters = sixCharacters.Remove(j, 1);
                        sixCharacters = sixCharacters.Remove(k, 1);
                        if (sixCharacters.Length == 6)
                        {
                            if (dictionaryOf6LetterWords.ContainsValue(sixCharacters))
                            {
                                // Loop through each entry in the dictionary of 6-letter words.
                                foreach (KeyValuePair<string, string> entry in dictionaryOf6LetterWords)
                                {
                                    // If the value matches the characters we are looking for
                                    if (entry.Value == sixCharacters)
                                    {
                                        if (!resultDictionary.ContainsKey(entry.Key))
                                        {
                                            // Add the key-value pair to resultDictionary
                                            resultDictionary.Add(entry.Key, entry.Value);
                                        }
                                    }
                                }
                                wordFound = true;
                            }
                        }
                    }
                }
            }
        }

        if (lengthToCheck <= 5)
        {
            //each possible 5 letter word
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        for (int l = 0; l < 6; l++)
                        {
                            string fiveCharacters = orderedCharacers;
                            fiveCharacters = fiveCharacters.Remove(i, 1);
                            fiveCharacters = fiveCharacters.Remove(j, 1);
                            fiveCharacters = fiveCharacters.Remove(k, 1);
                            fiveCharacters = fiveCharacters.Remove(l, 1);
                            if (fiveCharacters.Length == 5)
                            {
                                if (dictionaryOf5LetterWords.ContainsValue(fiveCharacters))
                                {
                                    // Loop through each entry in the dictionary of 5-letter words.
                                    foreach (KeyValuePair<string, string> entry in dictionaryOf5LetterWords)
                                    {
                                        // If the value matches the characters we are looking for
                                        if (entry.Value == fiveCharacters)
                                        {
                                            if (!resultDictionary.ContainsKey(entry.Key))
                                            {
                                                // Add the key-value pair to resultDictionary
                                                resultDictionary.Add(entry.Key, entry.Value);
                                            }
                                        }
                                    }
                                    wordFound = true;
                                }
                            }
                        }
                    }
                }
            }
            if (lengthToCheck <= 4)
            {
                //each possible 4 letter word
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        for (int k = 0; k < 7; k++)
                        {
                            for (int l = 0; l < 6; l++)
                            {
                                for (int m = 0; m < 5; m++)
                                {
                                    string fourCharacters = orderedCharacers;
                                    fourCharacters = fourCharacters.Remove(i, 1);
                                    fourCharacters = fourCharacters.Remove(j, 1);
                                    fourCharacters = fourCharacters.Remove(k, 1);
                                    fourCharacters = fourCharacters.Remove(l, 1);
                                    fourCharacters = fourCharacters.Remove(m, 1);
                                    if (fourCharacters.Length == 4)
                                    {
                                        if (dictionaryOf4LetterWords.ContainsValue(fourCharacters))
                                        {
                                            // Loop through each entry in the dictionary of 4-letter words.
                                            foreach (KeyValuePair<string, string> entry in dictionaryOf4LetterWords)
                                            {
                                                // If the value matches the characters we are looking for
                                                if (entry.Value == fourCharacters)
                                                {
                                                    if (!resultDictionary.ContainsKey(entry.Key))
                                                    {
                                                        // Add the key-value pair to resultDictionary
                                                        resultDictionary.Add(entry.Key, entry.Value);
                                                    }
                                                }
                                            }
                                            wordFound = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (lengthToCheck <= 3)
        {
            //each possible 3 letter word
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        for (int l = 0; l < 6; l++)
                        {
                            for (int m = 0; m < 5; m++)
                            {
                                for (int n = 0; n < 4; n++)
                                {
                                    string threeCharacters = orderedCharacers;
                                    threeCharacters = threeCharacters.Remove(i, 1);
                                    threeCharacters = threeCharacters.Remove(j, 1);
                                    threeCharacters = threeCharacters.Remove(k, 1);
                                    threeCharacters = threeCharacters.Remove(l, 1);
                                    threeCharacters = threeCharacters.Remove(m, 1);
                                    threeCharacters = threeCharacters.Remove(n, 1);
                                    if (dictionaryOf3LetterWords.ContainsValue(threeCharacters))
                                    {
                                        // Loop through each entry in the dictionary of 3-letter words.
                                        foreach (KeyValuePair<string, string> entry in dictionaryOf3LetterWords)
                                        {
                                            // If the value matches the characters we are looking for
                                            if (entry.Value == threeCharacters)
                                            {
                                                if (!resultDictionary.ContainsKey(entry.Key))
                                                {
                                                    // Add the key-value pair to resultDictionary
                                                    resultDictionary.Add(entry.Key, entry.Value);
                                                }
                                            }
                                        }
                                        wordFound = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (lengthToCheck <= 2)
        {
            //each possible 2 letter word
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        for (int l = 0; l < 6; l++)
                        {
                            for (int m = 0; m < 5; m++)
                            {
                                for (int n = 0; n < 4; n++)
                                {
                                    for (int o = 0; o < 3; o++)
                                    {
                                        string twoCharacters = orderedCharacers;
                                        twoCharacters = twoCharacters.Remove(i, 1);
                                        twoCharacters = twoCharacters.Remove(j, 1);
                                        twoCharacters = twoCharacters.Remove(k, 1);
                                        twoCharacters = twoCharacters.Remove(l, 1);
                                        twoCharacters = twoCharacters.Remove(m, 1);
                                        twoCharacters = twoCharacters.Remove(n, 1);
                                        twoCharacters = twoCharacters.Remove(o, 1);
                                        if (dictionaryOf2LetterWords.ContainsValue(twoCharacters))
                                        {
                                            // Loop through each entry in the dictionary of 2-letter words.
                                            foreach (KeyValuePair<string, string> entry in dictionaryOf2LetterWords)
                                            {
                                                // If the value matches the characters we are looking for
                                                if (entry.Value == twoCharacters)
                                                {
                                                    if (!resultDictionary.ContainsKey(entry.Key))
                                                    {
                                                        // Add the key-value pair to resultDictionary
                                                        resultDictionary.Add(entry.Key, entry.Value);
                                                    }
                                                }
                                            }
                                            wordFound = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (lengthToCheck <= 1)
            {
                //each possible one letter word
                foreach (char character in orderedCharacers)
                {
                    string oneCharacter = character.ToString();
                    if (dictionaryOf1LetterWords.ContainsValue(oneCharacter))
                    {
                        // Loop through each entry in the dictionary of 1-letter words.
                        foreach (KeyValuePair<string, string> entry in dictionaryOf1LetterWords)
                        {
                            // If the value matches the characters we are looking for
                            if (entry.Value == oneCharacter)
                            {
                                if (!resultDictionary.ContainsKey(entry.Key))
                                {
                                    // Add the key-value pair to resultDictionary
                                    resultDictionary.Add(entry.Key, entry.Value);
                                }
                            }
                        }
                        wordFound = true;
                    }
                }
            }
        }

        List<string> sortedKeys = resultDictionary.Keys
                            .OrderBy(key => key.Length)  // Sort by length in reverse order
                            .ThenByDescending(key => key)                    // Then sort alphabetically within the same length
                            .ToList();
        if (wordFound)
        {
            Console.WriteLine();
            foreach (string word in sortedKeys)
            {
                Console.WriteLine($"{word}, length:{word.Length}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"These are all the words that can be made from the letters {characters.ToUpper()} with a length greater than or equal to {lengthToCheck}.");
        }
        else
        {
            Console.WriteLine($"No words can be found made from the letters {characters.ToUpper()} with a length greater than or equal to {lengthToCheck}.");
        }
    }

    public static void NumberRoundSolver()
    {
        //add input validation
        Console.WriteLine("Enter 6 numbers, separated by commas;");
        string numbers = Console.ReadLine();
        Console.WriteLine("Enter the target number");
        int targetNumber = Convert.ToInt32(Console.ReadLine());
        int[] numbersArray = Array.ConvertAll(numbers.Split(','), int.Parse);
        if (numbersArray.Contains(targetNumber))
        {
            Console.WriteLine($"The target can be reached through the calculation {targetNumber}.");
        }
        //create every permutation of the numbers of every possible length and order,
        //starting with using all numbers and descending in length
        List<List<int>> permutations = new List<List<int>>();

        permutations.AddRange(SolverHelpers.Permutations(numbersArray));
        HashSet<List<string>> expressionLists = new HashSet<List<string>>();
        foreach (List<int> permutation in permutations)
        {
            //there are 5 possible slots to place in operators 0-5
            //there are 7 possible slots to place brackets, however each must be a pair
            //( can be placed in gaps 0-6
            // ) can be placed in gaps 1-7
            // number of ( must equal number of )
            //a ) cannot be placed before any (
            //a ( cannot be placed after any )
            List<string> expressionList = new List<string>();
            foreach (int number in permutation)
            {
                expressionList.Add(",");
                expressionList.Add(number.ToString());

            }
            expressionList.Add(",");

            switch (permutation.Count)
            {
                case 6:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength6(expressionList));
                    break;
                case 5:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength5(expressionList));
                    break;
                case 4:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength4(expressionList));
                    break;
                case 3:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength3(expressionList));
                    break;
                case 2:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength2(expressionList));
                    break;
                default:
                    Console.WriteLine("Something wrong???");
                    break;
            }




        }
        List<string> targetExpressions = new List<string>();
        Dictionary<string, int> results = new Dictionary<string, int>();
        List<string> expressionStrings = new List<string>();
        foreach (List<string> expressionStringList in expressionLists)
        {
            string expressionString = string.Join("", expressionStringList);
            expressionStrings.Add(expressionString);
            //now do math on the expressionString
            try
            {
                int result = SolverHelpers.EvaluateExpression(expressionString);

                if (result == targetNumber)
                {
                    goto foundTarget;
                    results.Add(expressionString, result);
                }
                Console.WriteLine(result);
                results.Add(expressionString, result);

            }
            catch
            {
                //Console.WriteLine("Error");
            }
        }
        Dictionary<string, int> closestExpressions = results
            .OrderBy(entry => Math.Abs(entry.Value - targetNumber))  // Sort by distance from targetNumber
            .ToDictionary(entry => entry.Key, entry => entry.Value);
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(closestExpressions.ElementAt(i));
        }
    foundTarget:;
        Console.WriteLine(results.Last());
    }

    public static void NewNumberRoundSolver()
    {
        //use a text file to source permutations of numbers and operators, then substitute in numbers

        //first take inputs using extra validation.
    }

}
internal class SolverHelpers
{
    static char[] operators = { '+', '-', '-', '/' };
    static char[] brackets = { '(', ')' };
    static char[] operatorsAndBrackets = { '+', '-', '*', '/', '(', ')' };

    public static List<List<int>> Permutations(int[] numbers)
    {
        List<List<int>> permutations = new List<List<int>>();
        //length = 6
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j)
                {
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            for (int l = 0; l < numbers.Length; l++)
                            {
                                if (l != i && l != j && l != k)
                                {
                                    for (int m = 0; m < numbers.Length; m++)
                                    {
                                        if (m != i && m != j && m != k && m != l)
                                        {
                                            for (int n = 0; n < numbers.Length; n++)
                                            {
                                                if (n != i && n != j && n != k && n != l && n != m)
                                                {
                                                    List<int> permutation = new List<int>();
                                                    permutation.Add(numbers[i]);
                                                    permutation.Add(numbers[j]);
                                                    permutation.Add(numbers[k]);
                                                    permutation.Add(numbers[l]);
                                                    permutation.Add(numbers[m]);
                                                    permutation.Add(numbers[n]);
                                                    permutations.Add(permutation);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //length = 5
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j)
                {
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            for (int l = 0; l < numbers.Length; l++)
                            {
                                if (l != i && l != j && l != k)
                                {
                                    for (int m = 0; m < numbers.Length; m++)
                                    {
                                        if (m != i && m != j && m != k && m != l)
                                        {
                                            List<int> permutation = new List<int>();
                                            permutation.Add(numbers[i]);
                                            permutation.Add(numbers[j]);
                                            permutation.Add(numbers[k]);
                                            permutation.Add(numbers[l]);
                                            permutation.Add(numbers[m]);
                                            permutations.Add(permutation);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //length = 4
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j)
                {
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            for (int l = 0; l < numbers.Length; l++)
                            {
                                if (l != i && l != j && l != k)
                                {
                                    List<int> permutation = new List<int>();
                                    permutation.Add(numbers[i]);
                                    permutation.Add(numbers[j]);
                                    permutation.Add(numbers[k]);
                                    permutation.Add(numbers[l]);
                                    permutations.Add(permutation);
                                }
                            }
                        }
                    }
                }
            }
        }
        //length = 3
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j)
                {
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            List<int> permutation = new List<int>();
                            permutation.Add(numbers[i]);
                            permutation.Add(numbers[j]);
                            permutation.Add(numbers[k]);
                            permutations.Add(permutation);
                        }
                    }
                }
            }
        }
        //length = 2
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j)
                {
                    List<int> permutation = new List<int>();
                    permutation.Add(numbers[i]);
                    permutation.Add(numbers[j]);
                    permutations.Add(permutation);
                }
            }
        }

        return permutations;
    }

    public static List<List<string>> OperatorPermutationsLength6Rewrite(List<string> expressionList)
    {

        //cannot have closed bracket if one is not open
        //closed brackets must have operators before and after
        //Logic rewrite required
        // +(, -(, *(, /(, )+ )- )* )/
        //These are only valid in certain positions
        List<List<string>> expressionLists = new List<List<string>>();
        for (int h = 0; h <= 1; h++)
        {
            int bracketOpen = 0;
            if (h == 1)
            {
                expressionList[0] = "_";
            }
            else
            {
                expressionList[0] = "(";
                bracketOpen++;
            }

            for (int i = 0; i < operatorsAndBrackets.Length; i++)
            {
                bracketOpen = IsBracket(bracketOpen, i);

                expressionList[2] = operatorsAndBrackets[i].ToString();
                for (int j = 0; j < operatorsAndBrackets.Length; j++)
                {
                    expressionList[4] = operatorsAndBrackets[j].ToString();
                    bracketOpen = IsBracket(bracketOpen, j);
                    for (int k = 0; k < operatorsAndBrackets.Length; k++)
                    {
                        expressionList[6] = operatorsAndBrackets[k].ToString();
                        bracketOpen = IsBracket(bracketOpen, k);
                        for (int l = 0; l < operatorsAndBrackets.Length; l++)
                        {
                            expressionList[8] = operatorsAndBrackets[l].ToString();
                            bracketOpen = IsBracket(bracketOpen, l);
                            for (int m = 0; m < operatorsAndBrackets.Length; m++)
                            {
                                expressionList[10] = operatorsAndBrackets[m].ToString();
                                bracketOpen = IsBracket(bracketOpen, m);
                                if (bracketOpen == 0)
                                {
                                    expressionList[12] = "_";
                                    expressionLists.Add(new List<string>(expressionList));
                                    string expressionListString = String.Join(" ", expressionList);
                                    Console.WriteLine(expressionListString);
                                }
                                else
                                {
                                    if (bracketOpen == 1)
                                    {
                                        expressionList[12] = ")";
                                        expressionLists.Add(new List<string>(expressionList));
                                        string expressionListString = String.Join(" ", expressionList);
                                        Console.WriteLine(expressionListString);
                                    }
                                }
                                bracketOpen = IsBracketUndo(bracketOpen, m);
                            }
                            bracketOpen = IsBracketUndo(bracketOpen, l);
                        }
                        bracketOpen = IsBracketUndo(bracketOpen, k);
                    }
                    bracketOpen = IsBracketUndo(bracketOpen, j);
                }
                bracketOpen = IsBracketUndo(bracketOpen, i);
            }
        }
        return expressionLists;

    }
    public static List<List<string>> OperatorPermutationsLength6(List<string> expressionList)
    {
        //cannot have closed bracket if one is not open
        //closed brackets must have operators before and after
        //Logic rewrite required
        // +(, -(, *(, /(, )+ )- )* )/
        //These are only valid in certain positions
        List<List<string>> expressionLists = new List<List<string>>();
        for (int h = 0; h <= 1; h++)
        {
            int bracketOpen = 0;
            if (h == 1)
            {
                expressionList[0] = "_";
            }
            else
            {
                expressionList[0] = "(";
                bracketOpen++;
            }

            for (int i = 0; i < operatorsAndBrackets.Length; i++)
            {
                bracketOpen = IsBracket(bracketOpen, i);

                expressionList[2] = operatorsAndBrackets[i].ToString();
                for (int j = 0; j < operatorsAndBrackets.Length; j++)
                {
                    expressionList[4] = operatorsAndBrackets[j].ToString();
                    bracketOpen = IsBracket(bracketOpen, j);
                    for (int k = 0; k < operatorsAndBrackets.Length; k++)
                    {
                        expressionList[6] = operatorsAndBrackets[k].ToString();
                        bracketOpen = IsBracket(bracketOpen, k);
                        for (int l = 0; l < operatorsAndBrackets.Length; l++)
                        {
                            expressionList[8] = operatorsAndBrackets[l].ToString();
                            bracketOpen = IsBracket(bracketOpen, l);
                            for (int m = 0; m < operatorsAndBrackets.Length; m++)
                            {
                                expressionList[10] = operatorsAndBrackets[m].ToString();
                                bracketOpen = IsBracket(bracketOpen, m);
                                if (bracketOpen == 0)
                                {
                                    expressionList[12] = "_";
                                    expressionLists.Add(new List<string>(expressionList));
                                    string expressionListString = String.Join(" ", expressionList);
                                    Console.WriteLine(expressionListString);
                                }
                                else
                                {
                                    if (bracketOpen == 1)
                                    {
                                        expressionList[12] = ")";
                                        expressionLists.Add(new List<string>(expressionList));
                                        string expressionListString = String.Join(" ", expressionList);
                                        Console.WriteLine(expressionListString);
                                    }
                                }
                                bracketOpen = IsBracketUndo(bracketOpen, m);
                            }
                            bracketOpen = IsBracketUndo(bracketOpen, l);
                        }
                        bracketOpen = IsBracketUndo(bracketOpen, k);
                    }
                    bracketOpen = IsBracketUndo(bracketOpen, j);
                }
                bracketOpen = IsBracketUndo(bracketOpen, i);
            }
        }
        return expressionLists;
    }

    public static List<List<string>> OperatorPermutationsLength5(List<string> expressionList)
    {
        List<List<string>> expressionLists = new List<List<string>>();
        int bracketOpen = 0;
        for (int h = 0; h <= 1; h++)
        {
            if (h == 1)
            {
                expressionList[0] = "_";
            }
            else
            {
                expressionList[0] = "(";
                bracketOpen++;
            }

            for (int i = 0; i < operatorsAndBrackets.Length; i++)
            {
                bracketOpen = IsBracket(bracketOpen, i);
                expressionList[2] = operatorsAndBrackets[i].ToString();
                for (int j = 0; j < operatorsAndBrackets.Length; j++)
                {
                    expressionList[4] = operatorsAndBrackets[j].ToString();
                    bracketOpen = IsBracket(bracketOpen, j);
                    for (int k = 0; k < operatorsAndBrackets.Length; k++)
                    {
                        expressionList[6] = operatorsAndBrackets[k].ToString();
                        bracketOpen = IsBracket(bracketOpen, k);
                        for (int l = 0; l < operatorsAndBrackets.Length; l++)
                        {
                            expressionList[8] = operatorsAndBrackets[l].ToString();
                            bracketOpen = IsBracket(bracketOpen, l);
                            if (bracketOpen > 0)
                            {
                                expressionList[10] = ")";
                                expressionLists.Add(new List<string>(expressionList));
                            }
                            else
                            {
                                expressionList[10] = "_";
                                expressionLists.Add(new List<string>(expressionList));
                            }
                            bracketOpen = IsBracketUndo(bracketOpen, l);
                        }
                        bracketOpen = IsBracketUndo(bracketOpen, k);
                    }
                    bracketOpen = IsBracketUndo(bracketOpen, j);
                }
                bracketOpen = IsBracketUndo(bracketOpen, i);
            }
        }
        return expressionLists;
    }

    public static List<List<string>> OperatorPermutationsLength4(List<string> expressionList)
    {
        List<List<string>> expressionLists = new List<List<string>>();
        int bracketOpen = 0;
        for (int h = 0; h <= 1; h++)
        {
            if (h == 1)
            {
                expressionList[0] = "_";
            }
            else
            {
                expressionList[0] = "(";
                bracketOpen++;
            }

            for (int i = 0; i < operatorsAndBrackets.Length; i++)
            {
                bracketOpen = IsBracket(bracketOpen, i);
                expressionList[2] = operatorsAndBrackets[i].ToString();
                for (int j = 0; j < operatorsAndBrackets.Length; j++)
                {
                    expressionList[4] = operatorsAndBrackets[j].ToString();
                    bracketOpen = IsBracket(bracketOpen, j);
                    for (int k = 0; k < operatorsAndBrackets.Length; k++)
                    {
                        expressionList[6] = operatorsAndBrackets[k].ToString();
                        bracketOpen = IsBracket(bracketOpen, k);
                        if (bracketOpen > 0)
                        {
                            expressionList[8] = ")";
                            expressionLists.Add(new List<string>(expressionList));
                        }
                        else
                        {
                            expressionList[8] = "_";
                            expressionLists.Add(new List<string>(expressionList));
                        }
                        bracketOpen = IsBracketUndo(bracketOpen, k);
                    }
                    bracketOpen = IsBracketUndo(bracketOpen, j);
                }
                bracketOpen = IsBracketUndo(bracketOpen, i);
            }
        }
        return expressionLists;
    }

    public static List<List<string>> OperatorPermutationsLength3(List<string> expressionList)
    {
        List<List<string>> expressionLists = new List<List<string>>();
        int bracketOpen = 0;
        for (int h = 0; h <= 1; h++)
        {
            if (h == 1)
            {
                expressionList[0] = "_";
            }
            else
            {
                expressionList[0] = "(";
                bracketOpen++;
            }

            for (int i = 0; i < operatorsAndBrackets.Length; i++)
            {
                bracketOpen = IsBracket(bracketOpen, i);
                expressionList[2] = operatorsAndBrackets[i].ToString();
                for (int j = 0; j < operatorsAndBrackets.Length; j++)
                {
                    expressionList[4] = operatorsAndBrackets[j].ToString();
                    bracketOpen = IsBracket(bracketOpen, j);
                    if (bracketOpen > 0)
                    {
                        expressionList[6] = ")";
                        expressionLists.Add(new List<string>(expressionList));
                    }
                    else
                    {
                        expressionList[6] = "_";
                        expressionLists.Add(new List<string>(expressionList));
                    }
                    bracketOpen = IsBracketUndo(bracketOpen, j);
                }
                bracketOpen = IsBracketUndo(bracketOpen, i);
            }
        }
        return expressionLists;
    }

    public static List<List<string>> OperatorPermutationsLength2(List<string> expressionList)
    {
        List<List<string>> expressionLists = new List<List<string>>();
        int bracketOpen = 0;
        for (int h = 0; h <= 1; h++)
        {
            if (h == 1)
            {
                expressionList[0] = "_";
            }
            else
            {
                expressionList[0] = "(";
                bracketOpen++;
            }

            for (int i = 0; i < operatorsAndBrackets.Length; i++)
            {
                bracketOpen = IsBracket(bracketOpen, i);
                if (bracketOpen > 0)
                {
                    expressionList[4] = ")";
                    expressionLists.Add(new List<string>(expressionList));
                }
                else
                {
                    expressionList[4] = "_";
                    expressionLists.Add(new List<string>(expressionList));
                }
                bracketOpen = IsBracketUndo(bracketOpen, i);
            }
        }
        return expressionLists;
    }

    public static int IsBracket(int bracketOpen, int counter)
    {
        if (operatorsAndBrackets[counter] == ')')
        {
            return bracketOpen - 1;
        }
        if (operatorsAndBrackets[counter] == '(')
        {
            return bracketOpen + 1;
        }
        return bracketOpen;
    }
    public static int IsBracketUndo(int bracketOpen, int counter)
    {
        if (operatorsAndBrackets[counter] == ')')
        {
            return bracketOpen + 1;
        }
        if (operatorsAndBrackets[counter] == '(')
        {
            return bracketOpen - 1;
        }
        return bracketOpen;
    }

    public static int EvaluateExpression(string expressionInput)
    {
        try
        {
            // Create a new Expression object from the input string
            var expression = new Expression(expressionInput);

            // Add custom functions for division and subtraction
            expression.EvaluateFunction += (name, args) =>
            {
                if (name.Equals("/") && args.Parameters.Count() == 2)
                {
                    try
                    {
                        // Convert to int and call custom method
                        args.Result = Operators.Divide(Convert.ToInt32(args.Parameters[0].Evaluate()), Convert.ToInt32(args.Parameters[1].Evaluate()));
                    }
                    catch
                    {
                        throw new Exception("Invalid expression");
                    }
                }
                else if (name.Equals("-") && args.Parameters.Count() == 2)
                {
                    try
                    {
                        // Convert to int and call custom method
                        args.Result = Operators.Subtract(Convert.ToInt32(args.Parameters[0].Evaluate()), Convert.ToInt32(args.Parameters[1].Evaluate()));
                    }
                    catch
                    {
                        throw new Exception("Invalid expression");
                    }
                }

            };

            // Evaluate the expression
            var result = expression.Evaluate();  // Evaluate the expression

            // Convert the result to int (assuming result is an integer)
            return Convert.ToInt32(result);
        }
        catch (Exception ex)
        {

            //Console.WriteLine("Invalid expression: " + ex.Message);
            throw new Exception("Invalid expression");
        }
    }

}

internal class Operators
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static int Subtract(int a, int b)
    {
        //can't produce negative numbers
        if (b > a)
        {
            return 999999;
        }
        return a - b;
    }
    public static int Multiply(int a, int b)
    {
        return a * b;
    }
    public static int Divide(int a, int b)
    {
        //can't divide by 0, and result has to be a whole number
        if (b == 0)
        {
            return 999999;
        }
        if (a % b != 0)
        {
            return 999999;
        }
        return a / b;
    }



}



internal class Maintainance
{
    public static void TextFileGenerator()
    {
        // Get the path to the current directory (where the executable is located)
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Path to the English Open Word List.txt file (relative to the current directory)
        string sourceTextFilePath = Path.Combine(currentDirectory, "EnglishOpenWordList.txt");



        List<string> listOfWords = File.ReadAllLines(sourceTextFilePath).ToList();
        HashSet<string> listOf9LetterWordsOrLess = RemoveWordsGreaterThan9Letters(listOfWords);
        listOf9LetterWordsOrLess.Add("Colour");
        string destinationTextFilePath9OrLess = Path.Combine(currentDirectory, "9LetterWordsOrLess.txt");
        File.WriteAllLines(destinationTextFilePath9OrLess, listOf9LetterWordsOrLess);
        string destinationTextFilePath9 = Path.Combine(currentDirectory, "9LetterWords.txt");
        string destinationTextFilePath8 = Path.Combine(currentDirectory, "8LetterWords.txt");
        string destinationTextFilePath7 = Path.Combine(currentDirectory, "7LetterWords.txt");
        string destinationTextFilePath6 = Path.Combine(currentDirectory, "6LetterWords.txt");
        string destinationTextFilePath5 = Path.Combine(currentDirectory, "5LetterWords.txt");
        string destinationTextFilePath4 = Path.Combine(currentDirectory, "4LetterWords.txt");
        string destinationTextFilePath3 = Path.Combine(currentDirectory, "3LetterWords.txt");
        string destinationTextFilePath2 = Path.Combine(currentDirectory, "2LetterWords.txt");
        string destinationTextFilePath1 = Path.Combine(currentDirectory, "1LetterWords.txt");


        List<string> listOf9LetterWords = new List<string>();
        List<string> listOf8LetterWords = new List<string>();
        List<string> listOf7LetterWords = new List<string>();
        List<string> listOf6LetterWords = new List<string>();
        List<string> listOf5LetterWords = new List<string>();
        List<string> listOf4LetterWords = new List<string>();
        List<string> listOf3LetterWords = new List<string>();
        List<string> listOf2LetterWords = new List<string>();
        List<string> listOf1LetterWords = new List<string>();

        foreach (string word in listOf9LetterWordsOrLess)
        {
            string sortedWord = new string(word.OrderBy(c => c).ToArray());
            switch (word.Length)
            {
                case 9:
                    listOf9LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 8:
                    listOf8LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 7:
                    listOf7LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 6:
                    listOf6LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 5:
                    listOf5LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 4:
                    listOf4LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 3:
                    listOf3LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 2:
                    listOf2LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 1:
                    listOf1LetterWords.Add($"{word} {sortedWord}");
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Strange???");
                    break;
            }


        }

        File.WriteAllLines(destinationTextFilePath9, listOf9LetterWords);
        File.WriteAllLines(destinationTextFilePath8, listOf8LetterWords);
        File.WriteAllLines(destinationTextFilePath7, listOf7LetterWords);
        File.WriteAllLines(destinationTextFilePath6, listOf6LetterWords);
        File.WriteAllLines(destinationTextFilePath5, listOf5LetterWords);
        File.WriteAllLines(destinationTextFilePath4, listOf4LetterWords);
        File.WriteAllLines(destinationTextFilePath3, listOf3LetterWords);
        File.WriteAllLines(destinationTextFilePath2, listOf2LetterWords);
        File.WriteAllLines(destinationTextFilePath1, listOf1LetterWords);
    }

    public static void NumberPermutationFileGenerator()
    {
        string[] numbersVariables = { "a", "b", "c", "d", "e", "f" };

        List<List<string>> permutations = new List<List<string>>();
        //length = 6
        for (int i = 0; i < numbersVariables.Length; i++)
        {
            for (int j = 0; j < numbersVariables.Length; j++)
            {
                if (i != j)
                {
                    for (int k = 0; k < numbersVariables.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            for (int l = 0; l < numbersVariables.Length; l++)
                            {
                                if (l != i && l != j && l != k)
                                {
                                    for (int m = 0; m < numbersVariables.Length; m++)
                                    {
                                        if (m != i && m != j && m != k && m != l)
                                        {
                                            for (int n = 0; n < numbersVariables.Length; n++)
                                            {
                                                if (n != i && n != j && n != k && n != l && n != m)
                                                {
                                                    List<string> permutation = new List<string>();
                                                    permutation.Add(numbersVariables[i]);
                                                    permutation.Add(numbersVariables[j]);
                                                    permutation.Add(numbersVariables[k]);
                                                    permutation.Add(numbersVariables[l]);
                                                    permutation.Add(numbersVariables[m]);
                                                    permutation.Add(numbersVariables[n]);
                                                    permutations.Add(permutation);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //length = 5
        for (int i = 0; i < numbersVariables.Length; i++)
        {
            for (int j = 0; j < numbersVariables.Length; j++)
            {
                if (i != j)
                {
                    for (int k = 0; k < numbersVariables.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            for (int l = 0; l < numbersVariables.Length; l++)
                            {
                                if (l != i && l != j && l != k)
                                {
                                    for (int m = 0; m < numbersVariables.Length; m++)
                                    {
                                        if (m != i && m != j && m != k && m != l)
                                        {
                                            List<string> permutation = new List<string>();
                                            permutation.Add(numbersVariables[i]);
                                            permutation.Add(numbersVariables[j]);
                                            permutation.Add(numbersVariables[k]);
                                            permutation.Add(numbersVariables[l]);
                                            permutation.Add(numbersVariables[m]);
                                            permutations.Add(permutation);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //length = 4
        for (int i = 0; i < numbersVariables.Length; i++)
        {
            for (int j = 0; j < numbersVariables.Length; j++)
            {
                if (i != j)
                {
                    for (int k = 0; k < numbersVariables.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            for (int l = 0; l < numbersVariables.Length; l++)
                            {
                                if (l != i && l != j && l != k)
                                {
                                    List<string> permutation = new List<string>();
                                    permutation.Add(numbersVariables[i]);
                                    permutation.Add(numbersVariables[j]);
                                    permutation.Add(numbersVariables[k]);
                                    permutation.Add(numbersVariables[l]);
                                    permutations.Add(permutation);
                                }
                            }
                        }
                    }
                }
            }
        }
        //length = 3
        for (int i = 0; i < numbersVariables.Length; i++)
        {
            for (int j = 0; j < numbersVariables.Length; j++)
            {
                if (i != j)
                {
                    for (int k = 0; k < numbersVariables.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            List<string> permutation = new List<string>();
                            permutation.Add(numbersVariables[i]);
                            permutation.Add(numbersVariables[j]);
                            permutation.Add(numbersVariables[k]);
                            permutations.Add(permutation);
                        }
                    }
                }
            }
        }
        //length = 2
        for (int i = 0; i < numbersVariables.Length; i++)
        {
            for (int j = 0; j < numbersVariables.Length; j++)
            {
                if (i != j)
                {
                    List<string> permutation = new List<string>();
                    permutation.Add(numbersVariables[i]);
                    permutation.Add(numbersVariables[j]);
                    permutations.Add(permutation);
                }
            }



        }
        //generate operator permutations and add to gaps
        HashSet<List<string>> expressionLists = new HashSet<List<string>>();
        foreach (List<string> permutation in permutations)
        {
            //there are 5 possible slots to place in operators 0-5
            //there are 7 possible slots to place brackets, however each must be a pair
            //( can be placed in gaps 0-6
            // ) can be placed in gaps 1-7
            // number of ( must equal number of )
            //a ) cannot be placed before any (
            //a ( cannot be placed after any )
            List<string> expressionList = new List<string>();
            foreach (string number in permutation)
            {
                expressionList.Add(",");
                expressionList.Add(number.ToString());

            }
            expressionList.Add(",");

            switch (permutation.Count)
            {
                case 6:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength6(expressionList));
                    break;
                case 5:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength5(expressionList));
                    break;
                case 4:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength4(expressionList));
                    break;
                case 3:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength3(expressionList));
                    break;
                case 2:
                    expressionLists.UnionWith(SolverHelpers.OperatorPermutationsLength2(expressionList));
                    break;
                default:
                    Console.WriteLine("Something wrong???");
                    break;
            }




        }




        //write to a file of permutations
        List<string> permutationsFlat = new List<string>();
        foreach (List<string> permutation in permutations)
        {
            string tempPermutation = "";
            foreach (string equationSegment in permutation)
            {
                tempPermutation = tempPermutation + equationSegment;
            }
            permutationsFlat.Add(tempPermutation);
        }
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string permutationsFilePath = Path.Combine(currentDirectory, "numbersRoundPermutations.txt");
        File.WriteAllLines(permutationsFilePath, permutationsFlat);
    }
    private static HashSet<string> RemoveWordsGreaterThan9Letters(List<string> listOfWords)
    {
        HashSet<string> words9LettersOrLess = new HashSet<string>();
        foreach (string word in listOfWords)
        {
            if (word.Length <= 9)
            {
                words9LettersOrLess.Add(word);
            }
        }

        return words9LettersOrLess;
    }
}