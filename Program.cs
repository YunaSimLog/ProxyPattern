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
            NormalProxy normalProxy = new NormalProxy(realsubject);
            client.ClientCode(normalProxy);

            Console.WriteLine();

            Console.WriteLine("Client: 가상 프록시로 동일한 클라이언트 코드 실행");
            VirtualProxy virtualProxy = new VirtualProxy();
            client.ClientCode(virtualProxy);
        }
    }
}
