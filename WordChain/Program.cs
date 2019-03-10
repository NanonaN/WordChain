using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        private static unsafe int GenerateChain(int mode, char*[] words, int len, char*[] result, char head, char tail, bool enable_loop)
        {
            Core core = new Core(head: head, tail: tail, enableLoop: enable_loop);
            List<string> wordList = core.ConvertWordArrayToList(words, len);
            List<string> resultWordList = core.FindLongestChain(wordList, mode);
            for (int i = 0; i < resultWordList.Count; i++)
            {
                char* resultPointer = result[i];
                for (int j = 0; j < resultWordList[i].Length; j++)
                {
                    *resultPointer++ = resultWordList[i][j];
                }
                *resultPointer = '\0';
            }
            return resultWordList.Count;
        }
        public static unsafe int gen_chain_word(char*[] words, int len, char*[] result, char head, char tail, bool enable_loop)
        {
            return GenerateChain(0, words, len, result, head, tail, enable_loop);
        }
        public static unsafe int gen_chain_char(char*[] words, int len, char*[] result, char head, char tail, bool enable_loop)
        {
            return GenerateChain(1, words, len, result, head, tail, enable_loop);
        }
        private List<string> GenerateChain()
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
                ExitWithCause("program mode not provided");
            }
            this.inputFilePath = inputFilePath;
            this.head = head;
            this.tail = tail;
            this.enableLoop = enableLoop;
            this.outputFilePath = outputFilePath;
        }
        private void ParseCommandLineArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Equals("-w"))
                {
                    if (args.Length <= i + 1)
                    {
                        ExitWithCause("-w argument requires a file absolute path");
                    }
                    else
                    {
                        if (wordMode == true)
                        {
                            ExitWithCause("-w argument cannot be used twice");
                        }
                        if (charMode == true)
                        {
                            ExitWithCause("-w argument cannot be used together with -c argument");
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
                        ExitWithCause("-c argument requires a file absolute path");
                    }
                    else
                    {
                        if (charMode == true)
                        {
                            ExitWithCause("-c argument cannot be used twice");
                        }
                        if (wordMode == true)
                        {
                            ExitWithCause("-c argument cannot be used together with -w argument");
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
                        ExitWithCause("-h argument requires a start letter");
                    }
                    else
                    {
                        if (head != '\0')
                        {
                            ExitWithCause("-h argument cannot be used twice");
                        }
                        string headString = args[++i];
                        if (headString.Length != 1 || !char.IsLetter(headString[0]))
                        {
                            ExitWithCause("-h argument requires a start letter");
                        }
                        head = headString[0];
                        continue;
                    }
                }
                if (args[i].Equals("-t"))
                {
                    if (args.Length <= i + 1)
                    {
                        ExitWithCause("-t argument requires an end letter");
                    }
                    else
                    {
                        if (tail != '\0')
                        {
                            ExitWithCause("-t argument cannot be used twice");
                        }
                        string tailString = args[++i];
                        if (tailString.Length != 1 || !char.IsLetter(tailString[0]))
                        {
                            ExitWithCause("-t argument requires an end letter");
                        }
                        tail = tailString[0];
                        continue;
                    }
                }
                if (args[i].Equals("-r"))
                {
                    if (enableLoop)
                    {
                        ExitWithCause("-r argument cannot be used twice");
                    }
                    enableLoop = true;
                    continue;
                }
                ExitWithCause("invalid argument" + args[i]);
            }
        }
        private void ExitWithCause(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("please re-run the program and try again");
            Console.ReadKey();
            Environment.Exit(1);
        }
        private string ReadContentFromFile()
        {
            if (!File.Exists(inputFilePath))
            {
                ExitWithCause("file " + inputFilePath + " not found");
            }
            string content = "";
            try
            {
                content = File.ReadAllText(inputFilePath);
            }
            catch (Exception)
            {
                ExitWithCause("unable to read from file " + inputFilePath);
            }
            return content;
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
                    ExitWithCause("word ring detected but there is no -r flag");
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
        private void OutputChain(List<string> chain)
        {
            string[] result = chain.ToArray();
            try
            {
                File.WriteAllLines(outputFilePath, chain);
            }
            catch (Exception e)
            {
                ExitWithCause("Error Occured When Writing Result To File");
            }
        }
    }
}
