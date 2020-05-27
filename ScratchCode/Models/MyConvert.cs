using System;

namespace ScratchCode.Models
{
    class MyConvert
    {
        /// <summary>
        /// Первод строки в byte массив
        /// </summary>
        /// <param name="str">Строку</param>
        /// <returns> Байт массив </returns>
        public byte[] ToByteArray(string str)
        {
            int size = str.Length;
            byte[] result = new byte[size];

            for (int i = 0; i < size; i++)
                result[i] = Convert.ToByte(str[i]);

            return result;
        }



        /// <summary>
        /// Первеод byte массива в строку
        /// </summary>
        /// <param name="array">Массив байтов</param>
        /// <returns> Строка </returns>
        public string ToString(byte[] array)
        {
            int size = array.Length;
            string result = "";

            for (int i = 0; i < size; i++)
                // Без Х2 не работает
                result += (array[i].ToString("X2"));

            return result;
        }
    }
}
