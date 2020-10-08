using System;
using Antecipa.Trainning.CrossCutting;

namespace Antecipa.Trainning.Infrastructure
{
    public class Logger: ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}