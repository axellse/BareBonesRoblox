using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace urlprotocoltest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BareBonesRoblox, Written By Axell
            //www.axell.me


            string channel = "LIVE"; // Channel if allowcustomchannel is false
            bool allowcustomchannel = false; //prompt the user for a custom channel.

            Console.Title = "BareBonesRoblox";
            Console.WriteLine(@"  ____                 ____                        _____       _     _           ");
            Console.WriteLine(@" |  _ \               |  _ \                      |  __ \     | |   | |          ");
            Console.WriteLine(@" | |_) | __ _ _ __ ___| |_) | ___  _ __   ___  ___| |__) |___ | |__ | | _____  __");
            Console.WriteLine(@" |  _ < / _` | '__/ _ \  _ < / _ \| '_ \ / _ \/ __|  _  // _ \| '_ \| |/ _ \ \/ /");
            Console.WriteLine(@" | |_) | (_| | | |  __/ |_) | (_) | | | |  __/\__ \ | \ \ (_) | |_) | | (_) >  < ");
            Console.WriteLine(@" |____/ \__,_|_|  \___|____/ \___/|_| |_|\___||___/_|  \_\___/|_.__/|_|\___/_/\_\");
            Console.WriteLine("Welcome to BareBonesRoblox.");
            if (allowcustomchannel == true)
            {
                channel = Console.ReadLine();
            }
            Console.WriteLine("Checking For Roblox Updates... Channel=LIVE");
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("https://clientsettings.roblox.com/v2/client-version/WindowsPlayer/channel/LIVE?binaryType=WindowsPlayer");

            string webData = System.Text.Encoding.UTF8.GetString(raw);
            Console.WriteLine("newest version has guid " + webData.Split('"')[7].Replace("version-", ""));

            Console.WriteLine("You have version " + Path.GetFileName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("version-", "")));
            if (webData.Split('"')[7] == Path.GetFileName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                Console.WriteLine("You are running the newst version!");
            }
            else
            {
                Console.WriteLine("You are not running the latest version. Switch to another bootstrapper to update if you want.");
               
            }
            Console.WriteLine("Getting Parameters...");

            try
            {
                //no support for deeplinking or anything like that, this is bare bones after all
                //start robloxplayer
                string par = "--app " +
                    "-t " +
                    args[0].Split('+')[2].Replace("gameinfo:", "") +
                    " -j " +
                    Uri.UnescapeDataString(args[0].Split('+')[4].Replace("placelauncherurl:", "")) +
                    " -b " +
                    args[0].Split('+')[5].Replace("browsertrackerid:", "") +
                    " --launchtime=" + args[0].Split('+')[3].Replace("launchtime:", "") +
                    " --rloc " +
                    args[0].Split('+')[6].Replace("robloxLocale:", "") +
                    " --gloc " + args[0].Split('+')[7].Replace("gameLocale:", "");
                Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\RobloxPlayerBeta.exe", par);
                Console.WriteLine("Starting Roblox...");
                Console.WriteLine();
                Thread.Sleep(5000);
                Application.Exit();
            }
            catch
            {
                if (args.Length > 0)
                {
                    Console.WriteLine("Checking Arguments...");
                    if (args[0] == "-uninstall")
                    {
                        Application.Run(new UninstallPrompt());

                    }
                    else
                    {
                        Console.WriteLine("Starting as app...");
                        Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\RobloxPlayerBeta.exe");
                    }
                }
            }
        }
    }
}
