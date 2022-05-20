using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Threading;
using Telegram.Bot.Exceptions;
//using Telegram.Bot.Extensions.Polling;
//using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
//using Microsoft.ServiceBus.Messaging;

namespace Задание_9._1
{
    class Program
    {
        static TelegramBotClient bot;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь для доступа к токену");
            //string puthToken = Console.ReadLine();
            //while (puthToken == null || !File.Exists(puthToken))
            //{
            //    Console.WriteLine("Значение не введено, или нет доступа к файлу. Введите заново:");
            //    puthToken = Console.ReadLine();
            //}
            //string token = File.ReadAllText($@"{puthToken}");
            string token = File.ReadAllText(@"D:\Диск\YandexDisk\Skilbox\Домашние Задания\Задание 9.1\Token.txt");

            #region exc

            //// https://hidemyna.me/ru/proxy-list/?maxtime=250#list

            // Содержит параметры HTTP-прокси для System.Net.WebRequest класса.
            //var proxy = new WebProxy()
            //{
            //    Address = new Uri($"http://172.67.181.200"),
            //    UseDefaultCredentials = false,
            //    //Credentials = new NetworkCredential(userName: "login", password: "password")
            //};

            //// Создает экземпляр класса System.Net.Http.HttpClientHandler.
            //var httpClientHandler = new HttpClientHandler() { Proxy = proxy };

            //// Предоставляет базовый класс для отправки HTTP-запросов и получения HTTP-ответов 
            //// от ресурса с заданным URI.
            //HttpClient hc = new HttpClient(httpClientHandler);

            //bot = new TelegramBotClient(token, hc);

            #endregion

            bot = new TelegramBotClient(token);

            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            Console.ReadKey();


        }

        private static void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            string text = $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            Console.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
            {
                Console.WriteLine(e.Message.Document.FileId);
                Console.WriteLine(e.Message.Document.FileName);
                Console.WriteLine(e.Message.Document.FileSize);
                               
                DownLoad(e.Message.Document.FileId, e.Message.Document.FileName, e.Message.Chat.Id);
            }

            if (e.Message.Text == null) return;

            var messageText = e.Message.Text;


            bot.SendTextMessageAsync(e.Message.Chat.Id,
                $"{messageText}"
                );
        }

        static async void DownLoad(string fileId, string path, long chat_id)
        {
            var file = await bot.GetFileAsync(fileId);
            FileStream fs = new FileStream(@"D:\23\" + path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);

           var sendFile = await bot.SendDocumentAsync(chat_id, file.FilePath, 
    "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>"
    /*parseMode: ParseMode.Html*/);

            fs.Close();

            fs.Dispose();
        }

        //static void SendFile(string Token)
        //{
        //    WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

        //    int update_id = 0;
        //    string startUrl = "https://api.telegram.org/bot{token}/";

        //    string url = $"{startUrl}getUpdates?offset={update_id}";
        //    var r = wc.DownloadString(url);

        //    var msgs = JObject.Parse(r)["result"].ToArray();
        //    foreach (dynamic msg in msgs)
        //    {
        //                       update_id = Convert.ToInt32(msg.update_id) + 1;

        //        string userMessage = msg.message.text;
        //        string userId = msg.message.from.id;
        //        string useFirstrName = msg.message.from.first_name;

        //        string text1 = $"{useFirstrName} {userId} {userMessage}";

        //        Console.WriteLine(text1);
        //        if (userMessage == "hi")
        //        {
        //            string responseText = $"Возвращаем вам файл, {useFirstrName}";
        //            string fileUrl = "https://api.telegram.org/file/bot<token>/<file_path>";
        //            string file_id = "";
        //            url = $"{fileUrl}sendMessage?file_id={file_id}";
        //            Console.WriteLine("+");
        //            wc.DownloadFile(url, );
        //        }
        //    }

        //    Console.WriteLine("+");

        //}
    }
}



