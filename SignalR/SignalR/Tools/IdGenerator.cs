using System.Text;

namespace SignalR.Tools
{
    public static class IdGenerator
    {
        private static readonly string AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random Random = new Random();

        public static string GenerateId()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                int index = Random.Next(AllowedCharacters.Length);
                sb.Append(AllowedCharacters[index]);
            }
            return sb.ToString();
        }
        public static string GeneratePassword()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int index = Random.Next(AllowedCharacters.Length);
                sb.Append(AllowedCharacters[index]);
            }
            return sb.ToString();
        }
    }
}
