using System.Text;

namespace ToDoList.Domain.Helpers
{
    public static class StringHelper
    {
        public static string EncryptPassword(string value)
        {
            var password = (value += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var data = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();

            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
