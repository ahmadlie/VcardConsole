using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using VcardTask.Models;

namespace VcardTask.Helper
{
    public class VCardService
    {
        public VCardService()
        {
            VCards = new List<VCard>();
        }

        public static List<VCard> VCards { get; set; }
        public static void AddToList(VCard vCard) => VCards.Add(vCard);


        //This method returns all Vcards as string
        public static string GetVCards()
        {
            string vCard = "";
            foreach (VCard card in VCards)
            {
                vCard += "-----------------------\nBEGIN:VCARD\nVERSION:3.0\n";
                vCard += $"FN:{card.FirstName} {card.LastName}\n";
                vCard += $"EMAIL:{card.Email}\n";
                vCard += $"TEL:{card.Phone}\n";
                vCard += $"ADR;TYPE=WORK:;;{card.City};;{card.Country}\n";
                vCard += $"UID:{card.Id}\n";
                vCard += "END:VCARD\n-----------------------";
            }
            return vCard;
        }


        //This method returns a Vcard as string according to the given id value
        public static string GetVCard(int id)
        {
            VCard card = VCards[id];
            string vCard = "";
            vCard += "-----------------------\nBEGIN:VCARD\nVERSION:3.0\n";
            vCard += $"FN:{card.FirstName} {card.LastName}\n";
            vCard += $"EMAIL:{card.Email}\n";
            vCard += $"TEL:{card.Phone}\n";
            vCard += $"ADR;TYPE=WORK:;;{card.City};;{card.Country}\n";
            vCard += $"UID:{card.Id}\n";
            vCard += "END:VCARD\n-----------------------";
            return vCard;
        }


        //This method Vcard save as vcf file
        public static void Save(string data, int number)
        {
            bool isTrue = true;
            string path;
            string folder = @"D:\VcardData\";
            while (isTrue)
            {
                Console.Write($"Please enter the {number + 1}. file name in the vcf format : ");
                string fileName = Console.ReadLine();
                int indexOfPoint = fileName.LastIndexOf('.');
                if (indexOfPoint == -1)
                {
                    Console.WriteLine("Please enter file extension!");
                    continue;
                }
                else
                {
                    string fileExtension = fileName.Substring(indexOfPoint + 1);
                    if (fileExtension != "vcf")
                    {
                        Console.WriteLine("Plese enter in correct format!");
                        continue;
                    }
                    else
                    {
                        path = folder + fileName;
                        if (!File.Exists(path))
                        {
                            File.WriteAllText(path, data);
                            isTrue = false;
                        }
                        else
                        {
                            Console.WriteLine("This file name already exists!");
                            continue;
                        }
                    }
                }

            }
        }
    }
}
