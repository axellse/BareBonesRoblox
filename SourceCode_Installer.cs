using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BareBonesRobloxInstaller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BareBonesRoblox Installer, Written by Axelan_se
            //https://axell.me

            bool foundinstall = false;

            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Roblox\Versions");
            foreach (string robloxversiondir in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Roblox\Versions"))
            {
                if (Directory.Exists(robloxversiondir + @"\content"))
                {
                    if (File.Exists(robloxversiondir + @"\RobloxPlayerLauncher.exe"))
                    {
                        foundinstall = true;
                        //finidng roblox install
                        Console.WriteLine("Found Roblox Installation at " + robloxversiondir);
                        Console.WriteLine("Installing Content ...");



                        //install bootstrapper
                        if (File.Exists(robloxversiondir + @"\RobloxPlayerLauncher.exe"))
                        {
                            File.Delete(robloxversiondir + @"\RobloxPlayerLauncher.exe");
                            Console.WriteLine("Removed Stock Bootstrapper");
                        }
                        try
                        {
                            using (var client = new WebClient())
                            {
                                client.DownloadFile("https://github.com/Axelanse/BareBonesRoblox/raw/main/RobloxPlayerLauncher.exe", robloxversiondir + @"\RobloxPlayerLauncher.exe");
                                Console.WriteLine("downloaded successfully");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to download Bootstrapper. Error: " + ex);
                        }
                        Console.Clear();
                        Console.WriteLine("BareBonesRoblox Has been successfully installed!");
                        Console.WriteLine("you can now close this window!");
                        Console.ReadKey();

                    }
                }
            }


            if (foundinstall == false)
            {
                Console.Clear();
                Console.WriteLine("No roblox installation found in appdata! searching programs 86");
                foreach (string robloxversiondir in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Roblox\Versions"))
                {
                    if (Directory.Exists(robloxversiondir + @"\content"))
                    {
                        if (File.Exists(robloxversiondir + @"\RobloxPlayerLauncher.exe"))
                        {
                            foundinstall = true;
                            //finidng roblox install
                            Console.WriteLine("Found Roblox Installation at " + robloxversiondir);
                            Console.WriteLine("Installing Content ...");



                            //install bootstrapper
                            if (File.Exists(robloxversiondir + @"\RobloxPlayerLauncher.exe"))
                            {
                                File.Delete(robloxversiondir + @"\RobloxPlayerLauncher.exe");
                                Console.WriteLine("Removed Stock Bootstrapper");
                            }
                            try
                            {
                                using (var client = new WebClient())
                                {
                                    client.DownloadFile("https://github.com/Axelanse/BareBonesRoblox/raw/main/RobloxPlayerLauncher.exe", robloxversiondir + @"\RobloxPlayerLauncher.exe");
                                    Console.WriteLine("downloaded successfully");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Failed to download Bootstrapper. Error: " + ex);
                            }
                            Console.Clear();
                            Console.WriteLine("BareBonesRoblox Has been successfully installed!");
                            Console.WriteLine("you can now close this window!");
                            Console.ReadKey();

                        }
                    }
                }

            }
        }
    }
}
