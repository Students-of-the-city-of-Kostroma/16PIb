using MathCadConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibraryTest
{
    [TestClass]
    public class ClassCalcTest
    {
        [TestMethod]
        public void TestMethodCalc01()
        {
            ClassObrpolsksap Obrpolsapis = new ClassObrpolsksap();
            ClassCalc Calcul = new ClassCalc();
            var lexer = new MathLexer();
            List<Token> tokens = new List<Token>(lexer.Tokenize("(2+3)*5"));
            List<Token> result = Obrpolsapis.Obrpolsksap(tokens);

            Assert.AreEqual(25, Calcul.Calc(result));

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethodCalc02()
        {
            ClassObrpolsksap Obrpolsapis = new ClassObrpolsksap();
            ClassCalc Calcul = new ClassCalc();
            var lexer = new MathLexer();
            List<Token> tokens = new List<Token>(lexer.Tokenize("(1+2)/0"));
            List<Token> result = Obrpolsapis.Obrpolsksap(tokens);

            Assert.AreEqual(12, Calcul.Calc(result));
        }

        [TestMethod]
        public void TestMethodCalc03()
        {
            ClassObrpolsksap Obrpolsapis = new ClassObrpolsksap();
            ClassCalc Calcul = new ClassCalc();
            var lexer = new MathLexer();
            List<Token> tokens = new List<Token>(lexer.Tokenize("(1+2)/(3+3)"));
            List<Token> result = Obrpolsapis.Obrpolsksap(tokens);

            Assert.AreEqual(0.5, Calcul.Calc(result));
        }

        [TestMethod]
        public void TestMethodCalc04()
        {
            ClassObrpolsksap Obrpolsapis = new ClassObrpolsksap();
            ClassCalc Calcul = new ClassCalc();
            var lexer = new MathLexer();
            List<Token> tokens = new List<Token>(lexer.Tokenize("6*(2-(0-1))"));
            List<Token> result = Obrpolsapis.Obrpolsksap(tokens);

            Assert.AreEqual(18, Calcul.Calc(result));
        }
        
    }
}
