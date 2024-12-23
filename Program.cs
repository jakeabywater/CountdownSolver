﻿internal class Program
{
    private static void Main(string[] args)
    {
    TextFileGenerator();
    startAgain:;
        //    Console.WriteLine("Welcome to a Countdown Solver, enter W for Words Round, or N for Numbers Round.");
        //checkWhichRoundAgain:;
        //    string gameType = Console.ReadLine();
        //    gameType = gameType.ToUpper();
        //    bool gameChosen = false;
        //    if (gameType == "W")
        //    {
        //        gameChosen = true;
        //        WordRoundSolver();
        //    }
        //    if (gameType == "N")
        //    {
        //        gameChosen = true;
        //        NumberRoundSolver();
        //    }
        //    else
        //    {
        //        if (!gameChosen)
        //        {
        //            Console.WriteLine("Invalid input, please enter W for the Words Round, or N for the Numbers Round.");
        //            goto checkWhichRoundAgain;
        //        }
        //    }
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("** Countdown Solver v1.0");
        Console.WriteLine("** By jakeabywater");
        Console.WriteLine("** https://github.com/jakeabywater/CountdownSolver");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("** Welcome to the Countdown Word Round Solver");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("");
        WordRoundSolver();
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Would you like to use the solver again? (Y/N)");
    invalidYN:;
        string input = Console.ReadLine();
        if (input.Length != 1)
        {
            Console.WriteLine("Please enter either Y or N.");
            goto invalidYN;
        }
        if (input.ToUpper() == "Y")
        {
            Console.Clear();
            goto startAgain;
        }
        else
        {
            if (input.ToUpper() == "N")
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------"); 
                Console.WriteLine("Thanks for using the solver!");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------"); 
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please enter either Y or N.");
                goto invalidYN;
            }
        }
    }
    private static void WordRoundSolver()
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
        

        Thread backgroundThread = new Thread(() =>
        {
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
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));
            Dictionary<string, string> dictionaryOf8LetterWords = File.ReadAllLines(destinationTextFilePath8)
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));
            Dictionary<string, string> dictionaryOf7LetterWords = File.ReadAllLines(destinationTextFilePath7)
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));
            Dictionary<string, string> dictionaryOf6LetterWords = File.ReadAllLines(destinationTextFilePath6)
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));
            Dictionary<string, string> dictionaryOf5LetterWords = File.ReadAllLines(destinationTextFilePath5)
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));
            Dictionary<string, string> dictionaryOf4LetterWords = File.ReadAllLines(destinationTextFilePath4)
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));
            Dictionary<string, string> dictionaryOf3LetterWords = File.ReadAllLines(destinationTextFilePath3)
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));
            Dictionary<string, string> dictionaryOf2LetterWords = File.ReadAllLines(destinationTextFilePath2)
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));
            Dictionary<string, string> dictionaryOf1LetterWords = File.ReadAllLines(destinationTextFilePath1)
                .ToDictionary(word => word, word => new string(word.OrderBy(c => c).ToArray()));

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
        });

        backgroundThread.Start();
        DisplayThinkingWithDots(backgroundThread);
        backgroundThread.Join();
    }

    private static void NumberRoundSolver()
    {
        char[] operators = { '+', '-', '-', '/' };
        Console.WriteLine("Enter 6 numbers, separated by commas;");
        string numbers = Console.ReadLine();
        Console.WriteLine("Enter the target number");
        int targetNumber = Convert.ToInt32(Console.ReadLine());

        Thread backgroundThread = new Thread(BackgroundTask);
        backgroundThread.Start();
        DisplayThinkingWithDots(backgroundThread);

        int[] numbersArray = Array.ConvertAll(numbers.Split(','), int.Parse);
        List<int> results = new List<int>();
    //create every permutation of the numbers of every possible length and order
    tryNextPermutation:;
        try
        {
            Divide(4, 6);
        }
        catch (ArithmeticException)
        {
            goto tryNextPermutation;
        }
    }

    private static int Divide(int a, int b)
    {
        //can't divide by 0, and result has to be a whole number
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        if (a % b != 0)
        {
            throw new ArithmeticException();
        }
        return a / b;
    }

    private static int Subtract(int a, int b)
    {
        //can't produce negative numbers
        if (b > a)
        {
            throw new ArithmeticException();
        }
        return a - b;
    }

    private static void TextFileGenerator()
    {
        // Get the path to the current directory (where the executable is located)
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Path to the words_alpha.txt file (relative to the current directory)
        string sourceTextFilePath = Path.Combine(currentDirectory, "words_alpha.txt");



        List<string> listOfWords = File.ReadAllLines(sourceTextFilePath).ToList();
        List<string> listOf9LetterWordsOrLess = RemoveWordsGreaterThan9Letters(listOfWords);
        listOf9LetterWordsOrLess.Add("Colour");
        string destinationTextFilePath = Path.Combine(currentDirectory, "9LetterWordsOrLess.txt");
        File.WriteAllLines(destinationTextFilePath, listOf9LetterWordsOrLess);
        string destinationTextFilePath9 = Path.Combine(currentDirectory, "9LetterWords.txt");
        string destinationTextFilePath8 = Path.Combine(currentDirectory, "8LetterWords.txt");
        string destinationTextFilePath7 = Path.Combine(currentDirectory, "7LetterWords.txt");
        string destinationTextFilePath6 = Path.Combine(currentDirectory, "6LetterWords.txt");
        string destinationTextFilePath5 = Path.Combine(currentDirectory, "5LetterWords.txt");
        string destinationTextFilePath4 = Path.Combine(currentDirectory, "4LetterWords.txt");
        string destinationTextFilePath3 = Path.Combine(currentDirectory, "3LetterWords.txt");
        string destinationTextFilePath2 = Path.Combine(currentDirectory, "2LetterWords.txt");
        string destinationTextFilePath1 = Path.Combine(currentDirectory, "1LetterWords.txt");


        List<string> listOf9LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 9)
            .ToList();
        List<string> listOf8LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 8)
            .ToList();
        List<string> listOf7LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 7)
            .ToList();
        List<string> listOf6LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 6)
            .ToList();
        List<string> listOf5LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 5)
            .ToList();
        List<string> listOf4LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 4)
            .ToList();
        List<string> listOf3LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 3)
            .ToList();
        List<string> listOf2LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 2)
            .ToList();
        List<string> listOf1LetterWords = File.ReadAllLines(destinationTextFilePath)
            .Where(word => word.Length == 1)
            .ToList();
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

    private static List<string> RemoveWordsGreaterThan9Letters(List<string> listOfWords)
    {
        List<string> words9LettersOrLess = new List<string>();
        foreach (string word in listOfWords)
        {
            if (word.Length <= 9)
            {
                words9LettersOrLess.Add(word);
            }
        }

        return words9LettersOrLess;
    }
    static void BackgroundTask()
    {
        // Simulate a task running
        Console.WriteLine("Background task started...");

        Console.WriteLine("Background task completed.");
    }

    static void DisplayThinkingWithDots(Thread taskThread)
    {
        string[] dotStates = { ".", "..", "..." };
        int iteration = 0;

        while (taskThread.IsAlive) // While the background thread is still running
        {
            Console.Clear();
            Console.Write("Thinking");
            Console.Write(dotStates[iteration % dotStates.Length]); // Cycle through the dots
            iteration++;
            Thread.Sleep(500); // Update animation every 500ms
        }

    }
}