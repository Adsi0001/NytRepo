using System.Runtime.Intrinsics.X86;

namespace BinaryConverter
{
    internal class Program
    {
        static void Main(String[] args)
        {
            //Gentag programmet indtil brugeren siger stop
            bool gentag = true;

            while (gentag)
            {
                //Præsenter programmet for brugeren
                Console.WriteLine("Binær Kodeomformer");
                Console.WriteLine("");

                //Her kan brugeren vælge programmets funktion
                Console.WriteLine("Vælg en funktion:");
                Console.WriteLine("");
                Console.WriteLine("1. Binær til Decimal");
                Console.WriteLine("2. Decimal til Binær");
                Console.WriteLine("");
                Console.Write("Indtast dit valg (1 eller 2): ");
                string valg = Console.ReadLine();

                if (valg == "1")
                {
                    //Indtast binær streng fx 11101101 SKAL vise 8 cifre
                    //Tjek at input er gyldigt
                    //Tjek at længden på input er 8 cifre, hvis ikke så meld fejl
                    //Tjek at input kun er 1 og 0-taller, hvis ikke så meld fejl
                    //Konverter gyldigt input til binArr
                    //Definer værdierne i binArr. 1 = true - 0 = false
                    //Input skal være 1 og 0-taller, hvis ikke så meld fejl
                    //Input skal være 8 cifre, hvis ikke så meld fejl

                    Console.WriteLine("Indtast en binær streng på 8 cifre: ");
                    string binInput = Console.ReadLine();
                    bool er8cifre = true;

                    if (binInput.Length != 8)
                    {
                        Console.WriteLine("Fejl: Binær streng skal være 8 cifre. ");
                        er8cifre = false;
                    }

                    for (int i = 0; i < binInput.Length; i++)
                    {
                        if (binInput[i] != '0' && binInput[i] != '1')
                        {
                            Console.WriteLine("Fejl: Binær streng må kun indeholde 0 og 1.");
                        }
                    }

                    bool[] binArr = new bool[8];

                    //Lav binInput til et array hvor 1 er true og 0 er false
                    for (int i = 0; i < binInput.Length; i++)
                    {
                        if (binInput[i] == '1')
                        {
                            binArr[i] = true; // Sæt true (1)
                        }
                        else
                        {
                            binArr[i] = false; // Sæt false (0)
                        }
                    }
                    int decValue = 0;

                    for (int i = 0; i < binArr.Length; i++)
                    {
                        // Hvis den aktuelle bit er true (1), læg værdien af denne bit til
                        if (binArr[i])
                        {
                            decValue = decValue * 2 + 1;
                        }
                        else
                        {
                            decValue = decValue * 2;
                        }
                    }
                    Console.WriteLine("Binær streng: " + binInput + ".");
                    Console.WriteLine("Decimal værdi: " + decValue + ".");
                    Console.WriteLine("");
                }
                else if (valg == "2")
                {
                    //Indtast decimal streng fx 83 (max 255)
                    //Konverter til binær streng der SKAL vise 8 cifre
                    //Tjek om tallene går op i hinanden ligesom NetworkChucks video
                    //Præsenter en binær linje til sidst

                    //Modulus og Division: Vi bruger % (modulus) for at finde den sidste bit (0 eller 1) af tallet, og / (division) for at reducere tallet, indtil det er 0.
                    //Bygning af binærstrengen: Binærstrengen bygges fra højre mod venstre ved at tilføje bittene forrest i strengen.                

                    Console.WriteLine("Indtast et decimaltal mellem 0 og 255: ");
                    int decimalTal = int.Parse(Console.ReadLine());

                    if (decimalTal < 0 || decimalTal > 255)
                    {
                        Console.WriteLine("Tallet skal være mellem 0 og 255.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        string binærtTal = "";

                        if (decimalTal == 0)
                        {
                            binærtTal = "0";
                        }
                        else
                        {
                            while (decimalTal > 0)
                            {
                                binærtTal = (decimalTal % 2) + binærtTal;
                                decimalTal = decimalTal / 2;
                            }
                        }
                        //Tilføj flere nuller hvis binærtTal er mindre end 8 cifre
                        //Tjek længden og bliv ved med at tilføje nuller til binærtTal er 8 cifre
                        int antalNuller = 8 - binærtTal.Length;
                        for (int i = 0; i < antalNuller; i++)
                        {
                            binærtTal = 0 + binærtTal;
                        }
                        Console.WriteLine("Decimaltal input: " + decimalTal + ".");
                        Console.WriteLine("Binær værdi: " + binærtTal + ".");
                        Console.WriteLine("");
                    }
                }
                else Console.WriteLine("Ugyldigt valg. Tast enten 1 eller 2.");
            }
            Console.WriteLine("Vil du gentage programmet? (ja/nej)");
            string svar = Console.ReadLine().ToLower(); // Læs brugerens svar og gør det til små bogstaver

            // Hvis svaret er ikke 'ja', afslut programmet
            if (svar != "ja")
            {
                gentag = false; // Sæt gentag til false for at stoppe løkken
                Console.WriteLine("Programmet afsluttes.");
            }
        }
    }
}
