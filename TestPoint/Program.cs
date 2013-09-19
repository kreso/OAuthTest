using OAuthLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TestPoint
{
    class Program
    {
        private readonly OAuthSigner _oAuthSigner = new OAuthSigner();

        static void Main(string[] args)
        {
            var runner = new Program();
            runner.Run();
        }

        private void Run()
        {
            //var signature = Sign(TestSourceType.Hugh);
            //var signature = Sign(TestSourceType.Quickie);
            var signature = Sign(TestSourceType.Quickie);

        }

        private string Sign(TestSourceType testSource)
        {
            var testData = Repo.TestData[testSource];
            return _oAuthSigner.Sign(testData[1]["consumer_secret"], 
                        testData[1]["url"], 
                        testData[0], 
                        testData[1]["http_method"]);
        }
    }
}
