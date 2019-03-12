using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChain;

namespace WordChainTests
{
    [TestClass()]
    public class CoreTests
    {
        private readonly List<string> _wordList1 = new List<string>()
        {
            "Element",
            "Heaven",
            "Table",
            "Teach",
            "Talk"
        };

        private readonly List<string> _wordChain1WithR = new List<string>()
        {
            "table",
            "element",
            "teach",
            "heaven"
        };

        private readonly List<string> _wordList2 = new List<string>()
        {
            "Algebra",
            "Apple",
            "Zoo",
            "Elephant",
            "Under",
            "Fox",
            "Dog",
            "Moon",
            "Leaf",
            "Trick",
            "Pseudopseudohypoparathyroidism"
        };

        private readonly List<string> _wordChain2 = new List<string>()
        {
            "algebra",
            "apple",
            "elephant",
            "trick"
        };

        private readonly List<string> _wordChain2WithC = new List<string>()
        {
            "pseudopseudohypoparathyroidism",
            "moon"
        };

        private readonly List<string> _wordChain2WithHe = new List<string>()
        {
            "elephant",
            "trick"
        };

        private readonly List<string> _wordChain2WithTt = new List<string>()
        {
            "algebra",
            "apple",
            "elephant"
        };
        [TestMethod()]
        public unsafe void gen_chain_wordTest()
        {
            TestGenChain(_wordList1, _wordChain1WithR, enableLoop: true);
            TestGenChain(_wordList2, _wordChain2);
            TestGenChain(_wordList2, _wordChain2WithHe, head: 'e');
            TestGenChain(_wordList2, _wordChain2WithTt, tail: 't');
        }
        [TestMethod()]
        public void gen_chain_charTest()
        {
            TestGenChain(_wordList2, _wordChain2WithC, mode: 1);
        }
        private unsafe void TestGenChain(List<string> wordList, List<string> expectedChain, int mode = 0, char head = '\0', char tail = '\0', bool enableLoop = false)
        {
            var resultArray = CreateStringArray(wordList.Count, 100);
            var wordListArray = ConvertToArray(wordList);
            var len = 0;
            switch (mode)
            {
                case 0:
                    len = Core.gen_chain_word(wordListArray, wordListArray.Length, resultArray, head, tail, enableLoop);
                    break;
                case 1:
                    len = Core.gen_chain_char(wordListArray, wordListArray.Length, resultArray, head, tail, enableLoop);
                    break;
                default:
                    Assert.Fail();
                    break;
            }
            var result = ConvertToList(resultArray, len);
            CollectionAssert.AreEqual(expectedChain, result);
        }
        private static unsafe char*[] CreateStringArray(int length = 100, int wordLength = 100)
        {
            var array = new char*[length];
            for (var i = 0; i < length; i++)
            {
                var word = new char[wordLength];
                fixed (char* wordPointer = &word[0])
                {
                    array[i] = wordPointer;
                }
            }
            return array;
        }
        private static unsafe List<string> ConvertToList(char*[] words, int len)
        {
            var wordList = new List<string>();
            for (var i = 0; i < len; i++)
            {
                wordList.Add(new string(words[i]));
            }
            return wordList;
        }
        private static unsafe char*[] ConvertToArray(IReadOnlyList<string> words)
        {
            var wordList = new char*[words.Count];
            for (var i = 0; i < words.Count; i++)
            {
                var word = new char[100];
                fixed (char* wordPointer = &word[0])
                {
                    int j;
                    for (j = 0; j < words[i].Length; j++)
                    {
                        word[j] = words[i][j];
                    }
                    word[j] = '\0';
                    wordList[i] = wordPointer;
                }
            }
            return wordList;
        }

        [TestMethod()]
        public void ParseCommandLineArgumentsTest()
        {
            TestWrongArgs("-w");
            TestWrongArgs("-c");
            TestWrongArgs("-h");
            TestWrongArgs("-t");
            TestWrongArgs("-");
            TestWrongArgs("-h 1");
            TestWrongArgs("-t 233");
            TestCorrectArgs("-w input.txt");
            TestCorrectArgs("-c input.txt");
            TestCorrectArgs("-w input.txt -h a");
            TestCorrectArgs("-w input.txt -t b");
            TestWrongArgs("abcdefg");
        }
        private void TestWrongArgs(string arguments)
        {
            var args = System.Text.RegularExpressions.Regex.Split(arguments, @"\s+");
            var core = new Core();
            try
            {
                core.ParseCommandLineArguments(args);
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
        }
        private static void TestCorrectArgs(string arguments)
        {
            var args = System.Text.RegularExpressions.Regex.Split(arguments, @"\s+");
            var core = new Core();
            try
            {
                core.ParseCommandLineArguments(args);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GenerateChainTest()
        {
            var core = new Core();
            var args = new string[]
            {
                "-w",
                "not_exist.txt"
            };
            try
            {
                core.ParseCommandLineArguments(args);
            }catch(ProgramException)
            {
                Assert.Fail();
            }
            try
            {
                core.GenerateChain();
                Assert.Fail();
            }catch(ProgramException)
            {

            }
        }
    }
}