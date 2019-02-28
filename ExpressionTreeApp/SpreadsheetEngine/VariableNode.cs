namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Expression tree node representing a variable
    /// </summary>
    internal class VariableNode : BaseNode
    {
        public VariableNode(string newName)
        {
            this.Name = newName;
        }

        public string Name { get; set; }

        public override double Evaluate()
        {
            return ;
        }
    }
}
