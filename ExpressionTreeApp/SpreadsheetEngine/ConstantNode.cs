namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Expression tree node representing a constant
    /// </summary>
    internal class ConstantNode : BaseNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value">Constant value of the node</param>
        public ConstantNode(int value)
        {
            this.Value = value;
        }

        public double Value { get; set; }

        public override double Evaluate()
        {
            return this.Value;
        }
    }
}
