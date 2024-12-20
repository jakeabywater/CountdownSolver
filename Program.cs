internal class Program
{
    private static void Main(string[] args)
    {
        TextFileGenerator();
        Console.WriteLine("Welcome to a Countdown Solver, enter W for words round, or N for numbers round.");
        string gameType = Console.ReadLine();
        gameType = gameType.ToUpper();
        bool gameChosen = false;
        if (gameType == "W")
        {
            gameChosen = true;
            WordRoundSolver();
        }
        if (gameType == "N")
        {
            gameChosen = true;
            NumberRoundSolver();
        }
        else
        {
            if (!gameChosen)
                Console.WriteLine("Invalid input, please enter W or N.");
            Environment.Exit(-1);
        }
    }
    private static void WordRoundSolver()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string destinationTextFilePath = Path.Combine(currentDirectory, "words9LettersOrLess.txt");
        Dictionary<string, int> dictionaryOf9LetterWords = File.ReadAllLines(destinationTextFilePath).ToDictionary(word => word, word => word.Length);
        // take an input of 9 comma seperated characters with error handling
        Console.WriteLine("Please enter 9 characters, hitting enter after each character:");
        List<char> characters = new List<char>();
        for (int i = 0; i < 9; i++)
        {
            string input = Console.ReadLine().ToLower();
            if (input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Invalid input, please enter a single letter.");
                Environment.Exit(-1);
            }
            characters.Add(input[0]);
        }
        Dictionary<string, int> resultDictionary = new Dictionary<string, int>();


        Console.WriteLine(resultDictionary);
    }
    private static void NumberRoundSolver()
    {

    }


    private static void TextFileGenerator()
    {
        // Get the path to the current directory (where the executable is located)
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Path to the words_alpha.txt file (relative to the current directory)
        string sourceTextFilePath = Path.Combine(currentDirectory, "words_alpha.txt");

        // Path to the words9LettersOrLess.txt file (relative to the current directory)
        string destinationTextFilePath = Path.Combine(currentDirectory, "words9LettersOrLess.txt");

        List<string> listOfWords = File.ReadAllLines(sourceTextFilePath).ToList();
        List<string> listOf9LetterWords = RemoveWordsGreaterThan9Letters(listOfWords);
        listOf9LetterWords.Add("Colour");
        File.WriteAllLines(destinationTextFilePath, listOf9LetterWords);
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
}
