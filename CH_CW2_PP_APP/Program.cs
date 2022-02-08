// See https://aka.ms/new-console-template for more information
using CH_CW2_PP_APP;

int GetThreadNumber()
{
    /// <summary>
    /// Get Thread numbers for parallel routines.
    /// </summary>
    /// 
    /// <returns>positive int</returns>

    while (true)
    {
        Console.Write("== Choose Thread Numbers ==\n=> ");
        string? answer3 = Console.ReadLine();

        // if null, restart
        if (answer3 == null) continue;

        int result = Int32.Parse(answer3);
        if (result > 0) return result;
        else continue;
    }
}

// Main Routine
while (true)
{
    // Choose routine
    Console.Write("== Choose Routine ==\n1) Crypto\n2) ...\n=> ");
    string? answer1 = Console.ReadLine();
    if (answer1 == null) continue;

    // Choose Mode
    Console.Write("== Choose Mode ==\n1) Serial Mode\n2) Parallel Mode\n=> ");
    string? answer2 = Console.ReadLine();
    if (answer2 == null) continue;

    // Start Routines
    switch (answer1)
    {
        case "1":
            if (answer2 == "1")
            {
                Crypto.SerialCaesar();
            } 
            else
            {
                Crypto.ParallelCaesar(GetThreadNumber());
            }
            goto EndRoutine;
        case "2":
            Console.WriteLine("1");
            goto EndRoutine;
        default:
            Console.WriteLine("Wrong Answer");
            break;
    }
}

// End Program
EndRoutine:
Console.WriteLine("End");
