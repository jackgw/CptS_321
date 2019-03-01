namespace CptS321
{
    using System;
    using NUnit.Framework;

    public class ExpressionTest
    {
        [Test]
        public void PlusEvaluationTest()
        {
            ExpressionTree appExpressionTree = new ExpressionTree("This+is+a+test+15");
            Assert.AreEqual(appExpressionTree.Evaluate(), 15.0); // variables should be 0 by default;
            appExpressionTree.SetVariable("This", 5.5);
            Assert.AreEqual(appExpressionTree.Evaluate(), 20.5); // "This" variable should now be 5.5
            appExpressionTree.SetVariable("is", -2.5);
            Assert.AreEqual(appExpressionTree.Evaluate(), 18.0); // "is" variable should now be -2.5
            appExpressionTree.SetVariable("a", 100);
            appExpressionTree.SetVariable("test", -25);
            Assert.AreEqual(appExpressionTree.Evaluate(), 93.0);
        }

        [Test]
        public void MinusEvaluationTest()
        {
            ExpressionTree appExpressionTree = new ExpressionTree("This-is-a-test-15");
            Assert.AreEqual(appExpressionTree.Evaluate(), -15.0); // variables should be 0 by default;
            appExpressionTree.SetVariable("This", 5.5);
            Assert.AreEqual(appExpressionTree.Evaluate(), -9.5); // "This" variable should now be 5.5
            appExpressionTree.SetVariable("is", -2.5);
            Assert.AreEqual(appExpressionTree.Evaluate(), -7.0); // "is" variable should now be -2.5
            appExpressionTree.SetVariable("a", 100);
            appExpressionTree.SetVariable("test", -25);
            Assert.AreEqual(appExpressionTree.Evaluate(), -82.0);
        }

        [Test]
        public void MultiplyEvaluationTest()
        {
            ExpressionTree appExpressionTree = new ExpressionTree("This*is*a*test*4");
            Assert.AreEqual(appExpressionTree.Evaluate(), 0); // variables should be 0 by default;
            appExpressionTree.SetVariable("This", 2);
            appExpressionTree.SetVariable("is", -10);
            appExpressionTree.SetVariable("a", 2.5);
            appExpressionTree.SetVariable("test", -0.5);
            Assert.AreEqual(appExpressionTree.Evaluate(), 100);
        }

        [Test]
        public void DivideEvaluationTest()
        {
            ExpressionTree appExpressionTree = new ExpressionTree("This/is/a/test/-10");
            appExpressionTree.SetVariable("This", 100);
            appExpressionTree.SetVariable("is", 2);
            appExpressionTree.SetVariable("a", -5);
            appExpressionTree.SetVariable("test", 0.5);
            Assert.AreEqual(appExpressionTree.Evaluate(), 2);
        }
    }
}
