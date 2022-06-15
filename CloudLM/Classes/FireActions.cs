using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudLM.Classes
{
    internal class FireActions
    {
        private static string FirebaseApiKey
        {
            get
            {
                if (ConfigurationManager.AppSettings["apiKey"] == null) throw new Exception("Firebase api key not found");
                return ConfigurationManager.AppSettings["apiKey"];
            }
        }
        private static FirebaseAuthProvider Provider
        {
            get
            {
                return new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));
            }
        }


        private static FirebaseAuthLink authLink;


        private static User _User = null;
        public static User User
        {
            get
            {
                return _User;
            }
        }


        private static string _AuthToken
        {
            set
            {
                System.IO.File.WriteAllText(".token", value);
            }
        }
        public static string AuthToken
        {
            get
            {
                try
                {
                    return System.IO.File.ReadAllText(".token");
                }
                catch { return null; }
            }
        }


        public static async Task Authenticate(string email, string password)
        {
            try
            {
                authLink = await Provider.SignInWithEmailAndPasswordAsync(email: email, password: password);
                if (authLink == null) throw new Exception("Authentication failed");
                _User = authLink.User;
                _AuthToken = authLink.FirebaseToken;
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.ApplyRegEx(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrEmpty(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        public static async Task UpdateProfile(string displayName, string photoUrl)
        {
            try
            {
                await authLink.UpdateProfileAsync(displayName, photoUrl);
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.ApplyRegEx(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrEmpty(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        public static async Task ResetPassword(string email)
        {
            try
            {
                await Provider.SendPasswordResetEmailAsync(email);
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.ApplyRegEx(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrEmpty(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        public static async Task VerifyEmail(string email)
        {
            try
            {
                await Provider.SendEmailVerificationAsync(email);
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.ApplyRegEx(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrEmpty(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        public static async Task ChangePassword(string newPassword)
        {
            try
            {
                await Provider.ChangeUserPassword(AuthToken, newPassword);
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.ApplyRegEx(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrEmpty(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }

        

    }
}
