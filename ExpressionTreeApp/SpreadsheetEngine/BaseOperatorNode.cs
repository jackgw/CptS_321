namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Expression tree node representing an operator
    /// </summary>
    internal abstract class BaseOperatorNode : BaseNode
    {
        public char Operator { get; set; }

        public BaseNode Left { get; set; }

        public BaseNode Right { get; set; }
    }
}
