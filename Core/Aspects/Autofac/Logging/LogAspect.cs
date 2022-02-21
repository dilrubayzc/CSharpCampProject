using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Interceptors;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect:MethodInterception
    {
        private Logger log;
        public LogAspect(Type log)
        {
            if (log.BaseType != typeof(ILogger))
                throw new Exception("Yanlış aspect tipi !!!");
            this.log = (Logger)Activator.CreateInstance(log);
        }
        protected override void OnBefore(IInvocation invocation)
        {
            log.Info(GetLogDetail(invocation));
        }
        protected override void OnAfter(IInvocation invocation)
        {
            log.Info(GetLogDetail(invocation));
        }
        protected override void OnException(IInvocation invocation, Exception e)
        {
            log.Info(GetLogDetailwithException(invocation, e));
        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };
            return logDetail;
        }
        private LogDetailsWithException GetLogDetailwithException(IInvocation invocation,Exception ex)
        {
            var logDetail = GetLogDetail(invocation);
            var logDetailWithException = new LogDetailsWithException
            {
                MethodName = logDetail.MethodName,
                LogParameters = logDetail.LogParameters,
                ExceptionMessage = ex.Message
            };
            return logDetailWithException;
        }
    }
}
