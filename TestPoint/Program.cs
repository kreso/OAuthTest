using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TestPoint
{
    class Program
    {
        private readonly OAuthBase _oAuth = new OAuthBase();

        static void Main(string[] args)
        {
            var runner = new Program();
            runner.Run();
        }

        private void Run()
        {
            var signature = Sign(TestSourceType.D2L);
        }

        private string Sign(TestSourceType testSource)
        {
            var testData = Repo.TestData[testSource];
            return Sign(testData[1]["consumer_secret"], 
                        testData[1]["url"], 
                        testData[0], 
                        testData[1]["http_method"]);
        }

        private string Sign(string consumerSecret, string url, IDictionary<string, string> data, string httpMethod = "POST")
        {
            var orderedFormData = data.OrderBy(kvp => kvp.Key);
            var normalizedData = NormalizeFormData(orderedFormData);
            return Sign(consumerSecret, url, normalizedData, httpMethod);
        }

        private string Sign(string consumerSecret, string url, string data, string httpMethod = "POST")
        {
            if (data == null) data = String.Empty;
            
            var normalizedUrl = NormalizeUrl(new Uri(url));
            var oAuthReadySignatureData = PrepareOAuthSignatureData(httpMethod, 
                                                                    normalizedUrl, data);

            var oAuthReadyConsumerSecret = PrepareOAuthConsumerSecret(consumerSecret);

            var oAuthKey = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", oAuthReadyConsumerSecret, ""));
            var hashAlgorithm = new HMACSHA1(oAuthKey);
            
            return GenerateOAuthSignature(hashAlgorithm, oAuthReadySignatureData);   
        }

        private string GenerateOAuthSignature(HMACSHA1 hashAlgorithm, string data)
        {
            var dataBuffer = Encoding.ASCII.GetBytes(data);
            var hashBytes = hashAlgorithm.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);
        }

        private string PrepareOAuthConsumerSecret(string consumerSecret)
        {
            return _oAuth.UrlEncode(consumerSecret);
        }

        private string PrepareOAuthSignatureData(string httpMethod, string normalizedUrl, string normalizedFormData)
        {
            var signatureData = new StringBuilder();

            signatureData.AppendFormat("{0}&", httpMethod.ToUpper());
            signatureData.AppendFormat("{0}&", _oAuth.UrlEncode(normalizedUrl));
            signatureData.AppendFormat("{0}", _oAuth.UrlEncode(normalizedFormData));

            return signatureData.ToString();
        }

        private string NormalizeUrl(Uri uri)
        {
            var normalizedUrl = new StringBuilder();

            normalizedUrl.Append(string.Format("{0}://{1}", uri.Scheme, uri.Host));

            if (!((uri.Scheme == "http" && uri.Port == 80) || (uri.Scheme == "https" && uri.Port == 443)))
                normalizedUrl.AppendFormat(":{0}", uri.Port);

            normalizedUrl.Append(uri.AbsolutePath);

            return normalizedUrl.ToString();
        }

        private string NormalizeFormData(IEnumerable<KeyValuePair<string, string>> formData)
        {
            var data = new StringBuilder();
            foreach (var kvp in formData)
                data.Append(String.Format("{0}={1}&", kvp.Key, _oAuth.UrlEncode(kvp.Value)));
            return (data.Length > 0) 
                ? data.Remove(data.Length - 1, 1).ToString()
                : "";
        }
    }
}
