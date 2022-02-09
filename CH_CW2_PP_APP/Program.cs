// See https://aka.ms/new-console-template for more information
using CH_CW2_PP_APP;

string mode = Environment.GetCommandLineArgs()[1];

if (mode == "-t")
{
    string isParallel = Environment.GetCommandLineArgs()[2];
    if (isParallel == "-s")
    {
        Crypto.SerialCaesar();
    }
    else if (isParallel == "-m")
    {
        string threadNumberString = Environment.GetCommandLineArgs()[3];
        int threadNumber = int.Parse(threadNumberString);
        Crypto.ParallelCaesar(threadNumber);
    }
}

Console.WriteLine("End");
