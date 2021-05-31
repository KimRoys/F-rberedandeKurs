using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FörberedandeKurs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Visar en meny tills man väljer att avsluta
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        #region Klassen Character
        class Character
        {
            public string name;
            public int health, strength, luck;

            public Character()
            {
                Console.WriteLine("\nSkriv in namnet du valt: ");
                this.name = Console.ReadLine();
                Random rd = new Random();
                int rd_health = rd.Next(50, 300);
                this.health = rd_health;
                int rd_strength = rd.Next(100, 400);
                this.strength = rd_strength;
                int rd_luck = rd.Next(20, 100);
                this.luck = rd_luck;
            }
            public Character(Character newCharacter)
            {
                this.name = newCharacter.name;
                this.health = newCharacter.health;
                this.strength = newCharacter.strength;
                this.luck = newCharacter.luck;

            }
            public void ShowCharacter()
            {
                Console.WriteLine("\n" + this.name + "'s hälsa är: " + this.health);
                Console.WriteLine("\n" + this.name + "s styrka är: " + this.strength);
                Console.WriteLine("\n" + this.name + "s tur är: " + this.luck + "\n");
            }
        }
        #endregion

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Välj uppgift:");
            Console.WriteLine("1) Hälsning");
            Console.WriteLine("2) Vem är du");
            Console.WriteLine("3) Ändra färg");
            Console.WriteLine("4) Dagens datum");
            Console.WriteLine("5) Störst");
            Console.WriteLine("6a) Gissa ett tal");
            Console.WriteLine("6b) Tänk på ett tal");
            Console.WriteLine("7) Spara text");
            Console.WriteLine("8) Hämta text");
            Console.WriteLine("9) Skicka decimaltal");
            Console.WriteLine("10) Multiplikationstabell");
            Console.WriteLine("11) Arrayer");
            Console.WriteLine("12) Palindrom");
            Console.WriteLine("13) Skriv ut siffror");
            Console.WriteLine("14) Sortera siffror");
            Console.WriteLine("15) Addera och skriv ut");
            Console.WriteLine("16) Ange din och motståndarens karaktärer");
            Console.WriteLine("17) Avsluta");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                #region 1 Hello World
                case "1":
                    //Skriv ut en hälsning
                    Console.WriteLine("Hello world");
                    Console.ReadKey();
                    return true;
                #endregion

                #region 2 Vem är du
                case "2":
                    //Vem är du?
                    Console.WriteLine("Vad heter du i förnamn?");

                    String fname = Console.ReadLine();
                    Console.WriteLine("Vad är ditt efternamn?");

                    String lname = Console.ReadLine();
                    Console.WriteLine("Hur gammal är du?");

                    String age = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine(fname + " " + lname + " " + age + " år.");
                    Console.ReadKey();
                    return true;
                #endregion

                #region 3 Ändra färg
                case "3":
                    //Ändra färg
                    if (Console.ForegroundColor == ConsoleColor.Blue)
                    {
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    return true;

                #endregion

                #region 4 Dagens datum
                case "4":
                    //Visa datum som svensk standard sv-SE
                    DateTime dt = DateTime.Now;
                    CultureInfo cultureInfo = new CultureInfo("sv-SE");
                    Console.WriteLine(" \nDagens datum är: " + dt.ToString("d", cultureInfo) + "\n\n");
                    Console.ReadLine();
                    return true;
                #endregion

                #region 5 Största talet
                case "5":
                    //Hämta in två värden, jämför och skriv ut det största värdet
                    Console.WriteLine("Skriv in ett heltal");
                    bool a;
                    int tal1;
                    string input1 = Console.ReadLine();
                    a = int.TryParse(input1, out tal1);
                    if (a == false)
                    {
                        Console.WriteLine("Du måste skriva ett heltal! \nFörsök igen");
                        Console.ReadLine();
                        return true;
                    }

                    Console.WriteLine("Skriv in ett heltal");
                    bool b;
                    int tal2;
                    string input2 = Console.ReadLine();
                    b = int.TryParse(input2, out tal2);
                    if (b == false)
                    {
                        Console.WriteLine("Du måste skriva ett heltal! \nFörsök igen");
                        Console.ReadLine();
                        return true;
                    }
                    if (tal1 > tal2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n" + tal1 + " är det största talet");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n" + tal2 + " är det största talet");
                    }
                    Console.ReadLine();
                    Console.ResetColor();
                    return true;

                #endregion

                #region 6 Gissa ett tal
                case "6a":
                    Console.WriteLine("Gissa vilket tal mellan 1 och hundra som slumpats fram.");
                    Random rd = new Random();
                    int rd_num = rd.Next(0, 101);
                    //Hämta in det gissade talet och jämför med randomtalet
                    Console.WriteLine("Välj ett tal att gissa på.");
                    bool res;
                    string myStr = Console.ReadLine();
                    res = int.TryParse(myStr, out int guess);
                    if (res == true)
                    {
                        if (guess == rd_num)
                        {
                            Console.WriteLine("Du gissade rätt! Talet är " + rd_num);
                        }
                        else
                        {
                            //Skapa en loop som körs tills gissningen är rätt
                            while (guess != rd_num)
                            {
                                if (guess > rd_num)
                                {
                                    Console.WriteLine("Din gissning var för högt, gissa igen!");
                                    myStr = Console.ReadLine();
                                    res = int.TryParse(myStr, out guess);

                                }
                                else
                                {
                                    Console.WriteLine("Din gissning var för låg, gissa igen");
                                    myStr = Console.ReadLine();
                                    res = int.TryParse(myStr, out guess);
                                }

                            }
                        }
                    }
                    Console.WriteLine("Grattis! Din gissning " + guess + " var rätt");
                    Console.ReadLine();
                    return true;

                case "6b":
                    //Tänk på ett tal
                    Console.WriteLine("Tänk på ett tal mellan 1 och 100. Tryck Enter när du är klar.");
                    Console.ReadLine();

                    int guessCounter = 0; //Antal gissningar.Startar på 0 vid första försöket.
                    int tal = 50; //Första gissningen startar på 50
                    int guessLower, guessHigher; //Två värden för att lättare hålla reda på gissningarna
                    int max = 101;
                    int min = 1;
                    int result;
                    bool loop = true;
                    //Skapa en loop som körs tills gissningen är rätt
                    do
                    {
                        Console.WriteLine("Jag gissar på {0}", tal);
                        //Skriv ut menyn
                        Console.WriteLine("Tryck [21] om det är rätt tal\n");
                        Console.WriteLine("Tryck [22] om ditt tal är lägre\n");
                        Console.WriteLine("Tryck [23] om ditt tal är högre\n");
                        Console.WriteLine("Avsluta med Enter\n");

                        guessCounter++; // Öka med en gissning för varje försök

                        int num1;
                        string s = Console.ReadLine(); //Användarens val
                        res = int.TryParse(s, out num1);
                        if (res == false)
                        {
                            //Inmatningen är inte ett nummer
                            Console.WriteLine("Felaktig inmatning, du måste skriva ett tal mellan 21 och 23\nTryck Enter för att fortsätta.");
                            Console.ReadKey();
                            Console.WriteLine("\n");

                            continue;
                        }
                        int menyVal = int.Parse(s);

                        switch (menyVal)
                        {
                            case 21:
                                result = tal;
                                //Gissningen är rätt
                                Console.WriteLine("\nHurra! Jag gissade rätt på {0} försök. Rätt tal är: {1}", guessCounter, tal);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ReadLine();
                                loop = false; //Avslutar loopen
                                return true;

                            case 22:

                                max = tal;
                                //Användarens tal är lägre
                                guessLower = (tal + min) / 2;
                                tal = guessLower;

                                break;

                            case 23:

                                min = tal;
                                //Användarens tal är högre
                                guessHigher = (max + min) / 2;
                                tal = guessHigher;
                                break;

                            default:
                                Console.WriteLine("Ogiltigt val!");
                                break;
                        }
                    } while (loop);
                    Console.ReadLine();
                    return true;

                #endregion

                #region 7 Spara text
                case "7":
                    try
                    {
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string filepath = path + "\\Test.txt";
                        //Skicka filinfo till StreamWriter Constructor
                        StreamWriter sw = new StreamWriter(filepath);
                        //Skriv in lite text
                        Console.WriteLine("Skriv in lite text här!");
                        sw.WriteLine(Console.ReadLine());
                        //Skriv en rad text till
                        Console.WriteLine("Skriv en rad text till");
                        sw.WriteLine(Console.ReadLine());
                        //Close the file
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Sparar till filen");
                    }
                    Console.ReadLine();
                    return true;

                #endregion

                #region 8 Hämta text
                case "8":
                    String line;
                    try
                    {
                        //Sätt Filsökvägen till användarens skrivbord på datorn
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string filepath = path + "\\Test.txt";
                        //skicka filens sökväg och namn till StreamReader constructor
                        StreamReader sr = new StreamReader(filepath);
                        //Läs första textraden
                        line = sr.ReadLine();
                        //Fortsätt läs textrader tills filen är slut
                        while (line != null)
                        {
                            //Skriv ut textraden på console
                            Console.WriteLine("\n" + line);
                            //Läs nästa rad
                            line = sr.ReadLine();
                        }
                        //Stäng filen
                        sr.Close();
                        Console.ReadLine();
                    }
                    //Fångar upp ev. fel
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Slut på text i filen");
                    }
                    Console.ReadLine();
                    return true;

                #endregion

                #region 9 Skicka decimaltal
                case "9":
                    //Hämta in ett decimaltal från användaren
                    Console.WriteLine("Skriv in ett decimaltal.");
                    double myNum;
                    myStr = Console.ReadLine();
                    res = double.TryParse(myStr, out myNum);
                    double rotNum;
                    //Om anv. har skrivit in ett korrekt decimaltal
                    if (res == true)
                    {
                        //Tar roten ur anv. tal
                        rotNum = Math.Sqrt(myNum);
                        //Talet upphöjt till 2
                        double uhNum = Math.Pow(myNum, 2);
                        //Talet upphöjt till 10
                        double tioNum = Math.Pow(myNum, 10);
                        //Skriv ut svaren
                        Console.WriteLine("\nRoten ur ditt tal " + myNum + " är: " + rotNum);
                        Console.WriteLine("\nDitt tal " + myNum + " upphöjt till 2 är: " + uhNum);
                        Console.WriteLine("\nDitt tal " + myNum + " upphöjt till 10 är: " + tioNum);
                    }
                    else
                    {
                        Console.WriteLine("Du måste skriva in ett siffertal.");
                    }
                    Console.ReadLine();
                    return true;

                #endregion

                #region 10 Multiplikationstabell
                case "10": int numVal;
                    do
                    {
                        //Hämta in en siffra mellan 1 och 10
                        Console.WriteLine("Välj med en siffra mellan 1 och 10, vilken tabell du vill ha utskriven\n");
                        myStr = Console.ReadLine();
                        res = int.TryParse(myStr, out numVal);
                        if (numVal < 1 || numVal > 10)
                        {
                            Console.WriteLine("\nSiffran måste vara mellan 1 och 10\n");
                        }
                    } while (numVal < 1 || numVal > 10);

                    //visa gångertabellen för den valda siffran
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.WriteLine("\n");
                        Console.Write(String.Format("{0,6}", i));
                        string output = " * " + numVal + " =" + String.Format(" {0, 6 }", i * numVal);
                        Console.Write(output);
                    }



                    Console.ReadLine();

                    return true;

                #endregion

                #region 11 Arrayer
                case "11":
                    // Skapa en array av random tal
                    int rdMin = 0;
                    int rdMax = 100;

                    int[] myNumArray = new int[20];
                    int myRdInt;
                    Random random = new Random();
                    Console.WriteLine("\nMin array av random tal:\n");
                    for (int i = 0; i < myNumArray.Length; i++)
                    {
                        myRdInt = random.Next(rdMin, rdMax);
                        myNumArray[i] = myRdInt;
                        Console.WriteLine(myRdInt);
                    }
                    Console.WriteLine("\nMin array av sorterade tal:\n");
                    int[] mySortedArr = myNumArray;
                    Array.Sort(mySortedArr);
                    foreach (int i in mySortedArr)
                    {
                        Console.WriteLine(i);
                    }
                    Console.ReadLine();
                    return true;

                #endregion

                #region 12 Palindrom
                case "12":
                    //Hämtar in ett ord från användaren och kontrollerar om det är en palindrom
                    Console.WriteLine("Skriv in ett ord");
                    string myWord, r;
                    myWord = Console.ReadLine();
                    char[] chars = myWord.ToCharArray();
                    Array.Reverse(chars);
                    r = new string(chars);
                    bool testBool = myWord.Equals(r, StringComparison.OrdinalIgnoreCase);
                    if (testBool == true)
                    {
                        Console.WriteLine("\nDitt ord: " + myWord + " är en Palindrom.");
                    }
                    else
                    {
                        Console.WriteLine("\nDitt ord: " + myWord + " är inte en Palindrom.");
                    }
                    Console.ReadLine();
                    return true;

                #endregion

                #region 13 Skriv ut siffror
                case "13":
                    //Tar in två tal från användaren och skriver ut alla siffror mellan dessa
                    int nr1;
                    int nr2;
                    Console.WriteLine("Du ska få välja två nummer varpå alla siffror \n" +
                        "mellan dessa kommer skrivas ut på skärmen.");
                    Console.WriteLine("Skriv in din första siffra och tryck Enter\n");
                    res = int.TryParse(Console.ReadLine(), out nr1);
                    if (res == true)
                    {
                        Console.WriteLine("\nSkriv in din andra siffra och tryck Enter\n");
                        res = int.TryParse(Console.ReadLine(), out nr2);
                        if (res == true)
                        {
                            Console.WriteLine("\n");
                            if (nr1 < nr2)
                            {
                                for (int i = nr1; i < nr2; i++)
                                {
                                    if (i > nr1)
                                    {
                                        Console.WriteLine(i);
                                    }
                                }
                            }
                            else
                            {
                                for (int i = nr1; i > nr2; i--)
                                {
                                    if (i < nr1)
                                    {
                                        Console.WriteLine(i);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Du måste skriva in ett tal!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du måste skriva in ett tal!");
                    }
                    Console.ReadLine();

                    return true;

                #endregion

                #region 14 Sortera siffror
                case "14":
                    //Tar in ett antal värden (komma-separerade siffror) från användaren som sedan
                    //sorteras och skrivs ut efter udda och jämna värden mha Linq
                    Console.WriteLine("Skriv in så många tal du vill, måste skrivas med ett komma mellan varje tal");
                    int[] input = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                    //Skriver ut de jämna siffrorna
                    Console.WriteLine("\nDina jämna siffror är:\n");
                    foreach (var item in input.Where((item, index) => item % 2 == 0))
                    {
                        Console.WriteLine(item);
                    }

                    //Skriver ut de ojämna siffrorna
                    Console.WriteLine("\nDina ojämna siffror är:\n");
                    foreach (var item in input.Where((item, index) => item % 2 != 0))
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadLine();
                    return true;

                #endregion

                #region 15 Addera och skriv ut
                case "15":
                    //Tar in ett antal värden (komma-separerade siffror) från användaren som sedan
                    //adderas och skrivs ut mha Linq
                    Console.WriteLine("Skriv in så många tal du vill, måste skrivas med ett komma mellan varje tal");
                    int[] inTal = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                    int sum = inTal.Sum();
                    Console.WriteLine("Summan av dina tal är: " + sum);
                    Console.ReadLine();
                    return true;

                #endregion

                #region 16 Ange din och motståndarens karaktärer
                case "16":
                    /*Funktion där användaren ska ange namnet på sin karaktär och namnet på en motståndare.
                    Funktionen skall sedan själv lägga till slumpmässiga värden för Hälsa, Styrka och Tur, som
                    sparas i en instans av en klass.*/
                    Console.WriteLine("\nDu kommer att få skriva in två namn.\n");
                    Console.WriteLine("Det första är din egen karaktär och det andra din motståndare\n");
                    Console.WriteLine("Tryck Enter för att fortsätta!");
                    Console.ReadLine();
                    Character myCharacter = new Character();
                    Character enemyCharacter = new Character();
                    myCharacter.ShowCharacter();
                    enemyCharacter.ShowCharacter();
                    Console.ReadLine();

                    return true;

                #endregion

                #region 17 Avsluta
                case "17":
                    return false;
                #endregion
                default:
                    return true;

            }

        }

    }
    
}
 
