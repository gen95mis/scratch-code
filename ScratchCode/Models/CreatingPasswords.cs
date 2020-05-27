using System.Collections.Generic;
using System.Linq;

namespace ScratchCode.Models
{
    class CreatingPasswords
    {
        public static CreatingPasswords Creating = new CreatingPasswords();
        public string SymbolArray = "ABCDEFGHIJKLMNOPQRSTUVWXTZ0123456789";


        public List<string> CreatPass()
        {
            List<string> listPass = new List<string>();

            string buf;
            int size = SymbolArray.Length;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    for (int k = 0; k < size; k++)
                        for (int l = 0; l < size; l++)
                        {
                            buf = "";
                            buf += SymbolArray[i];
                            buf += SymbolArray[j];
                            buf += SymbolArray[k];
                            buf += SymbolArray[l];
                            listPass.Add(buf);
                        }

            return listPass;
        }



        public List<string> CreatPass(int countPass, int sizePass)
        {
            List<string> listPass = new List<string>();
            System.Random random = new System.Random();

            string bufPass;
            int sizeListPass = 0;

            while (countPass >= sizeListPass)
            {
                bufPass = "";
                for (int j = 0; j < sizePass; j++)
                    bufPass += SymbolArray[random.Next(0, SymbolArray.Length)];

                listPass.Add(bufPass);
                listPass = new List<string>(listPass.Distinct());
                sizeListPass = listPass.Count;
            }

            return listPass;
        }
    }
}
