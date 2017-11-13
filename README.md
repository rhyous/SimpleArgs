## SimpleArgs ##
A project that makes it easier to add command line arguments to applications.

## Steps to use SimpleArgs ##

1. Install the NuGet package. It adds the SimpleArgs dll and an ArgsHandler.cs file.

    ```
    install-package SimpleArgs
    ```
Or if you don't want a separate dll, install this:

    ```
    install-package SimpleArgs.Sources
    ```

2. Add your new Arguments to the contructor of the ArgsHandler.cs file.

    ```
    public ArgsHandler()
    {
        Arguments = new List<Argument>
        {
            new Argument
            {
                Name = "Echo",
                ShortName = "E",
                Description = "I echo to the console whater you put after Echo=",
                Example = "Echo=\"Hello, World!\"",
                Action = (value) => { Console.WriteLine(value);}
            },
            // Add more args here
        };
    }
    ```

3. In Program.cs add this line of code to Main()

    ```
    static void Main(string[] args)
    {
        ArgsManager.Instance.Start(new ArgsHandler(), args);
    }
    ```

4. In the ArgsHandler.cs file, your new take action point is in the HandleArgs() method.

    ```
    public void HandleArgs(IReadArgs inArgsHandler)
    {
        Handled = true;
        Console.WriteLine("I handled the args!!!");
        // This is where you start your work now
    }
    ```

5. If you run with no args, you will be given usage.

    ```
    Usage:
      SimpleArgs.Example.exe Echo="Hello, World!"
      
    Arguments:
      Echo   (Optional) I echo to the console whater you put after Echo=
    
    Press any key to continue . . .
    ```
6. Access your arguments statically anywhere using static class Args.
     
    ```
    Args.Value("Echo") // returns value
    Args.Get("Echo") // Returns Argument object
    ```

