

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Invoker class for the spreadsheet command pattern
    /// </summary>
    public class SheetInvoker
    {
        private Stack<Command> undoStack = new Stack<Command>();
        private Stack<Command> redoStack = new Stack<Command>();

        public SheetInvoker()
        {

        }

        public void ExecuteCommand(Command cmd)
        {
            cmd.Execute();
            this.undoStack.Push(cmd);
        }

        public void UndoLastCommand()
        {
            Command tempCmd = this.undoStack.Pop();
            tempCmd.Undo();
            this.redoStack.Push(tempCmd);
        }

        public void RedoLastCommand()
        {
            Command tempCmd = this.redoStack.Pop();
            tempCmd.Execute();
            this.undoStack.Push(tempCmd);
        }

        public string CheckUndo()
        {
            if (this.undoStack.Peek() != null)
            {
                return this.undoStack.Peek().Name;
            }

            return string.Empty;
        }

        public string CheckRedo()
        {
            if (this.redoStack.Peek() != null)
            {
                return this.redoStack.Peek().Name;
            }

            return string.Empty;
        }
    }
}
