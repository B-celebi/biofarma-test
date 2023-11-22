using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Soru_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan JSON girişi alma
            Console.WriteLine("JSON girişi girin:");
            string jsonString = Console.ReadLine();

            try
            {
                // JSON stringini C# nesnesine çözme
                List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(jsonString);

                // Kişileri gruplandırma
                var riskyPersons = new List<Person>();
                var risklessPersons = new List<Person>();

                foreach (var person in persons)
                {
                    if (IsRisky(person.Hes))
                    {
                        riskyPersons.Add(new Person { Hes = person.Hes, Status = "risky" });
                    }
                    else
                    {
                        risklessPersons.Add(new Person { Hes = person.Hes, Status = "riskless" });
                    }
                }

                // Gruplanmış kişileri çıktı olarak yazdırma
                Console.WriteLine("Risky Kişiler:");
                PrintPersons(riskyPersons);

                Console.WriteLine("\nRiskless Kişiler:");
                PrintPersons(risklessPersons);
                Console.ReadLine();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Hata: JSON çözme hatası - {ex.Message}");
                Console.ReadLine();
            }
        }

        static bool IsRisky(string hes)
        {
            // Burada Databaseden kontrol etmeliyiz hangisi riskli diye.
            // Şimdilik basit bir mantık ekleyerek devam ediyorum.
            // "G1" ile başlayanlar riskli, diğerleri riskli değil.

            return hes.StartsWith("G1");
        }

        static void PrintPersons(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine($"{{\"hes\":\"{person.Hes}\", \"status\":\"{person.Status}\"}}");
            }
        }
    }
}
