using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandheldServer.DIInstallers
{
    //public interface IAuthProvider
    public interface ISomethingProvider
    {
        // These are the methods that are in Dom's example IAuthProvider interface; I don't know what I need for HandheldServer yet, though...
        //bool Authenticate(string username, string password, bool createPersistentCookie);
        //void SignOut();
    }

    //From http://app-code.net/wordpress/?p=676; see also http://devlicio.us/blogs/krzysztof_kozmic/archive/2009/12/24/castle-typed-factory-facility-reborn.aspx
    //public interface IMyFirstFactory
    //{
    //    T Create<T>();
    //    void Release(object value);
    //}

}