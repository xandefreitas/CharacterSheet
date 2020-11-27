using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Refit;
using CharacterSheet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterSheet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var charSpecs = RestService.For<ICaracteristicas>("https://www.dnd5eapi.co/api/");
                Console.WriteLine("Informe raça:");

                string raçaInformada = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações da raça:" + raçaInformada);

                var InfoRaça = await charSpecs.GetAddressAsync(raçaInformada);

                Console.Write($"\nRaça: {InfoRaça.Name}\nEnvelhecimento: {InfoRaça.Age}\nAlinhamento: {InfoRaça.Alignment}\nTamanho: {InfoRaça.Size_description}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Raça não encontrada"+ e.Message);
            }
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
