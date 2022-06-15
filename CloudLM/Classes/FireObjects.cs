using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudLM.Classes
{
    class FireObjects
    {
        internal static string AuthToken
        {
            get
            {
                try
                {
                    if (!String.IsNullOrEmpty(System.IO.File.ReadAllText(".token")))
                        return System.IO.File.ReadAllText(".token");
                }
                catch { }
                try { System.IO.File.Delete(".token"); } catch { }
                return null;
            }
            set
            {
                System.IO.File.WriteAllText(".token", value);
            }
        }
        internal static string RefreshToken
        {
            get
            {
                try
                {
                    if (!String.IsNullOrEmpty(System.IO.File.ReadAllText(".rtoken")))
                        return System.IO.File.ReadAllText(".rtoken");
                }
                catch { }
                try { System.IO.File.Delete(".rtoken"); } catch { }
                return null;
            }
            set
            {
                System.IO.File.WriteAllText(".rtoken", value);
            }
        }
        internal static FireSharp.Interfaces.IFirebaseConfig FiresharpConfig
        {
            get
            {
                return new FireSharp.Config.FirebaseConfig
                {
                    AuthSecret = AuthToken,
                    BasePath = BasePath
                };
            }
        }
        internal static Firebase.Auth.User User
        {
            get; set;
        }
        internal static Firebase.Auth.FirebaseAuthLink AuthLink { get; set; }
        internal static Firebase.Auth.FirebaseAuthProvider Provider
        {
            get
            {
                return new Firebase.Auth.FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(FirebaseApiKey));
            }
        }
        internal static string FirebaseApiKey
        {
            get
            {
                if (System.Configuration.ConfigurationManager.AppSettings["apiKey"] == null) throw new Exception("Firebase api key not found");
                return System.Configuration.ConfigurationManager.AppSettings["apiKey"];
            }
        }
        internal static string BasePath
        {
            get
            {
                if (System.Configuration.ConfigurationManager.AppSettings["basePath"] == null) throw new Exception("Firebase base path not found");
                return System.Configuration.ConfigurationManager.AppSettings["basePath"];
            }
        }
    }
}
