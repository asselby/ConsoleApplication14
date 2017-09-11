/*1.	Прочитать содержимое XML файла со списком последних новостей по ссылке https://habrahabr.ru/rss/interesting/
Создать класс Item со свойствами: Title, Link, Description, PubDate.
Создать коллекцию типа List<Item> и записать в нее данные из файла.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace XMLhw
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> itemList = new List<Item>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("https://habrahabr.ru/rss/interesting/");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Item item = new Item();
                XmlNode attrFirst = xnode.Attributes.GetNamedItem("item");
                if (attrFirst != null)
                    item.Title = attrFirst.Value;
               
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "title")
                        item.Title = childnode.InnerText;
                    if (childnode.Name == "link")
                        item.Link = childnode.InnerText;
                    if (childnode.Name == "description")
                        item.Description = childnode.InnerText;
                    if (childnode.Name == "pubDate")
                        item.PubDate = DateTime.Parse(childnode.InnerText);
                }
                itemList.Add(item);
            }
            foreach (Item i in itemList)
                Console.WriteLine("Title - {0}; \n Link - ({1};\n Description - {2}; \n PubDate - {3}", i.Title, i.Link, i.Description, i.PubDate);
                Console.ReadLine();
        }
    }
}
