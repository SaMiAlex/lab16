using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace lab16
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = "Products.json";
            Console.WriteLine("Введите количество товаров");
            int n = Convert.ToInt32(Console.ReadLine());
            Goods[] goodsarray = new Goods[n];
            if (!File.Exists(path))//создаем файл
            {
                File.Create(path);
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                //WriteIndented=true
            };
            using (StreamWriter sw = new StreamWriter(path))//пишем массив в файл
            {
                for (int i = 0; i < n; i++)//наполняем массив
                {
                    goodsarray[i] = new Goods();
                    string jsonString = JsonSerializer.Serialize(goodsarray[i], options);
                    sw.WriteLine(jsonString);
                }                
            }
            Console.ReadKey();
        }
    }
    class Goods
    {
        [JsonPropertyName("Артикул")]
        public int Code { get; set; }
        [JsonPropertyName("Название товара")]
        public string Name { get; set; }
        [JsonPropertyName("Цена товара")]
        public double Price { get; set; }
        public Goods()
        {
            try
            {
                Console.WriteLine("Введите код товара");
                Code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                Name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                Price = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}




