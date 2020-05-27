using System.Collections.Generic;


namespace ScratchCode.Models
{
    class SelectingPasswords : CipherSHA1
    {
        private List<string> ScratchCode;
        private List<string> ListPass;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ScratchCode"></param>
        public SelectingPasswords(List<string> ScratchCode)
        {
            this.ScratchCode = ScratchCode;
            ListPass = CreatingPasswords.Creating.CreatPass();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ScratchCode"></param>
        /// <param name="countPass"></param>
        /// <param name="sizePass"></param>
        public SelectingPasswords(List<string> ScratchCode, int countPass, int sizePass)
        {
            ListPass = CreatingPasswords.Creating.CreatPass(countPass, sizePass);
            this.ScratchCode = ScratchCode;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizeCode"></param>
        /// <param name="sizeSHA"></param>
        /// <returns></returns>
        public List<string> BruteForcePass(int sizeCode, int sizeSHA)
        {
            List<string> result = new List<string>();
            
            string sha = "";
            string code = "";
            string bufSha = "";


            foreach (string str in ScratchCode)
            {
                result = new List<string>();
                code = str.Substring(0, sizeCode);
                sha = str.Substring(sizeCode, sizeSHA);

                foreach (var pass in ListPass.ToArray())
                {
                    bufSha = ChipherCode(code, pass);
                    if (bufSha.Substring(0, sizeSHA) == sha)
                        result.Add(pass);
                }

                ListPass = result;
            }

            return result;
        }


    }
}
