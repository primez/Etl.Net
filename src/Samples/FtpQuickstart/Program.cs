﻿using Paillave.Etl;
using Paillave.Etl.Core.Streams;
using Paillave.Etl.Ftp;
using System;

namespace FtpQuickstart
{
    class Program
    {
        public class SimpleConfig
        {
            public FtpConnectionInfo ConnectionInfo { get; set; }
            public string Folder { get; set; }
        }
        public class FtpQuickstartJob : IStreamProcessDefinition<SimpleConfig>
        {
            public string Name => "FtpTest";

            public void DefineProcess(IStream<SimpleConfig> rootStream)
            {
                rootStream.CrossApplyFtpFiles("get file from ftp", rootStream.Select("get ftp cnx", i => i.ConnectionInfo), i => i.Folder)
                    .ToAction("write to console", i => Console.WriteLine(i.Name));
            }
        }
        static void Main(string[] args)
        {
            new StreamProcessRunner<FtpQuickstartJob, SimpleConfig>().ExecuteAsync(new SimpleConfig
            {
                ConnectionInfo = new FtpConnectionInfo
                {
                    Login = "test",
                    Password = "test",
                    Server = "localhost"
                },
                Folder = "SubFolder"
            }, null).Wait();
            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}
