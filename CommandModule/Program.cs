using System;
//remember to use the namespace
using Commands;


namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //Use this to add a command to the command lib
            Command.AddCommand("cc", cc);
            Command.AddCommand("aa", aa);

            //start listening commands
            Command.Listen();
        }

        static void aa(string[] _paras)
        {
            Console.WriteLine("This is the function aa");
        }

        static void cc(string[] _paras)
        {

            /////////////////////////////////////////////////////////////
            //       Check and Transform the Parameters.It's important.//
            /////////////////////////////////////////////////////////////
            int p0;
            string p1;


            try//check for paras
            {
                p0 = int.Parse(_paras[0]);
                p1 = _paras[1];
            }
            catch (Exception e)
            {
                throw e;
            }



            ///////////////////////////////////////////////////////////
            //       Transform the Parameters.It's important.        //
            ///////////////////////////////////////////////////////////
           

            ///////////////////////////////////////////////////////////
            //          Your Func actually starts at here.           //
            ///////////////////////////////////////////////////////////
            Console.WriteLine(p0 + p1);
            Console.WriteLine("This is the function cc.");
        }

    }
}
