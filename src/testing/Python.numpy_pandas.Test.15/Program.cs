using Python.Runtime;
using System;
using System.Collections.Generic;

namespace TestExec
{
    class Program
    {
        static void Main(string[] args)
        {
            PythonEngine.PythonHome += "C:\\Python27amd64";
            PythonEngine.Initialize();
            var home = PythonEngine.PythonHome;
            
            using (Py.GIL())
            {
                dynamic np = Py.Import("numpy");
                dynamic pd = Py.Import("pandas");
                Console.WriteLine(np.cos(np.pi * 2));

                dynamic sin = np.sin;
                Console.WriteLine(sin(5));

                double c = np.cos(5) + sin(5);
                Console.WriteLine(c);

                dynamic a = np.array(new List<float> { 1, 2, 3 });
                Console.WriteLine(a.dtype);

                dynamic dtype;
                dynamic b = np.array(new List<float> { 6, 5, 4 }, dtype = np.int32);
                Console.WriteLine(b.dtype);

                Console.WriteLine(a * b);

                dynamic df = pd.DataFrame(a * b);
                Console.WriteLine(df);

                Console.ReadKey();
            }

        }
    }
}
