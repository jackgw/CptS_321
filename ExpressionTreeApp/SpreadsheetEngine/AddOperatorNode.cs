namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class AddOperatorNode : BaseOperatorNode
    {
        public AddOperatorNode(char c)
        {
            this.Operator = c;
            this.Left = this.Right = null;
        }

        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Left.Evaluate(ref variables) + this.Right.Evaluate(ref variables);
        }
    }
}
