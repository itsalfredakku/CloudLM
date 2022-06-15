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
        internal async static Task AuthFromSession()
        {
            try
            {
                if (FireObjects.AuthToken == null || FireObjects.RefreshToken == null)
                {
                    return;
                }
                FireObjects.AuthLink = new Firebase.Auth.FirebaseAuthLink(FireObjects.Provider, new Firebase.Auth.FirebaseAuth() { FirebaseToken = FireObjects.AuthToken, RefreshToken = FireObjects.RefreshToken });
                try 
                { 
                    FireObjects.AuthLink = await FireObjects.AuthLink.GetFreshAuthAsync();
                    await FireObjects.AuthLink.RefreshUserDetails();
                }
                catch { throw; }
                FireObjects.User = FireObjects.AuthLink.User;
                FireObjects.AuthToken = FireObjects.AuthLink.FirebaseToken;
                FireObjects.RefreshToken = FireObjects.AuthLink.RefreshToken;
            }
            catch (Exception ex)
            {
                FireObjects.AuthLink = null;

                string error = Classes.Utility.RegExFilter(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrWhiteSpace(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        internal async static Task AuthFromEmailAndPassword(string email, string password)
        {
            try
            {
                FireObjects.AuthLink = await FireObjects.Provider.SignInWithEmailAndPasswordAsync(email: email, password: password);
                FireObjects.User = FireObjects.AuthLink.User;
                FireObjects.AuthToken = FireObjects.AuthLink.FirebaseToken;
                FireObjects.RefreshToken = FireObjects.AuthLink.RefreshToken;
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.RegExFilter(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrWhiteSpace(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        internal async static Task<string> MachineId()
        {
            string machineId = (await (new FireSharp.FirebaseClient(FireObjects.FiresharpConfig)).GetAsync($"{FireObjects.User.LocalId}/machineId")).ResultAs<string>();
            if (String.IsNullOrWhiteSpace(machineId))
            {
                await (new FireSharp.FirebaseClient(FireObjects.FiresharpConfig)).SetAsync($"{FireObjects.User.LocalId}/machineId", Classes.Utility.GetHdds().First().SerialNo.Trim());
            }
            return machineId;
        }
        internal async static Task<string> ValidFrom()
        {
            return (await (new FireSharp.FirebaseClient(FireObjects.FiresharpConfig)).GetAsync($"{FireObjects.User.LocalId}/validFrom")).ResultAs<string>();
        }
        internal async static Task<string> ValidTill()
        {
            return (await (new FireSharp.FirebaseClient(FireObjects.FiresharpConfig)).GetAsync($"{FireObjects.User.LocalId}/validTill")).ResultAs<string>();
        }

        /*public static async Task UpdateProfile(string displayName, string photoUrl)
        {
            try
            {
                await authLink.UpdateProfileAsync(displayName, photoUrl);
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.RegExFilter(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrWhiteSpace(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }*/
        public static async Task Validate()
        {
            try
            {
                try 
                {
                    string hdsn = await MachineId();
                    DateTime validFrom = DateTime.ParseExact(await ValidFrom(), "yyyyMMdd", null);
                    DateTime validTill = DateTime.ParseExact(await ValidTill(), "yyyyMMdd", null);



                    foreach (HardDrive hardDrive in Classes.Utility.GetHdds())
                    {
                        if (hardDrive.SerialNo.Trim() == (await MachineId()).Trim())
                        {
                            if (DateTime.Now >= validFrom && DateTime.Now <= validTill)
                                return;
                        }
                    }
                }
                catch
                {
                    throw new Exception("Please contact administration");
                }
                throw new Exception("Invalid machine");
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.RegExFilter(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrWhiteSpace(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        public static async Task ResetPassword(string email)
        {
            try
            {
                await FireObjects.Provider.SendPasswordResetEmailAsync(email);
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.RegExFilter(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrWhiteSpace(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        public static async Task VerifyEmail(string email)
        {
            try
            {
                await FireObjects.Provider.SendEmailVerificationAsync(email);
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.RegExFilter(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrWhiteSpace(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
        public static async Task ChangePassword(string newPassword)
        {
            try
            {
                await FireObjects.Provider.ChangeUserPassword(FireObjects.AuthToken, newPassword);
            }
            catch (Exception ex)
            {
                string error = Classes.Utility.RegExFilter(@"Reason: [a-zA-Z]+", ex.Message);
                if (String.IsNullOrWhiteSpace(error)) throw new Exception(ex.Message);
                throw new Exception(error);
            }
        }
    }
}
