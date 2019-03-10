using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordChain
{
    public class Core
    {
        string inputFilePath = "";
        char head = '\0';
        char tail = '\0';
        bool enableLoop = false;
        bool wordMode = false;
        bool charMode = false;
        readonly string outputFilePath = "solution.txt";
        static void Main(string[] args)
        {
            Core core = new Core();
            if (args.Length > 0)
            {
                core.ParseCommandLineArguments(args);
            }
            List<string> chain = core.GenerateChain();
            core.OutputChain(chain);
        }
        private unsafe List<string> ConvertWordArrayToList(char*[] words, int len)
        {
            List<string> wordList = new List<string>();
            for (int i = 0; i < len; i++)
            {
                wordList.Add(new string(words[i]).ToLower());
            }
            return wordList;
        }
        private static unsafe int ConvertWordListToArray(List<string> wordList, char*[] words)
        {
            for (int i = 0; i < wordList.Count; i++)
            {
                char* wordPointer = words[i];
                for (int j = 0; j < wordList[i].Length; j++)
                {
                    *wordPointer++ = wordList[i][j];
                }
                *wordPointer = '\0';
            }
            return wordList.Count;
        }
        private static unsafe int GenerateChain(int mode, char*[] words, int len, char*[] result, char head, char tail, bool enable_loop)
        {
            Core core = new Core(head: head, tail: tail, enableLoop: enable_loop);
            List<string> wordList = core.ConvertWordArrayToList(words, len);
            List<string> resultWordList = core.FindLongestChain(wordList, mode);
            int resultLen = ConvertWordListToArray(resultWordList, result);
            return resultLen;
        }
        public static unsafe int gen_chain_word(char*[] words, int len, char*[] result, char head, char tail, bool enable_loop)
        {
            return GenerateChain(0, words, len, result, head, tail, enable_loop);
        }
        public static unsafe int gen_chain_char(char*[] words, int len, char*[] result, char head, char tail, bool enable_loop)
        {
            return GenerateChain(1, words, len, result, head, tail, enable_loop);
        }
        public List<string> GenerateChain()
        {
            string content = ReadContentFromFile();
            List<string> words = DivideWord(content);
            List<string> chain = new List<string>();
            words = words.Where((x, i) => words.FindIndex(y => y.Equals(x)) == i).ToList();
            if (wordMode)
            {
                chain = FindLongestChain(words, 0);
            }
            if (charMode)
            {
                chain = FindLongestChain(words, 1);
            }
            return chain;
        }
        public Core()
        {

        }
        public Core(string inputFilePath = "", int mode = 0, char head = '\0', char tail = '\0', bool enableLoop = false, string outputFilePath = @"solution.txt")
        {
            if (mode == 0)
            {
                wordMode = true;
            }
            else if (mode == 1)
            {
                charMode = true;
            }
            else
            {
                ExceptWithCause(new ModeNotProvidedException("Program Mode Not Provided"));
            }
            this.inputFilePath = inputFilePath;
            this.head = head;
            this.tail = tail;
            this.enableLoop = enableLoop;
            this.outputFilePath = outputFilePath;
        }
        public void ParseCommandLineArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Equals("-w"))
                {
                    if (args.Length <= i + 1)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -w Argument Requires a File's Absolute Path"));
                    }
                    else
                    {
                        if (wordMode == true)
                        {
                            ExceptWithCause(new ArgumentErrorException("The -w Argument Cannot be Used Twice"));
                        }
                        if (charMode == true)
                        {
                            ExceptWithCause(new ArgumentErrorException("The -w Argument Cannot be Used Together with the -c Argument"));
                        }
                        inputFilePath = args[++i];
                        wordMode = true;
                        continue;
                    }
                }
                if (args[i].Equals("-c"))
                {
                    if (args.Length <= i + 1)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -c Argument Requires a File's Absolute Path"));
                    }
                    else
                    {
                        if (charMode == true)
                        {
                            ExceptWithCause(new ArgumentErrorException("The -c Argument Cannot be Used Twice"));
                        }
                        if (wordMode == true)
                        {
                            ExceptWithCause(new ArgumentErrorException("The -c Argument Cannot be Used Together with the -w Argument"));
                        }
                        inputFilePath = args[++i];
                        charMode = true;
                        continue;
                    }
                }
                if (args[i].Equals("-h"))
                {
                    if (args.Length <= i + 1)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -h Argument Requires a Start Letter"));
                    }
                    else
                    {
                        if (head != '\0')
                        {
                            ExceptWithCause(new ArgumentErrorException("The -h Argument Cannot be Used Twice"));
                        }
                        string headString = args[++i];
                        if (headString.Length != 1 || !char.IsLetter(headString[0]))
                        {
                            ExceptWithCause(new ArgumentErrorException("The -h Argument Requires a Start Letter"));
                        }
                        head = headString[0];
                        continue;
                    }
                }
                if (args[i].Equals("-t"))
                {
                    if (args.Length <= i + 1)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -t Argument Requires an End Letter"));
                    }
                    else
                    {
                        if (tail != '\0')
                        {
                            ExceptWithCause(new ArgumentErrorException("The -t Argument Cannot be Used Twice"));
                        }
                        string tailString = args[++i];
                        if (tailString.Length != 1 || !char.IsLetter(tailString[0]))
                        {
                            ExceptWithCause(new ArgumentErrorException("The -t Argument Requires an End Letter"));
                        }
                        tail = tailString[0];
                        continue;
                    }
                }
                if (args[i].Equals("-r"))
                {
                    if (enableLoop)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -r Argument Cannot be Used Twice"));
                    }
                    enableLoop = true;
                    continue;
                }
                ExceptWithCause(new ArgumentErrorException("Invalid Argument: " + args[i]));
            }
        }
        private void ExceptWithCause(ProgramException exception)
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine("Please Re-run the Program and Try Again");
            //Console.ReadKey();
            //Environment.Exit(1);
            throw exception;
        }
        private string ReadContentFromFile()
        {
            return ReadContentFromFile(this.inputFilePath);
        }
        private string ReadContentFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                ExceptWithCause(new FileException("Input File " + filePath + " Not Found"));
            }
            string content = "";
            try
            {
                content = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                ExceptWithCause(new FileNotReadableException("Unable to Read From File " + filePath));
            }
            return content;
        }
        public unsafe int read_string_from_file(char* file_path, char* content)
        {
            string filePath = new string(file_path);
            string contentString = ReadContentFromFile(filePath);
            int i;
            for (i = 0; i < contentString.Length; i++)
            {
                content[i] = contentString[i];
            }
            content[i] = '\0';
            return contentString.Length;
        }
        public unsafe int divide_string_by_word(char* content, char*[] words)
        {
            StringBuilder sb = new StringBuilder();
            string contentString = new string(content);
            List<string> wordList = DivideWord(contentString);
            return ConvertWordListToArray(wordList, words);
        }
        private List<string> DivideWord(string content)
        {
            string[] words = System.Text.RegularExpressions.Regex.Split(content, @"[^a-zA-Z]+");
            List<string> wordList = new List<string>();
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    wordList.Add(word.ToLower());
                }
            }
            return wordList;
        }
        private List<string> FindLongestChain(List<string> words, int mode, char last = '\0', List<string> current = null)
        {
            if (current == null)
            {
                current = new List<string>();
            }
            if (words.Count == 0)
            {
                return current;
            }
            List<List<string>> candicates = new List<List<string>>();
            foreach (string word in words)
            {
                if (last == '\0' || word.StartsWith(last.ToString()))
                {
                    List<string> tempCurrent = current.GetRange(0, current.Count);
                    List<string> tempWords = words.GetRange(0, words.Count);
                    tempCurrent.Add(word);
                    tempWords.Remove(word);
                    candicates.Add(FindLongestChain(tempWords, mode, word[word.Length - 1], tempCurrent));
                }
            }
            List<string> max = null;
            int maxLength = 0;
            foreach (List<string> candicate in candicates)
            {
                if (candicate.Count < 2)
                {
                    continue;
                }
                int length = 0;
                bool valid = true;
                string firstWord = candicate[0];
                string lastWord = candicate[candicate.Count - 1];
                if (firstWord[0] == lastWord[lastWord.Length - 1] && !enableLoop)
                {
                    ExceptWithCause(new WordRingException("Word Ring Detected but There is no -r Flag"));
                }
                for (int i = 0; i < candicate.Count; i++)
                {
                    if (i == 0 && head != '\0')
                    {
                        if (candicate[i][0] != head)
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (i == candicate.Count - 1 && tail != '\0')
                    {
                        if (candicate[i][candicate[i].Length - 1] != tail)
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                if (valid)
                {
                    foreach (string word in candicate)
                    {
                        if (mode == 0)
                        {
                            length += 1;
                        }
                        else if (mode == 1)
                        {
                            length += word.Length;
                        }
                    }
                    if (length > maxLength)
                    {
                        maxLength = length;
                        max = candicate;
                    }
                }
            }
            return max ?? current;
        }
        public void OutputChain(List<string> chain)
        {
            string[] result = chain.ToArray();
            try
            {
                File.WriteAllLines(outputFilePath, chain);
            }
            catch (Exception e)
            {
                ExceptWithCause(new FileNotWritableException("Error Occured When Writing Result To File " + outputFilePath));
            }
        }
    }
}
