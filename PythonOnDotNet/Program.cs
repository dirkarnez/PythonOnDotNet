using Python.Runtime;
using System;

namespace PythonOnDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Py.GIL())
            {
                // https://www.python.org/ftp/python/3.5.0/python-3.5.0-embed-win32.zip
                dynamic client = Py.Import("http.client");
                dynamic conn = client.HTTPSConnection("www.python.org");
                conn.request("GET", "/static/favicon.ico");
                Console.WriteLine(conn.getresponse().status);
                conn.close();
                Console.ReadLine();
            }
        }
    }
}
