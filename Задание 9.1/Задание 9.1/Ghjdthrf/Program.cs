using System;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Ghjdthrf
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread task = new Thread(BackgrundBot);
            task.Start();

            for (int i = 0; i < 500; i++)
            {
                Console.Write("+ ");
                Thread.Sleep(50);
            }


        }

        TelegramBotClientPollingExtensions

        static void BackgrundBot()

        {
            string token = "2106928646:AAFdymuquRxs9Z_67uY3kxP8RNk07FPbbTY";


            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

            int update_id = 0;
            string startUrl = $@"https://api.telegram.org/bot{token}/";

            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={update_id}";
                var r = wc.DownloadString(url);

                var msgs = JObject.Parse(r)["result"].ToArray();

                foreach (dynamic msg in msgs)
                {
                    update_id = Convert.ToInt32(msg.update_id) + 1;

                    string userMessage = msg.message.text;
                    string userId = msg.message.from.id;
                    string useFirstrName = msg.message.from.first_name;

                    string text = $"{useFirstrName} {userId} {userMessage}";

                    Console.WriteLine(text);

                    if (userMessage == "hi")
                    {
                        string responseText = $"Здравствуйте, {useFirstrName}";
                        url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        Console.WriteLine("+");
                        wc.DownloadString(url);
                    }
                }


                Thread.Sleep(10);
            }
        }
    }
}

