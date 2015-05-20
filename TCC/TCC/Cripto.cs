using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace TCC
{
    abstract class Cripto
    {
        static String texto_cripto;
        static String texto_descripto;
        static String chavePadrao = "sc";

        #region Variaveis_Encapsuladas
        public static String Texto_descripto
        {
            get { return Cripto.texto_descripto; }
            set { Cripto.texto_descripto = value; }
        }
        public static String Texto_cripto
        {
            get { return Cripto.texto_cripto; }
            set { Cripto.texto_cripto = value; }
        }
        #endregion

        public static string cripto(string info)
        {
            string chave = chavePadrao;
            byte[] texto = Encoding.UTF8.GetBytes(info);
            byte[] senha = Encoding.UTF8.GetBytes(chave);

            RijndaelManaged rm = new RijndaelManaged();

            PasswordDeriveBytes senha_gerada = new PasswordDeriveBytes(chave, new MD5CryptoServiceProvider().ComputeHash(senha));

            rm.Key = senha_gerada.GetBytes(32);
            rm.IV = senha_gerada.GetBytes(16);
            rm.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();

            CryptoStream crip = new CryptoStream(ms, rm.CreateEncryptor(rm.Key, rm.IV), CryptoStreamMode.Write);
            crip.Write(texto, 0, texto.Length);
            crip.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string descripto(string info_cripto)
        {
            string chave = chavePadrao;
            byte[] senha = Encoding.UTF8.GetBytes(chave);

            RijndaelManaged rm = new RijndaelManaged();
            MemoryStream ms = null;
            PasswordDeriveBytes senha_gerada = new PasswordDeriveBytes(chave, new MD5CryptoServiceProvider().ComputeHash(senha));

            rm.Key = senha_gerada.GetBytes(32);
            rm.IV = senha_gerada.GetBytes(16);
            rm.Padding = PaddingMode.PKCS7;
            try
            {
                ms = new MemoryStream(Convert.FromBase64String(info_cripto), 0, Convert.FromBase64String(info_cripto).Length);

            }
            catch
            {
                string x = cripto(info_cripto);
                ms = new MemoryStream(Convert.FromBase64String(x), 0, Convert.FromBase64String(x).Length);
            }
            CryptoStream crip = new CryptoStream(ms, rm.CreateDecryptor(rm.Key, rm.IV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(crip);
            return sr.ReadToEnd();
        }
    }
}
