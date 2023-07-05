using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public interface ISubject
    {
        void Request();
    }

    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request");
        }
    }

    class Proxy : ISubject
    {
        private RealSubject _realsubject;

        public Proxy(RealSubject realsubject)
        {
            _realsubject = realsubject;
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: 실제 요청을 실행하기 전에 액세스를 확인");
            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: 요청 시간 기록");
        }

        public void Request()
        {
            if(CheckAccess())
            {
                _realsubject.Request();
                LogAccess();
            }
        }
    }

    public class Client
    {
        public void ClientCode(ISubject subject)
        {
            subject.Request();
        }
    }
}
