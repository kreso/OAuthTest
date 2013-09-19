using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OAuthSignatureContract
{
    [ServiceContract()]
    public interface IOAuthSignature
    {
        [OperationContract()]
        string GetSignature(SignatureData data);
    }

    [DataContract()]
    public class SignatureData
    {
        [DataMember()]
        Dictionary<string,string> PostParameters { get; set; }

        [DataMember()]
        string HttpMethod { get; set; }
        
        [DataMember()]
        string Url { get; set; }
        
        [DataMember()]
        string ConsumerKey { get; set; }
    }
}
