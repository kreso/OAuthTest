using System.Collections.Generic;

namespace TestPoint
{
    internal static class Repo
    {
        internal static readonly Dictionary<TestSourceType, Dictionary<string, string>[]> TestData;

        static Repo()
        {
            TestData = SetTestData();
        }

        private static Dictionary<TestSourceType, Dictionary<string, string>[]> SetTestData()
        {
            return new Dictionary<TestSourceType, Dictionary<string, string>[]>
            {
                {
                    TestSourceType.ImsLocal, new Dictionary<string, string>[2]
                    {
                        new Dictionary<string, string>
                        {
                            {"launch_presentation_return_url", "http://localhost/ims/lms_return.php"},
                            {
                                "lis_outcome_service_url",
                                "http://localhost/ims/common/tool_consumer_outcome.php?b64=MTIzNDU6OjpzZWNyZXQ="
                            },
                            {"lis_result_sourcedid", "feb-123-456-2929::28883"},
                            {"lti_message_type", "basic-lti-launch-request"},
                            {"lti_version", "LTI-1p0"},
                            {"oauth_callback", "about:blank"},
                            {"oauth_consumer_key", "12345"},
                            {"oauth_nonce", "569c74a965dba264eca1c5fbdd8f357e"},
                            {"oauth_signature_method", "HMAC-SHA1"},
                            {"oauth_timestamp", "1376477060"},
                            {"oauth_version", "1.0"},
                            {"resource_link_id", "1"},
                        },
                        new Dictionary<string, string>
                        {
                            {"consumer_secret", "secret"},
                            {"url", "http://localhost/ims/tool.php"},
                            {"http_method", "POST"}
                        }
                    }
                },
                {
                    TestSourceType.ImsGlobal, new Dictionary<string, string>[2]
                    {
                        /* TsaZ2pcGV/AQBu0zOJO8yfxgWOE= */
                        new Dictionary<string, string>
                        {
                            {"resource_link_id", "1"},
                            {"oauth_callback", "about:blank"},
                            {
                                "lis_outcome_service_url",
                                "http://www.imsglobal.org/developers/LTI/test/v1p1/common/tool_consumer_outcome.php?b64=RDJMOjo6ZGZoa2pzZGFoZzIzNGV2NTQ2djQ1Z2praHNkZmc="
                            },
                            {"lis_result_sourcedid", "feb-123-456-2929::28883"},
                            {
                                "launch_presentation_return_url",
                                "http://www.imsglobal.org/developers/LTI/test/v1p1/lms_return.php"
                            },
                            {"lti_version", "LTI-1p0"},
                            {"lti_message_type", "basic-lti-launch-request"},
                            {"oauth_version", "1.0"},
                            {"oauth_nonce", "355c2fd6dcdc210cb6ea4f6ad5539dc4"},
                            {"oauth_timestamp", "1376389444"},
                            {"oauth_consumer_key", "D2L"},
                            {"oauth_signature_method", "HMAC-SHA1"},
                        },
                        new Dictionary<string, string>
                        {
                            {"consumer_secret", "dfhkjsdahg234ev546v45gjkhsdfg"},
                            {"url", "http://www-cert.thinkcentral.com/ePC/toolprovider/ltivalidator"},
                            {"http_method", "POST"},
                        }
                    }
                },
                {
                    // http://oauth.googlecode.com/svn/spec/ext/consumer_request/1.0/drafts/2/spec.html#OAuth Core 1.0
                    /* IxyYZfG2BaKh8JyEGuHCOin/4bA= */
                    TestSourceType.OAuthTest, new Dictionary<string, string>[2]
                    {
                        new Dictionary<string, string>
                        {
                            {"oauth_consumer_key", "dpf43f3p2l4k3l03"},
                            {"oauth_token", ""},
                            {"oauth_signature_method", "HMAC-SHA1"},
                            {"oauth_timestamp", "1191242096"},
                            {"oauth_nonce", "kllo9940pd9333jh"},
                            {"oauth_version", "1.0"},
                        },
                        new Dictionary<string, string>
                        {
                            {"consumer_secret", "kd94hf93k423kf44"},
                            {"url", "http://provider.example.net/profile"},
                            {"http_method", "GET"},
                        }
                    }
                },
                {
                    /* Source: [hUf2IqUOXS0y7aSgQJN+K7ULEOM=] Generated: [+NhxKKqmi6EuFbkxUVw6cQl1u50=] */
                    /* 
                     * Our LTI validation component excludes "basiclti_submit" parameter!
                     */
                    TestSourceType.D2L, new Dictionary<string, string>[2]
                    {
                        new Dictionary<string, string>
                        {
                            {"launch_presentation_locale", "EN-US__"},
                            {"lti_message_type", "basic-lti-launch-request"},
                            {"lti_version", "LTI-1p0"},
                            {"oauth_callback", "about:blank"},
                            {"oauth_consumer_key", "D2L"},
                            {"oauth_nonce", "458091633"},
                            {"oauth_signature_method", "HMAC-SHA1"},
                            {"oauth_timestamp", "1376477731"},
                            {"oauth_version", "1.0"},
                            {"resource_link_description", ""},
                            {"resource_link_id", "hmhprod_"},
                            {"resource_link_title", ""},
                            //{"basiclti_submit", "Launch Endpoint with BasicLTI Data"},
                        },
                        new Dictionary<string, string>
                        {
                            {"consumer_secret", "dfhkjsdahg234ev546v45gjkhsdfg"},
                            {"url", "http://www-cert.thinkcentral.com/ePC/toolprovider/ltivalidator"},
                            {"http_method", "POST"},
                        }
                    }
                },
                {
                    /* Source: [54tOq2C+A09DmIdfV2thYCBbk64=] Generated: [PogDVLksgTOn4NFYFm3HvKVbD6o=] */
                    /* 
                     * Hugh Test 23.08
                     */
                    TestSourceType.Hugh, new Dictionary<string, string>[2]
                    {
                        new Dictionary<string, string>
                        {
                            {"lti_message_type", "basic-lti-launch-request"},/**/
                            {"lti_version", "LTI-1p0"}, /**/
                            {"oauth_callback", "about:blank"}, /**/
                            {"oauth_consumer_key", "thinkcentral"}, /**/
                            {"oauth_nonce", "137726653555068408698"}, /**/
                            {"oauth_signature_method", "HMAC-SHA1"}, /**/
                            {"oauth_timestamp", "1377266535"},/**/
                            {"oauth_version", "1.0"}, /**/
                            {"resource_link_id", "123456"}, /**/
                         
                            {"custom_resource_url", "12345"},
                            {"custom_launch_point", "resource"},
                            {"lis_outcome_service_url", "123456"},
                            {"launchpoint", "http://www-cert.thinkcentral.com/ePC/toolprovider/ltivalidator"},
                            {"launch_presentation_return_url", "http://localhost:8080"},
                            {"tool_consumer_instance_guid", "tck"},
                        },
                        new Dictionary<string, string>
                        {
                            {"consumer_secret", "secret2"},
                            {"url", "http://www-cert.thinkcentral.com/ePC/toolprovider/ltivalidator"},
                            {"http_method", "POST"},
                        }
                    }
                },
                {
                    /* Source: [zQogczAg3jpxbx2PhzYn7DS0x2s=] Generated: [ypN4uVTpyTW+Hgg//3GJzGWd7ko=] */
                    /* 
                     * Consumer Cert Test 19.9
                     */
                    TestSourceType.ConsumerCertTest, new Dictionary<string, string>[2]
                    {
                        new Dictionary<string, string>
                        {
                            {"lti_message_type", "basic-lti-launch-request"},
                            {"lti_version", "LTI-1p0"}, 
                            {"oauth_callback", "about:blank"}, 
                            {"oauth_consumer_key", "{CB8B3233-14C5-4CDE-B236-6ABC1DC1DCEF}"}, 
                            {"oauth_nonce", "13795845925641060493871"}, 
                            {"oauth_signature_method", "HMAC-SHA1"}, 
                            {"oauth_timestamp", "1379586826"},
                            {"oauth_version", "1.0"}, 
                            {"resource_link_id", "Go Math Online Assessment G2, FL"}, 
                         
                            {"custom_resource_url", "http://www-review-cert-tc1.thinkcentral.com/content/hsp/math/hspmath/na/gr2/te_9780153615443_/mathNav.html?page=toc"},
                            {"custom_resource_id", "123"},
                            {"custom_resource_isbn", "9780153827181"},
                            {"custom_launch_point", "resource"},
                            {"lis_outcome_service_url", "123456"},
                            {"launch_presentation_return_url", "http://localhost:8080"},
                            {"tool_consumer_instance_guid", "tck"},
                            {"roles", "Instructor"},
                            {"user_id", "6DA81BA1B4DC0CCDE04400144F250A8C"},

                            {"x", "With Space"},
                            {"y", "yes"},
                        },
                        new Dictionary<string, string>
                        {
                            {"consumer_secret", "523ad2e0d6ea1"},
                            {"url", "http://localhost/ims/lti/cert/lmscert.php?x=With%20Space&y=yes"},
                            {"http_method", "POST"},
                        }
                    }
                },
                {
                    /* Source: [zQogczAg3jpxbx2PhzYn7DS0x2s=] Generated: [ypN4uVTpyTW+Hgg//3GJzGWd7ko=] */
                    /* 
                     * Consumer Cert Test 19.9
                     */
                    TestSourceType.Quickie, new Dictionary<string, string>[2]
                    {
                        new Dictionary<string, string>
                        {
                            {"resource_link_id", "LTIConsumer"},

                            {"lti_version", "LTI-1p0"}, 
                            {"lti_message_type", "basic-lti-launch-request"},

                            {"oauth_callback", "about:blank"}, 
                            {"oauth_consumer_key", "thinkcentral"}, 
                            {"oauth_nonce", "828e8afc967bc72615d5c414112e9ea3"}, 
                            {"oauth_signature_method", "HMAC-SHA1"}, 
                            {"oauth_timestamp", "1379589991"},
                            {"oauth_version", "1.0"}, 

                            {"custom_resource_url", "http://www-cert.thinkcentral.com/content/hsp/math/hspmath/na/gr2/te_9780153615443_/mathNav.html?page=toc"},
                        },
                        new Dictionary<string, string>
                        {
                            {"consumer_secret", "secret2"},
                            {"url", "http://www-cert.thinkcentral.com/ePC/toolprovider/ltivalidator"},
                            {"http_method", "POST"},
                        }
                    }
                },
            };
        }
    }
}
