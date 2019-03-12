using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordChain
{
    public class Core
    {
        private string _input = "";
        private readonly bool _inputIsFile = true;
        private char _head = '\0';
        private char _tail = '\0';
        private bool _enableLoop;
        private bool _wordMode;
        private bool _charMode;
        private readonly string _outputFilePath = "solution.txt";
        private static void Main(string[] args)
        {
            var core = new Core(args);
            core.GenerateChain(true);
        }
        private static unsafe List<string> ConvertWordArrayToList(char*[] words, int len)
        {
            var wordList = new List<string>();
            for (var i = 0; i < len; i++)
            {
                wordList.Add(new string(words[i]).ToLower());
            }
            return wordList;
        }
        private static unsafe int ConvertWordListToArray(IReadOnlyList<string> wordList, char*[] words)
        {
            for (var i = 0; i < wordList.Count; i++)
            {
                var wordPointer = words[i];
                for (var j = 0; j < wordList[i].Length; j++)
                {
                    *wordPointer++ = wordList[i][j];
                }
                *wordPointer = '\0';
            }
            return wordList.Count;
        }
        private static unsafe int GenerateChain(int mode, char*[] words, int len, char*[] result, char head, char tail, bool enable_loop)
        {
            CheckValid(head, tail);
            var core = new Core(head: head, tail: tail, enableLoop: enable_loop);
            var wordList = ConvertWordArrayToList(words, len);
            var resultWordList = core.FindLongestChain(wordList, mode);
            var resultLen = ConvertWordListToArray(resultWordList, result);
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

        private static void CheckValid(char head, char tail)
        {
            if (head != '\0' && !char.IsLetter(head) || tail != '\0' && !char.IsLetter(tail))
            {
                ExceptWithCause(new ArgumentErrorException("The -h and -t Argument Must be Followed by an English Letter"));
            }
        }
        public List<string> GenerateChain(bool outputToFile = false)
        {
            CheckValid(_head, _tail);
            var content = _inputIsFile ? ReadContentFromFile() : _input;
            var words = DivideWord(content);
            var chain = new List<string>();
            words = words.Where((x, i) => words.FindIndex(y => y.Equals(x)) == i).ToList();
            if (_wordMode)
            {
                chain = FindLongestChain(words, 0);
            }
            if (_charMode)
            {
                chain = FindLongestChain(words, 1);
            }
            if (outputToFile)
            {
                OutputChain(chain);
            }
            return chain;
        }
        public Core(IReadOnlyList<string> args)
        {
            ParseCommandLineArguments(args);
        }
        public Core(string input = "", int mode = 0, char head = '\0', char tail = '\0', bool enableLoop = false, string outputFilePath = @"solution.txt", bool inputIsFile = true)
        {
            switch (mode)
            {
                case 0:
                    _wordMode = true;
                    break;
                case 1:
                    _charMode = true;
                    break;
                default:
                    ExceptWithCause(new ModeNotProvidedException("Program Mode Not Provided"));
                    break;
            }
            _input = input;
            _inputIsFile = inputIsFile;
            _head = head;
            _tail = tail;
            _enableLoop = enableLoop;
            _outputFilePath = outputFilePath;
        }
        private void ParseCommandLineArguments(IReadOnlyList<string> args)
        {
            for (var i = 0; i < args.Count; i++)
            {
                if (args[i].Equals("-w"))
                {
                    if (args.Count <= i + 1)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -w Argument Requires a File's Absolute Path"));
                    }
                    else
                    {
                        if (_wordMode)
                        {
                            ExceptWithCause(new ArgumentErrorException("The -w Argument Cannot be Used Twice"));
                        }
                        if (_charMode)
                        {
                            ExceptWithCause(new ArgumentErrorException("The -w Argument Cannot be Used Together with the -c Argument"));
                        }
                        _input = args[++i];
                        _wordMode = true;
                        continue;
                    }
                }
                if (args[i].Equals("-c"))
                {
                    if (args.Count <= i + 1)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -c Argument Requires a File's Absolute Path"));
                    }
                    else
                    {
                        if (_charMode)
                        {
                            ExceptWithCause(new ArgumentErrorException("The -c Argument Cannot be Used Twice"));
                        }
                        if (_wordMode)
                        {
                            ExceptWithCause(new ArgumentErrorException("The -c Argument Cannot be Used Together with the -w Argument"));
                        }
                        _input = args[++i];
                        _charMode = true;
                        continue;
                    }
                }
                if (args[i].Equals("-h"))
                {
                    if (args.Count <= i + 1)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -h Argument Requires a Start Letter"));
                    }
                    else
                    {
                        if (_head != '\0')
                        {
                            ExceptWithCause(new ArgumentErrorException("The -h Argument Cannot be Used Twice"));
                        }
                        var headString = args[++i];
                        if (headString.Length != 1 || !char.IsLetter(headString[0]))
                        {
                            ExceptWithCause(new ArgumentErrorException("The -h Argument Requires a Start Letter"));
                        }
                        _head = headString.ToLower()[0];
                        continue;
                    }
                }
                if (args[i].Equals("-t"))
                {
                    if (args.Count <= i + 1)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -t Argument Requires an End Letter"));
                    }
                    else
                    {
                        if (_tail != '\0')
                        {
                            ExceptWithCause(new ArgumentErrorException("The -t Argument Cannot be Used Twice"));
                        }
                        var tailString = args[++i];
                        if (tailString.Length != 1 || !char.IsLetter(tailString[0]))
                        {
                            ExceptWithCause(new ArgumentErrorException("The -t Argument Requires an End Letter"));
                        }
                        _tail = tailString.ToLower()[0];
                        continue;
                    }
                }
                if (args[i].Equals("-r"))
                {
                    if (_enableLoop)
                    {
                        ExceptWithCause(new ArgumentErrorException("The -r Argument Cannot be Used Twice"));
                    }
                    _enableLoop = true;
                    continue;
                }
                ExceptWithCause(new ArgumentErrorException("Invalid Argument: " + args[i]));
            }

            if (!_wordMode && !_charMode)
            {
                ExceptWithCause(new ModeNotProvidedException("No Mode are Provided in the Arguments"));
            }
        }
        private static void ExceptWithCause(ProgramException exception)
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine("Please Re-run the Program and Try Again");
            //Console.ReadKey();
            //Environment.Exit(1);
            throw exception;
        }
        private string ReadContentFromFile()
        {
            return ReadContentFromFile(_input);
        }
        private static string ReadContentFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                ExceptWithCause(new InputFileException("Input File " + filePath + " Not Found"));
            }
            var content = "";
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
        private static List<string> DivideWord(string content)
        {
            var words = System.Text.RegularExpressions.Regex.Split(content, @"[^a-zA-Z]+");
            return (from word in words where word.Length > 0 select word.ToLower()).ToList();
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
            var candidates = new List<List<string>>();
            foreach (var word in words)
            {
                if (last != '\0' && !word.StartsWith(last.ToString())) continue;
                var tempCurrent = current.GetRange(0, current.Count);
                var tempWords = words.GetRange(0, words.Count);
                tempCurrent.Add(word);
                tempWords.Remove(word);
                candidates.Add(FindLongestChain(tempWords, mode, word[word.Length - 1], tempCurrent));
            }
            List<string> max = null;
            var maxLength = 0;
            foreach (var candidate in candidates)
            {
                if (candidate.Count < 2)
                {
                    continue;
                }
                var length = 0;
                var valid = true;
                var firstWord = candidate[0];
                var lastWord = candidate[candidate.Count - 1];
                if (firstWord[0] == lastWord[lastWord.Length - 1] && !_enableLoop)
                {
                    ExceptWithCause(new WordRingException("Word Ring Detected but There is no -r Flag"));
                }
                for (var i = 0; i < candidate.Count; i++)
                {
                    if (i == 0 && _head != '\0')
                    {
                        if (candidate[i][0] != _head)
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (i != candidate.Count - 1 || _tail == '\0') continue;
                    if (candidate[i][candidate[i].Length - 1] == _tail) continue;
                    valid = false;
                    break;
                }

                if (!valid) continue;
                foreach (var word in candidate)
                {
                    length += mode == 0 ? 1 : mode == 1 ? word.Length : 0;
                }

                if (length <= maxLength) continue;
                maxLength = length;
                max = candidate;
            }
            return max ?? current;
        }
        private void OutputChain(IEnumerable<string> chain)
        {
            try
            {
                File.WriteAllLines(_outputFilePath, chain);
            }
            catch (Exception)
            {
                ExceptWithCause(new FileNotWritableException("Error Occured When Writing Result To File " + _outputFilePath));
            }
        }
    }
}
