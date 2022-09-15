using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AOPLogTest
{
    [AttributeUsage(AttributeTargets.Class)]
    class AopLogAttribute : ContextStaticAttribute, IContributeObjectSink
    {
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return null;
        }


    }

    [AopLog]
    public class AopContext : ContextBoundObject
    {


    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AopLogMethodAttribute : Attribute
    {


    }

}
