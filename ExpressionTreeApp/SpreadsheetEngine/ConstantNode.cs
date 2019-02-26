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
    class ConstantNode : BaseNode
    {
        public double Value { get; set; }
    }
}
