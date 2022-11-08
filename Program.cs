using System;
using System.Runtime.Intrinsics.Arm;
using MarioHash;

namespace Hashbrowns
{
    class Program
    {
        static void Main(string[] args)
        {
            MainContainer RM = new MainContainer();
            MainContainer.RunMain();
        }
    }

    //This Class may be unnecessary.
    class ParseFile
    {
        public string WordList;

        public ParseFile()
        {

        }
        public ParseFile(string WList)
        {
            WordList = WList;

        }
    }

    class MainContainer
    {
        public static void RunMain()
        {
            string textToEnter = @"



 __  __     ______     ______     __  __     ______     ______     ______     __     __     __   __     ______    
/\ \_\ \   /\  __ \   /\  ___\   /\ \_\ \   /\  == \   /\  == \   /\  __ \   /\ \  _ \ \   /\ ""-.\ \   /\  ___\   
\ \  __ \  \ \  __ \  \ \___  \  \ \  __ \  \ \  __<   \ \  __<   \ \ \/\ \  \ \ \/ "".\ \  \ \ \-.  \  \ \___  \  
 \ \_\ \_\  \ \_\ \_\  \/\_____\  \ \_\ \_\  \ \_____\  \ \_\ \_\  \ \_____\  \ \__/"".~\_\  \ \_\\""\_\  \/\_____\ 
  \/_/\/_/   \/_/\/_/   \/_____/   \/_/\/_/   \/_____/   \/_/ /_/   \/_____/   \/_/   \/_/   \/_/ \/_/   \/_____/ 
                                                                                                                    

                ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));

            Console.WriteLine("What hash would you like to fry? (No Salt)");
            string Hash = Console.ReadLine();

            Console.WriteLine("And what is the algorithm?");

            textToEnter = @"

(1) SHA-1
(2) SHA-2 (512)
(3) SHA-3 (256)
(4) SHA-2 (256)
(5) MD4
(6) MD5
(7) BCRYPT (Coming soon!)
(8) Whirlpool
(9) PBKDF2 (Coming soon!)                                
                                        
                ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            String Algorithm = Console.ReadLine();

            Console.WriteLine("Hash:" + Hash + " Algorithm:" + Algorithm);
            Console.WriteLine("Is this correct? (Y/n)");
            string IsCorrect = Console.ReadLine();

            if (IsCorrect == "Y")
            {
                Console.WriteLine("What is the location of your wordlist?");
                ParseFile parseFile = new ParseFile();
                parseFile.WordList = Console.ReadLine();

                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lines = File.ReadAllLines(@parseFile.WordList);

                if (Algorithm == "1")
                {
                    foreach (string line in lines)
                    {
                        // Hashing code from "https://www.youtube.com/watch?v=tRaFiPRlphs"
                        string HashedLine = MarioHash.MarioHash.Hash_SHA1(line);

                        Console.WriteLine(HashedLine);

                        //Success text if input matches line hash.
                        if (Hash.ToUpper() == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
                else if (Algorithm == "2")
                {
                    foreach (string line in lines)
                    {
                        string HashedLine = MarioHash.MarioHash.Hash_SHA2(line);

                        Console.WriteLine(HashedLine);

                        if (Hash.ToUpper() == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
                else if (Algorithm == "3")
                {
                    foreach (string line in lines)
                    {
                        string HashedLine = MarioHash.MarioHash.Hash_SHA3(line);

                        Console.WriteLine(HashedLine);

                        if (Hash.ToUpper() == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
                else if (Algorithm == "4")
                {
                    foreach (string line in lines)
                    {
                        string HashedLine = MarioHash.MarioHash.Hash_SHA256(line);

                        Console.WriteLine(HashedLine);

                        if (Hash.ToUpper() == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
                else if (Algorithm == "5")
                {
                    foreach (string line in lines)
                    {
                        string HashedLine = MarioHash.MarioHash.Hash_MD4(line);

                        Console.WriteLine(HashedLine);

                        if (Hash.ToUpper() == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
                else if (Algorithm == "6")
                {
                    foreach (string line in lines)
                    {
                        string HashedLine = MarioHash.MarioHash.Hash_MD5(line);

                        Console.WriteLine(HashedLine);

                        if (Hash.ToUpper() == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
                //Upper and lower case letters! DO NOT convert ToUpper()!
                else if (Algorithm == "7")
                {
                    foreach (string line in lines)
                    {
                        string HashedLine = MarioHash.MarioHash.Hash_BCRYPT(line);

                        Console.WriteLine(HashedLine);

                        if (Hash == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
                else if (Algorithm == "8")
                {
                    foreach (string line in lines)
                    {
                        string HashedLine = MarioHash.MarioHash.Hash_Whirlpool(line);

                        Console.WriteLine(HashedLine);

                        if (Hash.ToUpper() == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
                //Upper and lower case letters! DO NOT convert ToUpper()!
                else if (Algorithm == "9")
                {
                    foreach (string line in lines)
                    {
                        string HashedLine = MarioHash.MarioHash.Hash_PBKDF2(line);

                        Console.WriteLine(HashedLine);

                        if (Hash == HashedLine)
                        {
                            Console.WriteLine(line + " is served!");
                            break;
                        }
                    }
                }
            }
            else if (IsCorrect == "n")
            {
                RunMain();
            }
            else
                Console.WriteLine("Invalid Input. Is " + Hash + ":" + Algorithm + " correct?");
            IsCorrect = Console.ReadLine();

        }
    }
}
