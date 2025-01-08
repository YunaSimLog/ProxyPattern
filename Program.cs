using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Client: real Subject로 클라이언트 코드 실행");
            RealSubject realsubject = new RealSubject();
            client.ClientCode(realsubject);

            Console.WriteLine();

            Console.WriteLine("Client: 기본형 프록시로 동일한 클라이언트 코드 실행");
            Proxy_Default proxyDefault = new Proxy_Default(realsubject);
            client.ClientCode(proxyDefault);

            Console.WriteLine();

            Console.WriteLine("Client: 가상 프록시로 동일한 클라이언트 코드 실행");
            Proxy_Virtual proxy = new Proxy_Virtual();
            client.ClientCode(proxy);
        }
    }
}
