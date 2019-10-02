using Logger.Core;
using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();

            AppenderFactory appenderFactory = new AppenderFactory();

            ReadAppendersData(appendersCount, appenders, appenderFactory);

            ILogger logger = new Logger.Models.Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int appendersCount, ICollection<IAppender> appenders, AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendesInfo = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                string appenderType = appendesInfo[0];
                string layoutType = appendesInfo[1];
                string levelStr = "INFO";
                if (appendesInfo.Length == 3)
                {
                    levelStr = appendesInfo[2];
                }
                
                try
                {
                    IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelStr);
                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    //Output neede?
                    Console.WriteLine(e.Message);
                    continue;
                }
               
            }
        }
    }
}
