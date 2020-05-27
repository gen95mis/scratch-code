using System;
using System.Collections.Generic;

namespace ScratchCode.Models
{
    public class CreatingCode
    {
        public static CreatingCode RandomCode = new CreatingCode();
        
        // Массив символов для Кода
        private string SymbolArray = "ABCDEFGHIJKLMNOPQRSTUVWXTZ0123456789";


        /// <summary>
        /// Генирация кода
        /// </summary>
        /// <param name="sizeCode"> Размер строки (када) </param>
        /// <returns> Код </returns>
        private string GenCode(int sizeCode)
        {
            string str = "";
            Random random = new Random();

            for (int i = 0; i < sizeCode; i++)
            {
                str += SymbolArray[random.Next(0, SymbolArray.Length)];
                // Остановка делается для неповторимости при генирации
                System.Threading.Thread.Sleep(5);
            }

            return str;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="countCode"></param>
        /// <param name="pass"></param>
        /// <param name="sizeCode"></param>
        /// <returns></returns>
        public List<string> GenerationScratchCodes(int countCode, string pass, int sizeCode, int sizeSHA)
        {
            List<string> result = new List<string>();
            string code;
            string sha;

            for (int i = 0; i < countCode; i++)
            {
                code = GenCode(sizeCode);
                sha = CipherSHA1.SHA.ChipherCode(code, pass);
                sha = CipherSHA1.SHA.TruncateString(sha, sizeSHA);

                result.Add(code + sha);
            }

            return result;
        }
    }
}
