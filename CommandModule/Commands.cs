using System;
using System.Collections.Generic;

namespace Commands

//To use the Commands, you should set your function's parameter as an string array.
//The Array contains all the parameters following the first command string seperated by espace(default).
//Your function should transform the string in the Array into the type you want yourself.
//Your function should Not return value or object
//Use Commands.AddCommand(str,func) to link the command string and your function

{
    public delegate void Func(string[] para);
    //public delegate void FuncParameterized(object o);
    class Command
    {

        private static Dictionary<string, Func> commandLib;//all the relations between string and funcs
        private string inputString { get; }//the string user inputed
        private string commandString { get; }//the command string that identified
        private string[] parameterStrings { get; }//the parameters that identified


        public static char seperator { get; set; }//the char to seperated the string,default is espace
        public static string exitor { get; set; }//the string of command to stop listening commands

        static Command()
        {
            //Set the default seperator as the 'espace' character
            seperator = ' ';
            //Set the default exitor as the "exit" string
            exitor = "exit";
            commandLib = new Dictionary<string, Func>();


        }

        static public void AddCommand(string _cstring, Func _func)
        {
            commandLib.Add(_cstring, _func);

            Console.WriteLine("{0} was added to the command library as the command:{1}\n", _func, _cstring);

        }


        static public void Listen()
        {
            Console.WriteLine("Hello World!\nUse exit to quit listening commands.\n");
            Console.WriteLine("---------------------------------------------------");
            while (true)
            {
                string i = Console.ReadLine();
                Command c = new Command(i);

               

                if (c.commandString == exitor)//the way to stop commanding
                {
                    break;
                }
                try
                {
                    c.Excute();//Excute the command inputed
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error called:\n" + e.Message + "\nhas occured when excuting the command.\nFailed to excute it.\n");
                    Console.WriteLine("---------------------------------------------------");
                    continue;
                }


                //Console.WriteLine("Excuted the command :{0}\n", c.commandString);
                Console.WriteLine("---------------------------------------------------");
            }
        }



        public Command(string _input)
        {
            //parameterStrings = new ArrayList();
            inputString = _input;
            

            string[] _splited = inputString.Split(seperator);
            commandString = _splited[0];

            parameterStrings = new string[_splited.Length-1];

            for (int i = 1; i < _splited.Length; i++)
            {
                parameterStrings[i - 1] = _splited[i];
            }


        }


        public Func FindFuncByCmdString(string _cmdString)
        {
            foreach (string _libString in commandLib.Keys)
            {
                if (_libString == commandString)
                {
                    Console.WriteLine("The command :{0}  was FOUND!!", commandString);
                    return commandLib[_libString];
                }

            }
            Console.WriteLine("The command :{0}  was NOT found!!", commandString);
            return null;
        }

        public void Excute()
        {
            //Object _paras = parameterStrings as Object;

            Func _func = FindFuncByCmdString(commandString);

            if (_func == null)
            {
                Console.WriteLine("Fail to excute the command :{0}\n\n", commandString);
                return;
            }

            _func(parameterStrings);
            
        }
    }
}


