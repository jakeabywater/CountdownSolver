internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to a Countdown Solver, enter W for words round, or N for numbers round.");
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
