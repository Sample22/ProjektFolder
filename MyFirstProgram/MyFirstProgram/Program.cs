using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;


namespace MyFirstProgram {
    class Program {
        static void Main(string[] args) {
            //WorkSpace Start

            string exeName = "CSGO.exe";
            string HWID = "BFEBFBFF000306C3";

            Process[] pname = Process.GetProcessesByName(exeName); // Kigger exeName variablen og ser hvad der står i den.


            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor"); // Laver en ny Management class der kigger på win32_processor, altså computerens cpu
            ManagementObjectCollection moc = mc.GetInstances(); // Får alt information om CPUen

            foreach (ManagementObject mo in moc) {
                if (cpuInfo == "") {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }


            if (cpuInfo == HWID) {




                Console.WriteLine("Bunny Hoppingz V1 by Sample" + " HWID: " + cpuInfo);
                Console.WriteLine(" "); // Mellemrum i konsollen
                Console.WriteLine("Please Enter Your Credentials:");
                Console.WriteLine(" ");
            Line1: Console.Write("Username: ");
                string user = Console.ReadLine(); // Læser hvad man har skrevet i Username, og gemmer det i en variabel kaldet user
                Console.Write("Password: ");
                string pw = Console.ReadLine();
                if (user == "Sample" && pw == "1234")  // Tjekker om man har skrevet username og password rigtigt. Hvis man har, så går den videre, ellers SKRIVER den INVALID CREDENTIALS og hopper tilbage til login skærmen.
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Logged in as: " + user);
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to start injecting..");
                    Console.ReadKey();
                    Console.Clear();


                    if (pname.Length == 0) {
                        Console.Beep();
                        Console.WriteLine(exeName + " is not running! Launch " + exeName + " first!");
                    }
                    else
                        Console.WriteLine(exeName + " was found!" + " Hack was injected sucessfully!");
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to terminate..");
                    goto Line2;


                }
                else
                    Console.WriteLine(" ");
                Console.WriteLine("ERROR: INVALID CREDENTIALS");
                Console.WriteLine(" ");
                goto Line1;



            Line2: Console.ReadKey();


            }
            else

                Console.WriteLine("HWID not registered! Contact the seller of the software.");
            Console.ReadKey();
            //Workspace Slut
        }
    }
}
