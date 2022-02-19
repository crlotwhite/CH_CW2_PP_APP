// See https://aka.ms/new-console-template for more information
using CH_CW2_PP_APP;

var argsArray = Environment.GetCommandLineArgs();
if (argsArray.Count() > 1)
{
    string mode = argsArray[1];

    if (mode == "-t")
    {
        string isParallel = argsArray[2];
        if (isParallel == "-s")
        {
            Crypto.SerialCaesar();
        }
        else if (isParallel == "-m")
        {
            string threadNumberString = argsArray[3];
            int threadNumber = int.Parse(threadNumberString);
            Crypto.threadCount = threadNumber;
            Crypto.ParallelCaesar();
        }
    }

}
else
{
    string srcPath = UIClass.CreateInputDialog("Source File Path");
    string destPath = UIClass.CreateInputDialog("Destination File Path");
    string mode = UIClass.CreateInputDialogWithOptions("Mode", new List<string> { "Encrypt", "Decrypt" });

    List<string> textList = Utils.GetWordsFromFile(srcPath);
    List<string> outputList;
    if (mode == "1")
    {
        outputList = Crypto.ParallelCaesar(textList);
    }
    else
    {
        outputList = Crypto.DecryptCaesar(textList);
    }

    if (Utils.ExportTextFile(destPath, outputList))
    {
        Console.WriteLine("Success!");
    }
    else
    {
        Console.WriteLine("Fail...");
    }

}

Console.WriteLine("End");
