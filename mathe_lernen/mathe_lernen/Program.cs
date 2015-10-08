using System;
namespace mathe_lernen
{
	class MainClass
	{
		public static void Main (string[] args)
		{	
			Console.WriteLine ("Open Source projekt von Marten-Marc Droth unter der MIT Licens");
			Random rnd = new Random();
			while (true) {
				DateTime start = DateTime.UtcNow;
				string input = "0";
				string[] output = new string[2];
				Int32 ran;
				Int32 f = 0;
				Int32 r = 0;
				Console.Write ("Anzahl der aufgabe:");
				input = Console.ReadLine ();
				try
				{
					Convert.ToInt32(input);
				}
				catch
				{
					input = "10";
				}
				for(Int32 i = Convert.ToInt32(input);i>0;i--)
				{
					Console.Clear();
					ran = rnd.Next (0, 4);
					switch(ran)
					{
					case 0:
						output = addition (rnd.Next(0,101));
						break;
					case 1:
						output = subtraktion(rnd.Next(0,101));
						break;
					case 2:
						output = multiplikation(rnd.Next(0,101));
						break;
					case 3:
						output = division(rnd.Next(0,101));
						break;
					default:
						Console.WriteLine ("error: {0}", ran.ToString ());
						Console.ReadKey ();
						output [0] = "error";
						output [1] = "error";
						break;
					}
					Console.WriteLine ("Aufgabe verbleibent: {0}", i);
					Console.Write (output [0]);
					if (Console.ReadLine () == output [1]) {
						Console.WriteLine ("\nRichtig");
						r++;
					} else {
						Console.WriteLine ("\nFalsch. Lösung:{0}", output [1]);
						f++;
					}
					Console.ReadKey ();
				}
				Console.Clear ();
				DateTime ende = DateTime.UtcNow;
				Console.WriteLine("Du hast insgesamt {0}m{1}s gebraucht",(ende-start).Minutes,(ende-start).Seconds);
				try
				{
					Console.WriteLine("{0}% richtig",r*100/(f+r));
				}
				catch
				{
					Console.WriteLine ("0% richtig");
				}
				Console.WriteLine("Falsche antworten: {0}",f);
				Console.WriteLine("Richtige antworten: {0}",r);
				Console.WriteLine ("Neustart? [J]a [N]ein");
				input = Console.ReadLine();
				if (!(input == "J" || input == "j" || input == "y" || input == "Y"))
				{
					break;
				}
				Console.Clear ();
			}
		}
		static int absnz(Int32 input)
		{
			if (input < 0) 
			{
				input = input * -1;
			}
			else if(input == 0)
			{
				input = 1;
			}
			return input;
		}
		static string[] addition(Int32 seed)
		{
			Random rnd = new Random (seed);
			Int32 num1 = rnd.Next (0, 1001);
			Int32 num2 = rnd.Next (0, 1001 - num1);
			Int32 num3 = num1 + num2;
			string temp = string.Format("{0}+{1}=",num1.ToString(),num2.ToString());
			string[] reout = new string[2];
			reout[0]=temp;
			temp = string.Format("{0}",num3);
			reout[1] = temp;
			return reout;
		}
		static string[] subtraktion(Int32 seed)
		{
			Random rnd = new Random (seed);
			Int32 num1 = rnd.Next (0, 1001);
			Int32 num2 = rnd.Next (0, num1);
			Int32 num3 = num1 - num2;
			string temp = string.Format("{0}-{1}=",num1.ToString(),num2.ToString());
			string[] reout = new string[2];
			reout[0]=temp;
			temp = string.Format("{0}",num3.ToString());
			reout[1] = temp;
			return reout;
		}
		static string[] multiplikation(Int32 seed)
		{
			Random rnd = new Random (seed);
			Int32 num1 = absnz(rnd.Next (1, 101)-rnd.Next (1, 101));
			Int32 num2 = rnd.Next (1, 1000/num1);
			Int32 num3 = num1 * num2;
			string temp = string.Format("{0}*{1}=",num1.ToString(),num2.ToString());
			string[] reout = new string[2];
			reout[0]=temp;
			temp = string.Format("{0}",num3.ToString());
			reout[1] = temp;
			return reout;
		}
		static string[] division(Int32 seed)
		{
			Random rnd = new Random (seed);
			Int32 num1 = absnz(rnd.Next (1, 101)-rnd.Next (1, 101));
			Int32 num2 = rnd.Next (1,1000/num1)*num1;
			Int32 num3 = num2 / num1;
			string temp = string.Format("{0}/{1}=",num2.ToString(),num1.ToString());
			string[] reout = new string[2];
			reout[0]=temp;
			temp = string.Format("{0}",num3.ToString());
			reout[1] = temp;
			return reout;
		}
	}
}