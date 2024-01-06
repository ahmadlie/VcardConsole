using Newtonsoft.Json;
using VcardTask.Helper;
using VcardTask.Models;

namespace VcardTask;
class Program
{

    static async Task Main()
    {
        VCardService _vCardService = new VCardService();
        string apiUrl = "https://api.randomuser.me";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                Console.Write("Enter how many times the Vcard will be generated : ");
                int count = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        VCard vCard = CustomJsonConverter.Convert(jsonString);
                        VCardService.AddToList(vCard);
                        string vcardAsString = VCardService.GetVCard(i);

                        VCardService.Save(vcardAsString, i);
                        Console.WriteLine("VCard Saccessfully Saved!");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                string vCards = VCardService.GetVCards();
                Console.WriteLine(vCards);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
