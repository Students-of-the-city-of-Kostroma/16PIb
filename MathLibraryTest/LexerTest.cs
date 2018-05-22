using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLexer;

namespace MathLibraryTest
{
    [TestClass]
    public class LexerTest
    {
        void CheckTokens(IEnumerable<Token> t, params string[] p)
        {
            List<Token> tokens = new List<Token>(t);
            Assert.AreEqual(p.Length, 2*tokens.Count, "Неправильное число токенов");
            for (int i = 0; i < tokens.Count; i++)
            {
                Assert.AreEqual(p[2*i], tokens[i].Type);
                Assert.AreEqual(p[2*i+1], tokens[i].Value);                
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("15"),
                "(literal)", "15"
                );
        }
        [TestMethod]
        public void TestMethod2()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("20*(-1)"),
                "(literal)", "20",
                "(operator)", "*",
                "(parenthesis)", "(",
                "(operator)", "-",
                "(literal)", "1",
                "(parenthesis)", ")"
                );
        }
        [TestMethod]
        public void TestMethod3()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("2.3e+21"),
                "(literal)", "2.3e+21"
                );
        }
        [TestMethod]
        public void TestMethod4()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("-1-(-5)"),
                "(operator)", "-",
                "(literal)", "1",
                "(operator)", "-",
                "(parenthesis)", "(",
                "(operator)", "-",
                "(literal)", "5",
                "(parenthesis)", ")"
                );
        }
        [TestMethod]
        public void TestMethod5()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("-1+(-2)"),
                "(operator)", "-",
                "(literal)", "1",
                "(operator)", "+",
                "(parenthesis)", "(",
                "(operator)", "-",
                "(literal)", "2",
                "(parenthesis)", ")"
                );
        }
        [TestMethod]
        public void TestMethod6()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("26*(20-154)"),
                "(literal)", "26",
                "(operator)", "*",
                "(parenthesis)", "(",
                "(literal)", "20",
                "(operator)", "-",
                "(literal)", "154",
                "(parenthesis)", ")"
                );
        }
        [TestMethod]
        public void TestMethod7()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("10-7/(2)"),
                "(literal)", "10",
                "(operator)", "-",
                "(literal)", "7",
                "(operator)", "/",
                "(parenthesis)", "(",
                "(literal)", "2",
                "(parenthesis)", ")"
                );
        }
        [TestMethod]
        public void TestMethod8()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("3-2.1+410"),
                "(literal)", "3",
                "(operator)", "-",
                "(literal)", "2.1",
                "(operator)", "+",
                "(literal)", "410"
                );
        }
        [TestMethod]
        public void TestMethod9()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("-14"),              
                "(operator)", "-",
                "(literal)", "14"
                );
        }
        [TestMethod]
        public void TestMethod10()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("5.1"),            
                "(literal)", "5.1"
                );
        }
        
        [TestMethod]
        public void TestMethod11()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("8e+3"),            
                "(literal)", "8e+3"
                );
        }
        [TestMethod]
        public void TestMethod12()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("8e+3"),
                "(literal)", "8e+3"
                );
        }
        [TestMethod]
        public void TestMethod13()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("-1.6e+3"),
                "(operator)", "-",
                "(literal)", "1.6e+3"
                );
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod14()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("-1e"),
                "(operator)", "-",
                "(literal)", "1e"
                );
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod15()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("8.9-2.1e"),
                "(literal)", "8.9",
                "(operator)", "-",
                "(literal)", "2.1e"
                );
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod16()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("0-6e*15"),
                "(literal)", "0",
                "(operator)", "-",
                "(literal)", "6e",
                "(operator)", "*",
                "(literal)", "15"
                );
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod17()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("4-1e/14"),
                "(literal)", "4",
                "(operator)", "-",
                "(literal)", "1e",
                "(operator)", "/",
                "(literal)", "14"
                );
        }
        [TestMethod]
        public void TestMethod18()
        {
            MathLexer lexer = new MathLexer();
            CheckTokens(lexer.Tokenize("06/02"),
                "(literal)", "06",
                "(operator)", "/",
                "(literal)", "02"
                );
        }

        


        

        
    }

}
