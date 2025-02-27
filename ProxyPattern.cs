﻿using System;
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

    /// <summary>
    ///  기본형 프록시
    ///  RealSubject (실제 대상)을 생성자로 받아 처리
    /// </summary>
    class NormalProxy : ISubject
    {
        private RealSubject _realsubject;

        public NormalProxy(RealSubject realsubject)
        {
            _realsubject = realsubject;
        }

        public bool CheckAccess()
        {
            Console.WriteLine("NormalProxy: 실제 요청을 실행하기 전에 액세스를 확인");
            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("NormalProxy: 요청 시간 기록");
        }

        public void Request()
        {
            if (CheckAccess())
            {
                _realsubject.Request();
                LogAccess();
            }
        }
    }

    /// <summary>
    /// 가상 프록시
    /// 객체 초기화가 실제로 필요한 시점에 초기화될수 있도록 지연
    /// </summary>
    class VirtualProxy : ISubject
    {
        private RealSubject _realsubject;

        public VirtualProxy()
        {
        }

        public bool CheckAccess()
        {
            Console.WriteLine("VirtualProxy: 실제 요청을 실행하기 전에 액세스를 확인");
            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("VirtualProxy: 요청 시간 기록");
        }

        public void Request()
        {
            if (_realsubject == null)
                _realsubject = new RealSubject();

            if (CheckAccess())
            {
                _realsubject.Request();
                LogAccess();
            }
        }
    }

    /// <summary>
    /// 보호 프록시
    /// </summary>
    public class ProtectionProxy : ISubject
    {
        private RealSubject _realsubject;
        bool _access; // 접근 권한

        ProtectionProxy(RealSubject realsubject, bool access)
        {
            _realsubject = realsubject;
            _access = access;
        }

        public void Request()
        {
            if (_access)
            {
                _realsubject.Request();
            }
        }
    }

    public class LoggingProxy : ISubject
    {
        RealSubject _realSubject;

        LoggingProxy(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        public void Request()
        {
            Console.WriteLine("로깅.....");

            _realSubject.Request();

            Console.WriteLine("프록시 객체 액션 수행!!");

            Console.WriteLine("로깅.....");
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
