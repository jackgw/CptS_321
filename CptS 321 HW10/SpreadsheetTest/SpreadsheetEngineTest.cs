// <copyright file="SpreadsheetEngineTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Jack Wharton
// 11506329
// CptS 321

namespace CptS321
{
    using System;
    using System.Threading;
    using NUnit.Framework;

    /// <summary>
    /// Test class for the spreadsheet engine, testing various functionalities
    /// </summary>
    public class SpreadsheetEngineTest
    {
        /// <summary>
        /// Tests the ability of the spreadsheet class and it's underlying engine to evaluate an
        /// expression correctly, using operators: +, -, *, and parentheses
        /// </summary>
        [Test]
        public void ExpressionEvaluationTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            /* Add */
            spreadsheet.ChangeText(1, 1, "=10+5");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 1).Value), 15);

            /* Subtract */
            spreadsheet.ChangeText(1, 1, "=10-5");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 1).Value), 5);

            /* Multiply */
            spreadsheet.ChangeText(1, 1, "=10*5");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 1).Value), 50);

            /* Divide */
            spreadsheet.ChangeText(1, 1, "=10/5");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 1).Value), 2);

            /* Multiple Operators */
            spreadsheet.ChangeText(1, 1, "=2*2/4+5-3");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 1).Value), 3);

            /* Precedence */
            spreadsheet.ChangeText(1, 1, "=5+10*2");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 1).Value), 25);

            /* Parentheses */
            spreadsheet.ChangeText(1, 1, "=(5+10)*2");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 1).Value), 30);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet class and it's underlying engine to evaluate an
        /// expression that depends on the value of another cell
        /// </summary>
        [Test]
        public void DependancyTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            spreadsheet.ChangeText(1, 1, "10");
            spreadsheet.ChangeText(1, 2, "=B2");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 2).Value), 10);

            spreadsheet.ChangeText(0, 0, "-10.01");
            spreadsheet.ChangeText(12, 10, "=A1");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(12, 10).Value), -10.01);

            /* string cell copy not implemented yet, should assign to zero for now */
            spreadsheet.ChangeText(1, 1, "test");
            spreadsheet.ChangeText(1, 2, "=B2");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 2).Value), 0);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet class and it's underlying engine to evaluate an
        /// expression depending on multiple different cells
        /// </summary>
        [Test]
        public void MultipleDependancyTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            spreadsheet.ChangeText(1, 1, "20");
            spreadsheet.ChangeText(1, 2, "4");
            spreadsheet.ChangeText(0, 0, "=B2+B3");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 24);

            spreadsheet.ChangeText(1, 1, "2");
            spreadsheet.ChangeText(1, 2, "4");
            spreadsheet.ChangeText(1, 3, "6");
            spreadsheet.ChangeText(1, 4, "8");
            spreadsheet.ChangeText(0, 0, "=(B2+B3)*B4-B5");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 28);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet class and it's underlying engine to update the value of a cell
        /// when a different cell that it is dependant on has its value changed
        /// </summary>
        [Test]
        public void DependancyUpdateTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            spreadsheet.ChangeText(1, 1, "10");
            spreadsheet.ChangeText(1, 2, "5");
            spreadsheet.ChangeText(0, 0, "=B2+B3");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 15);
            spreadsheet.ChangeText(1, 1, "15");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 20);
            spreadsheet.ChangeText(1, 1, "20");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 25);
            spreadsheet.ChangeText(1, 2, "20");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 40);
        }

        /// <summary>
        /// Creates a test Sheet class, and uses the GetCell() method to test whether ChangeText() worked correctly.
        /// </summary>
        [Test]
        public void CellTextChangedTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            spreadsheet.ChangeText(5, 5, "10");
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(5, 5).Value), 10);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet and it's underlying logic to undo changed text
        /// </summary>
        [Test]
        public void UndoTextTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);
            SheetInvoker commandControl = new SheetInvoker();

            Command cmd1 = new ChangeTextCommand(spreadsheet.GetCell(1, 1), "100");
            CommandCollection commands1 = new CommandCollection("Text Change", cmd1);
            commandControl.ExecuteCommand(commands1);

            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(1, 1).Text, "100");

            commandControl.UndoLastCommand();

            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(1, 1).Text, string.Empty);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet and it's underlying logic to undo changed BG color
        /// </summary>
        [Test]
        public void UndoColortest()
        {
            Sheet spreadsheet = new Sheet(26, 50);
            SheetInvoker commandControl = new SheetInvoker();

            Command cmd1 = new ChangeColorCommand(spreadsheet.GetCell(1, 1), 0x000FFFFF);
            CommandCollection commands1 = new CommandCollection("Text Change", cmd1);
            commandControl.ExecuteCommand(commands1);

            Assert.AreEqual(spreadsheet.GetCell(1, 1).BGColor, 0x000FFFFF);

            commandControl.UndoLastCommand();

            Assert.AreEqual(spreadsheet.GetCell(1, 1).BGColor, 0xFFFFFFFF);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet and it's underlying logic to undo changed text
        /// </summary>
        [Test]
        public void RedoTextTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);
            SheetInvoker commandControl = new SheetInvoker();

            Command cmd1 = new ChangeTextCommand(spreadsheet.GetCell(1, 1), "100");
            CommandCollection commands1 = new CommandCollection("Text Change", cmd1);
            commandControl.ExecuteCommand(commands1);

            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(1, 1).Text, "100");

            commandControl.UndoLastCommand();

            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(1, 1).Text, string.Empty);

            commandControl.RedoLastCommand();

            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(1, 1).Text, "100");
        }

        /// <summary>
        /// Tests the ability of the spreadsheet and it's underlying logic to undo changed BG color
        /// </summary>
        [Test]
        public void RedoColorTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);
            SheetInvoker commandControl = new SheetInvoker();

            Command cmd1 = new ChangeColorCommand(spreadsheet.GetCell(1, 1), 0x000FFFFF);
            CommandCollection commands1 = new CommandCollection("Text Change", cmd1);
            commandControl.ExecuteCommand(commands1);

            Assert.AreEqual(spreadsheet.GetCell(1, 1).BGColor, 0x000FFFFF);

            commandControl.UndoLastCommand();

            Assert.AreEqual(spreadsheet.GetCell(1, 1).BGColor, 0xFFFFFFFF);

            commandControl.RedoLastCommand();

            Assert.AreEqual(spreadsheet.GetCell(1, 1).BGColor, 0x000FFFFF);
        }

        /// <summary>
        /// Tests the XML Saving and loading functionality of the spreadsheet
        /// NOTE: filename is local to this machine, a new file will have to be created if this program is transferred
        /// Can use the normal interface to do this ^^
        /// </summary>
        [Test]
        public void SaveLoadTest()
        {
            Sheet spreadsheetSave = new Sheet(26, 50);
            Sheet spreadsheetLoad = new Sheet(26, 50);

            /* Location of xml file for test use */
            string filename = "C:\\Users\\jackg\\Desktop\\CptS 321\\GitLab\\CptS 321 HW9\\CptS 321 HW4\\XmlTestFile.xml";

            spreadsheetSave.ChangeText(0, 0, "25");
            spreadsheetSave.ChangeText(0, 1, "=A1+5");
            spreadsheetSave.ChangeBGColor(0, 1, 0x00800080); // purple

            Assert.AreEqual(double.Parse(spreadsheetSave.GetCell(0, 0).Value), 25);
            Assert.AreEqual(double.Parse(spreadsheetSave.GetCell(0, 1).Value), 30);
            Assert.AreEqual(spreadsheetSave.GetCell(0, 1).BGColor, (uint)0x00800080);

            /* Save */
            spreadsheetSave.SaveXML(filename);

            /* Load into spreadsheetLoad */
            spreadsheetLoad.LoadXML(filename);

            Assert.AreEqual(double.Parse(spreadsheetLoad.GetCell(0, 0).Value), 25);
            Assert.AreEqual(double.Parse(spreadsheetLoad.GetCell(0, 1).Value), 30);
            Assert.AreEqual(spreadsheetLoad.GetCell(0, 1).BGColor, (uint)0x00800080);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet to detect an invalid reference and change the
        /// value of the cell to an error message
        /// </summary>
        [Test]
        public void InvalidReferenceTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            spreadsheet.ChangeText(0, 0, "=12+fooref_123");

            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(0, 0).Value, "!(Invalid Reference)");

            spreadsheet.ChangeText(0, 0, "=12+B1");

            /* Changes should update normally */
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 12);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet to detect an out of bouds reference and change the
        /// value of the cell to an error message
        /// </summary>
        [Test]
        public void OutOfBoundsTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            spreadsheet.ChangeText(0, 0, "=A75");

            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(0, 0).Value, "!(Out of Bounds)");

            spreadsheet.ChangeText(0, 0, "=A10");

            /* Changes should update normally */
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 0);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet to detect a self reference and change the
        /// value of the cell to an error message
        /// </summary>
        [Test]
        public void SelfReferenceTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            spreadsheet.ChangeText(0, 0, "=300+(101*B1/A1)");

            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(0, 0).Value, "!(Self Reference)");

            spreadsheet.ChangeText(0, 0, "=300+(101*B1/100)");

            /* Changes should update normally */
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 300);
        }

        /// <summary>
        /// Tests the ability of the spreadsheet to detect a circular reference and change the
        /// value of the cell to an error message
        /// </summary>
        [Test]
        public void CircularReferenceTest()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            spreadsheet.ChangeText(0, 0, "=10+A2");
            spreadsheet.ChangeText(0, 1, "=2*B2");
            spreadsheet.ChangeText(1, 1, "=4*B1");
            spreadsheet.ChangeText(1, 0, "=20-A1"); // Circular reference

            /* All invloved cells should display error */
            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(0, 0).Value, "!(Circular Reference)");
            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(0, 1).Value, "!(Circular Reference)");
            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(1, 1).Value, "!(Circular Reference)");
            StringAssert.AreEqualIgnoringCase(spreadsheet.GetCell(1, 0).Value, "!(Circular Reference)");

            spreadsheet.ChangeText(1, 0, "=20");

            /* Changes should be updated normally */
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 0).Value), 20);
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(1, 1).Value), 80);
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 1).Value), 160);
            Assert.AreEqual(double.Parse(spreadsheet.GetCell(0, 0).Value), 170);
        }
    }
}
