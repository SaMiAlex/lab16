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

namespace lab16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Products.json";
            double maxprice = 0;
            string goodName = "";
            Goods good = new Goods(0,"",0);

            using (StreamReader sr = new StreamReader(path))
            {
                for (int i = 0; i < 5; i++)
                {
                    string line = sr.ReadLine();
                    good = JsonSerializer.Deserialize<Goods>(line);
                    if (maxprice<good.Price)
                    {
                        maxprice = good.Price;
                        goodName = good.Name;
                    }                                      
                }
            }
            Console.WriteLine("Самый дорогой товар в списке - {0}",goodName);
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
        public Goods(int code, string name, double price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
    }
}
