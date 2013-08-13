using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestPoint
{
    class Program
    {
        private readonly Uri _uri = new Uri("http://test.com/");
        private const string ConsumerKey = "CK";
        private const string ConsumerSecret = "secret";
        private const string Token = "";
        private const string TokenSecret = "";
        private const string HttpMethod = "POST";
        private readonly string _timeStamp = DateTime.Now.ToString();
        private const string Nonce = "1";
        private const OAuthBase.SignatureTypes SignatureType = OAuthBase.SignatureTypes.HMACSHA1;
        private string _normalizedUrl = "";
        private string _normalizedRequestParameters = "";

        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            var data = new Dictionary<string, string>()
            {
                {"oauth_consumer_key", "dpf43f3p2l4k3l03"},
                {"oauth_token", ""},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_timestamp", "1191242096"},
                {"oauth_nonce", "kllo9940pd9333jh"},
                {"oauth_version", "1.0"},
            };


            // http://oauth.googlecode.com/svn/spec/ext/consumer_request/1.0/drafts/2/spec.html#OAuth Core 1.0
            /*
            Sign("kd94hf93k423kf44", 
                 "http://provider.example.net/profile", 
                 "oauth_consumer_key=dpf43f3p2l4k3l03&oauth_nonce=kllo9940pd9333jh&oauth_signature_method=HMAC-SHA1&oauth_timestamp=1191242096&oauth_token=&oauth_version=1.0", 
                 "GET");
            */
            /*
            Sign("kd94hf93k423kf44",
                 "http://provider.example.net/profile",
                 data,
                 "GET");
            */
            Sign("dfhkjsdahg234ev546v45gjkhsdfg", 
                "http://www-cert.thinkcentral.com/ePC/toolprovider/ltivalidator",
                GetFormsData());

        }

        private void Sign(string consumerSecret, string url, IDictionary<string, string> data, string httpMethod = "POST")
        {
            if (data == null)
                data = GetFormsData();

            var orderedFormData = data.OrderBy(kvp => kvp.Key);
            var normalizedData = NormalizeFormData(orderedFormData);

            Sign(consumerSecret, url, normalizedData, httpMethod);
        }

        private void Sign(string consumerSecret, string url, string data, string httpMethod = "POST")
        {
            /*
             * URL = http://www-cert.thinkcentral.com/ePC/toolprovider/ltivalidator
             * Key = D2L
             * Secret = dfhkjsdahg234ev546v45gjkhsdfg
            oauth_signature=TsaZ2pcGV/AQBu0zOJO8yfxgWOE=
             */

            httpMethod = httpMethod.ToUpper();

            var oAuth = new OAuthBase();

            if (data == null)
                data = String.Empty;
            
            var normalizedUrl = NormalizeUrl(new Uri(url));

            var oAuthReadySignatureData = PrepareOAuthSignatureData(oAuth, httpMethod, 
                                                                    normalizedUrl, data);

            var oAuthReadyConsumerSecret = PrepareOAuthConsumerSecret(oAuth, consumerSecret);

            var oAuthKey = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", oAuthReadyConsumerSecret, ""));
            //var oAuthKey = Encoding.ASCII.GetBytes(string.Format("{0}", oAuthReadyConsumerSecret));
            var hashAlgorithm = new HMACSHA1(oAuthKey);

            var signature = GenerateOAuthSignature(hashAlgorithm, oAuthReadySignatureData);   
        }

        private Dictionary<string,string> GetFormsData()
        {
            return new Dictionary<string, string>()
            {
                {"resource_link_id", "1"},
                {"oauth_callback", "about:blank"},
                {"lis_outcome_service_url", "http://www.imsglobal.org/developers/LTI/test/v1p1/common/tool_consumer_outcome.php?b64=RDJMOjo6ZGZoa2pzZGFoZzIzNGV2NTQ2djQ1Z2praHNkZmc="},
                {"lis_result_sourcedid", "feb-123-456-2929::28883"},
                {"launch_presentation_return_url", "http://www.imsglobal.org/developers/LTI/test/v1p1/lms_return.php"},
                {"lti_version", "LTI-1p0"},
                {"lti_message_type", "basic-lti-launch-request"},
                {"oauth_version", "1.0"},
                {"oauth_nonce", "355c2fd6dcdc210cb6ea4f6ad5539dc4"},
                {"oauth_timestamp", "1376389444"},
                {"oauth_consumer_key", "D2L"},
                {"oauth_signature_method", "HMAC-SHA1"},
            };
        }

        private object GenerateOAuthSignature(HMACSHA1 hashAlgorithm, string data)
        {
            var dataBuffer = Encoding.ASCII.GetBytes(data);
            var hashBytes = hashAlgorithm.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);
        }

        private string PrepareOAuthConsumerSecret(OAuthBase oAuth, string consumerSecret)
        {
            return oAuth.UrlEncode(consumerSecret);
        }

        private string PrepareOAuthSignatureData(OAuthBase oAuth, string httpMethod, string normalizedUrl, string normalizedFormData)
        {
            var signatureData = new StringBuilder();

            signatureData.AppendFormat("{0}&", httpMethod.ToUpper());
            signatureData.AppendFormat("{0}&", oAuth.UrlEncode(normalizedUrl));
            signatureData.AppendFormat("{0}", oAuth.UrlEncode(normalizedFormData));

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
                data.Append(String.Format("{0}={1}&", kvp.Key, kvp.Value));

            return (data.Length > 0) 
                ? data.Remove(data.Length - 1, 1).ToString()
                : "";
        }
    }
}
