﻿// <copyright file="ExpressionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Jack Wharton
// 11506329
// CptS 321

namespace CptS321
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Test class for Expression Tree
    /// </summary>
    public class ExpressionTest
    {
        /// <summary>
        /// Scenario testing the addition operator
        /// </summary>
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

        /// <summary>
        /// Scenario testing the subtraction operator
        /// </summary>
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

        /// <summary>
        /// Scenario testing the multiplication operator
        /// </summary>
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

        /// <summary>
        /// Scenario testing the division operator
        /// </summary>
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

        /// <summary>
        /// Scenarios testing combinations of the four types of operators supported: +, -, *, /
        /// </summary>
        [Test]
        public void MultipleOperatorEvaluationTest()
        {
            ExpressionTree appExpressionTree = new ExpressionTree("2*50/25+15-10");
            Assert.AreEqual(appExpressionTree.Evaluate(), 9);
            appExpressionTree = new ExpressionTree("100/50*25-15+10");
            Assert.AreEqual(appExpressionTree.Evaluate(), 45);
        }

        /// <summary>
        /// Scenarios testing precedence of the four types of operators supported: +, -, *, /
        /// </summary>
        [Test]
        public void OperatorPrecedenceEvaluationTest()
        {
            ExpressionTree appExpressionTree = new ExpressionTree("10+2*8+4");
            Assert.AreEqual(appExpressionTree.Evaluate(), 30);
            appExpressionTree = new ExpressionTree("5-100/25");
            Assert.AreEqual(appExpressionTree.Evaluate(), 1);
        }

        /// <summary>
        /// Scenarios testing correct use of parentheses
        /// </summary>
        [Test]
        public void ParenthesesEvaluationTest()
        {
            ExpressionTree appExpressionTree = new ExpressionTree("2-(10-9)");
            Assert.AreEqual(appExpressionTree.Evaluate(), 1);
            appExpressionTree = new ExpressionTree("(6*2)/(4*3)");
            Assert.AreEqual(appExpressionTree.Evaluate(), 1);
            appExpressionTree = new ExpressionTree("(4*(2+8))/2");
            Assert.AreEqual(appExpressionTree.Evaluate(), 20);
        }
    }
}
