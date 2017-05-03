using System;


namespace SA.Factorys
{
    public static class Soma1c
    {
        /// <summary>
        /// Geraum número sequencial em formato string
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns></returns>
        public static string soma(string num,int size)
        {

            string result;
            

            long ret = (Convert.ToInt64(num) + 1);
            result = Convert.ToString(ret).PadLeft(size, '0');


            return result;
        }
    }
}