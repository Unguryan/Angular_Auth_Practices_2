using Auth.App.Services;
using System.Text;

namespace Auth.Infra.Services
{
    public class EncodePasswordService : IEncodePasswordService
    {
        public Task<string> DecodePasswordAsync(string? password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return Task.FromResult(password);
            }

            UTF8Encoding encoder = new UTF8Encoding();
            Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(password);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new string(decoded_char);
            return Task.FromResult(result);
        }

        public Task<string> EncodePasswordAsync(string? password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return Task.FromResult(password);
            }

            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return Task.FromResult(encodedData);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}
