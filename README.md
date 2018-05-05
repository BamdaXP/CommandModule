# 控制台模块 CommandModule

**语言：C#**

提供一个类，能够方便地让程序执行一般控制台有地基础功能。
提供一个控制台界面方便程序DEBUG或者直接进行发布。

Program.cs是提供的实现例子，如果你已经掌握可以忽视。

## 使用方法
1. 将文件CommandModule.cs添加进工程

2. 在**主程序入口**中添加命名空间 Commands

    
```
using System;

using Commands;

class Program
{
    static void main(string[] args)
    {
        .......
    }
}
```

3. 在开始监听用户输入之前，向CommandLib中添加**函数**与**字符串命令名称**的关联关系。


```
       
        Command.AddCommand("dofunc",func); //其中，func是函数的名字，dofunc是希望调用时使用的命令名称
        //

```

4. 开始监听用户输入

```
Command.Listen();
```
执行这条语句时，主进程会停在这里，此后控制台的输入都会当作命令处理


## 函数编写要求

- **不能带有返回值（void）**。带有返回值没有任何意义，控制台只会执行命令并不会接受命令的结果。
- **参数必须是一个字符串数组**用来存储参数。
- **需要有参数检测**。否则用户的输入会很不安全。CommandModule已经有处理错误的方法，你只需要把错误throw出去就行了。
- **需要有参数的转化**。所有命令后接上的参数都会当作字符串放在参数的字符串数组里，使用时需要自行根据需要转化。

例子：

```
void func(string[] _paras)
        {

            /////////////////////////////////////////////////////////////
            //       Check and Transform the Parameters.It's important.//
            /////////////////////////////////////////////////////////////
            int p0;
            string p1;
            
            //Try to transform the parameters
            try
            {
                p0 = int.Parse(_paras[0]);
                p1 = _paras[1];
            }
            catch (Exception e)
            {
                throw e;
            }




            ///////////////////////////////////////////////////////////
            //          Your Func actually starts at here.           //
            ///////////////////////////////////////////////////////////
            Console.WriteLine(p0 + p1);
            Console.WriteLine("This is the function.");
        }
```


## 退出

使用以下命令来退出监听输入

```
exit
```

## 修改
- 命令的分隔符默认是空格(espace)，你可以通过以下方法修改

```
Command.seperator = 'x';//x为你需要的分隔符
```
- 退出监听的默认命令字符是 "exit" ，你可以通过以下方法修改


```
Command.exitor = "xxx";//xxx为你需要的字符串
```
# 欢迎提建议以及报BUG
# 玩的开心




