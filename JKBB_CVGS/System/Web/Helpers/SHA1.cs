namespace System.Web.Helpers
{
    public class SHA1
    {
        // source https://www.codeproject.com/Articles/482546/Creating-a-custom-user-login-form-with-NET-Csharp
        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }

}