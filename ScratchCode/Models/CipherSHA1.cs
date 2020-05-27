using System.Security.Cryptography;


namespace ScratchCode.Models
{
    class CipherSHA1:MyConvert
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static CipherSHA1 SHA = new CipherSHA1();


        /// <summary>
        /// SHA1 для кода + параль
        /// </summary>
        /// <returns>Hash от кода + параль</returns>
        public string ChipherCode(string code, string pass)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            byte[] buffer = ToByteArray(code + pass);
            buffer = sha.ComputeHash(buffer);
            string result = ToString(buffer);

            return result;
        }


        /// <summary>
        /// Обрезание строки
        /// </summary>
        /// <param name="str"> Строка </param>
        /// <param name="size"> Количество необходимых символов от строки </param>
        /// <returns> Обрезаная строка </returns>
        public string TruncateString (string str, int size) => str.Substring(0, size);
    }
}
 