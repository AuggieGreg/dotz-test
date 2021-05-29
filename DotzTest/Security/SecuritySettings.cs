using System;
using System.Text;

namespace DotzTest.Security
{
    public static class SecuritySettings
    {
        public static string TokenSecret { 
            get {
                return "tokensecret-dotztest";
            } 
        }

        public static byte[] TokenKey {
            get {
                return Encoding.ASCII.GetBytes(SecuritySettings.TokenSecret);
            }
        }
    }
}