using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OAuthSignatureContract;

namespace OAuthSignatureService
{
    
    public class OAuthSignatureService : IOAuthSignature
    {
        [WebGet()]
        public string GetSignature(SignatureData data)
        {
            throw new NotImplementedException();
        }
    }
}
