using System;
namespace CH_CW2_PP_APP
{
	internal class UIClass
	{
		public static string CreateInputDialog(string message)
        {
			Console.Write(message + "\n=> ");
			return Console.ReadLine().ToString();
        }

		public static string CreateInputDialogWithOptions(string message, List<string> options)
        {
			Console.WriteLine(message);
			for (int i=0;i<options.Count();i++)
            {
				Console.WriteLine((i + 1).ToString() + options[i]);
            }
			Console.Write("=> ");
			return Console.ReadLine().ToString();
        }

		public static void ShowProgressBar(int current, int length, int top, int thread)
        {
			var percent = current / (float)length * 100.0f;
			Console.SetCursorPosition(0, top + thread);
			string s = "Work in progress by Thread" + thread + " " + (int)percent + " :: " + current.ToString() + "/" + length.ToString();
			Console.WriteLine(s);
		}
	}
}

