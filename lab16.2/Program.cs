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
            string jsonString = "";
            double maxprice = 0;
            
            using (StreamReader sr = new StreamReader(path))
            {
                jsonString = sr.ReadToEnd();
            }
            
            Goods good = JsonSerializer.Deserialize<Goods>(jsonString); //не могу понять как из json файла достать полноценный массив, с которым можно потом работать

            /*for (int i = 0; i < good.Length; i++)
            {
                if (maxprice < good.price)
                {
                    maxprice = good.price;
                }
            }*/
            Console.WriteLine(maxprice);
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
