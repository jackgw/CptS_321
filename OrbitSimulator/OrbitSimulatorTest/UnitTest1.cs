using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CptS321
{
    public class UnitTest1
    {
        private  methods = new NonPublic();

        private MethodInfo GetMethod(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Assert.Fail("methodName cannot be null or whitespace");
            }

            var method = this.methods.GetType().GetMethod(name,
            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            if (method == null)
            {
                Assert.Fail(string.Format("{0}	method	not	found", name));
            }
            return method;
        }

        [Test]
        public void TestMyPrivateInstanceMethod()
        {
            //	Retrieve	the	method	that	we	want	to	test	using	reflection
            MethodInfo methodInfo = this.GetMethod("privCalc");

            //	Test	the	method	by	calling	the	MethodBase.Invoke method
            Assert.AreEqual(15, methodInfo.Invoke(methods, new object[] { 5 }));
        }
    }
}
