using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WordChain.Tests
{
    [TestClass()]
    public class CoreTests
    {
        readonly List<string> wordList1 = new List<string>()
        {
            "Element",
            "Heaven",
            "Table",
            "Teach",
            "Talk"
        };
        readonly List<string> wordChain1WithR = new List<string>()
        {
            "table",
            "element",
            "teach",
            "heaven"
        };
        readonly List<string> wordList2 = new List<string>()
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
        readonly List<string> wordChain2 = new List<string>()
        {
            "algebra",
            "apple",
            "elephant",
            "trick"
        };
        readonly List<string> wordChain2WithC = new List<string>()
        {
            "pseudopseudohypoparathyroidism",
            "moon"
        };
        readonly List<string> wordChain2WithH_e = new List<string>()
        {
            "elephant",
            "trick"
        };
        readonly List<string> wordChain2WithT_t = new List<string>()
        {
            "algebra",
            "apple",
            "elephant"
        };
        [TestMethod()]
        public unsafe void gen_chain_wordTest()
        {
            TestGenChain(wordList1, wordChain1WithR, enableLoop: true);
            TestGenChain(wordList2, wordChain2);
            TestGenChain(wordList2, wordChain2WithH_e, head: 'e');
            TestGenChain(wordList2, wordChain2WithT_t, tail: 't');
        }
        [TestMethod()]
        public void gen_chain_charTest()
        {
            TestGenChain(wordList2, wordChain2WithC, mode: 1);
        }
        private unsafe void TestGenChain(List<string> wordList, List<string> expectedChain, int mode = 0, char head = '\0', char tail = '\0', bool enableLoop = false)
        {
            char*[] resultArray = CreateStringArray(wordList.Count, 100);
            char*[] wordListArray = ConvertToArray(wordList);
            int len = 0;
            if (mode == 0)
            {
                len = Core.gen_chain_word(wordListArray, wordListArray.Length, resultArray, head, tail, enableLoop);
            }
            else if (mode == 1)
            {
                len = Core.gen_chain_char(wordListArray, wordListArray.Length, resultArray, head, tail, enableLoop);
            }
            else
            {
                Assert.Fail();
            }
            List<string> result = ConvertToList(resultArray, len);
            CollectionAssert.AreEqual(expectedChain, result);
        }
        private unsafe static char*[] CreateStringArray(int length = 100, int wordLength = 100)
        {
            char*[] array = new char*[length];
            for (int i = 0; i < length; i++)
            {
                char[] word = new char[wordLength];
                fixed (char* wordPointer = &word[0])
                {
                    array[i] = wordPointer;
                }
            }
            return array;
        }
        private static unsafe List<string> ConvertToList(char*[] words, int len)
        {
            List<string> wordList = new List<string>();
            for (int i = 0; i < len; i++)
            {
                wordList.Add(new string(words[i]));
            }
            return wordList;
        }
        private static unsafe char*[] ConvertToArray(List<string> words)
        {
            char*[] wordList = new char*[words.Count];
            for (int i = 0; i < words.Count; i++)
            {
                int j = 0;
                char[] word = new char[100];
                fixed (char* wordPointer = &word[0])
                {
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
    }
}