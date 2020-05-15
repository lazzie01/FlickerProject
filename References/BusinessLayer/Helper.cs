using System;
using System.IO;
using System.Text;

namespace BusinessLayer
{
    public class FileNameGenerator
    {
        private static Random rand = new Random();

        private static string GenerateTenIntegerStrings()
        {
            int randomNumber = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                randomNumber = rand.Next(10);
                sb.Append(randomNumber);
            }
            return sb.ToString();
        }

        public static string RandomName(string s1)
        {
            int start = s1.Length - 5;
            return GenerateTenIntegerStrings() + s1.Substring(start);
        }
    }

    public static class Helper
    {
        public static string ToBase64String(string folderPath, string fileName)
        {
            string result = null;
            try
            {
                string s1 = Convert.ToBase64String(File.ReadAllBytes(folderPath + fileName));
                result = "data:image/jpeg;base64, " + s1;
            }
            catch(Exception)
            {

            }
            return result;
        }
    }
}