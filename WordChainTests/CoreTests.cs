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
            TestWrongArgs("-w input.txt -h 9");
            TestWrongArgs("-w input.txt -t 0");
            TestWrongArgs("-c input.txt -h 7 -t 1");
            TestWrongArgs("-w input.txt -h 123");
            TestWrongArgs("-c input.txt -t 321");
            TestWrongArgs("-h a");
            TestWrongArgs("-w input.txt -w input.txt");
            TestWrongArgs("-w input.txt -c input.txt");
            TestWrongArgs("-c input.txt -c input.txt");
            TestWrongArgs("-c input.txt -w input.txt");
            TestWrongArgs("-w input.txt -h a -h c");
            TestWrongArgs("-w input.txt -t a -t c");
            TestWrongArgs("-w input.txt -r -r");
            TestCorrectArgs("-w input.txt -r");
        }
        private static void TestWrongArgs(string arguments)
        {
            var args = System.Text.RegularExpressions.Regex.Split(arguments, @"\s+");
            try
            {
                var core = new Core(args);
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
        }
        private static void TestCorrectArgs(string arguments)
        {
            var args = System.Text.RegularExpressions.Regex.Split(arguments, @"\s+");
            try
            {
                var core = new Core(args);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GenerateChainTest()
        {
            Core core = null;
            var args = new[]
            {
                "-w",
                "not_exist.txt"
            };
            try
            {
                core = new Core(args);
            }
            catch (ProgramException)
            {
                Assert.Fail();
            }
            try
            {
                core.GenerateChain();
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
            core = new Core("input.txt", 1, enableLoop: true, inputIsFile: true);
            var result = core.GenerateChain(true);
            CollectionAssert.AreEqual(result, _wordChain2WithC);
            core = new Core("input.txt", 1, head: '9', inputIsFile: true);
            try
            {
                result = core.GenerateChain();
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
            core = new Core("input.txt", mode: 0, tail: '0');
            try
            {
                result = core.GenerateChain();
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
            core = new Core("input.txt", mode: 0, head: '0', tail: '0');
            try
            {
                result = core.GenerateChain();
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
            core = new Core("inputr.txt", mode: 0);
            try
            {
                result = core.GenerateChain();
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
            core = new Core("input1.txt");
            try
            {
                result = core.GenerateChain();
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
            core = new Core("abc cde", outputFilePath: @"K:\test\solution.txt", inputIsFile: false);
            try
            {
                result = core.GenerateChain(true);
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
            try
            {
                core = new Core("abc cde", mode: 233, outputFilePath: @"K:\test\solution.txt", inputIsFile: false);
                Assert.Fail();
            }
            catch (ProgramException)
            {

            }
        }
    }
}