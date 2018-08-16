using System;
using PostSharp.Laos;

namespace PostSharpExample
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class LoggingAttribute : OnMethodBoundaryAspect
    {
        public string BusinessName { get; set; }

        public override void OnEntry(MethodExecutionEventArgs eventArgs)
        {
            LoggingHelper.Writelog(BusinessName + "开始执行");
        }

        public override void OnExit(MethodExecutionEventArgs eventArgs)
        {
            LoggingHelper.Writelog(BusinessName + "成功完成");
        }
    }
}
