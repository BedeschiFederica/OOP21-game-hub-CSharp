using System;
using System.Collections.Generic;

namespace Furegato_Silvia
{
    /**
    * <summary>Enum <c>Colors</c> defines custom colors.</summary>
    */
    public enum Colors
    {
        RED = 0,
        ORANGE = 1,
        YELLOW = 2,
        LIME = 3,
        GREEN = 4,
        LIGHT_BLUE = 5,
        BLUE = 6,
        INDIGO = 7,
        PURPLE = 8,
        MAGENTA = 9
    }

    /**
    * <summary>Extension class <c>ColorsExtension</c> defines some methods fr the enum .</summary>
    */
    static public class ColorsExtension
    {
        private const int MAX_COLOR_NUMBER = 10;
        private const int MIN_COLOR_NUMBER = 0;

        /**
         * <summary>Method <c>GetRandomColors</c> creates a list of random colors of length n.</summary>
         * 
         * <param name="n">The number of colors.</param>
         * <returns>A list of random colors.</returns>
         */
        public static List<Colors> GetRandomColors(this Colors c, int n)
        {
            Random randColor = new Random();
            if (n > MAX_COLOR_NUMBER || n < MIN_COLOR_NUMBER)
            {
                throw new ArgumentOutOfRangeException($"Input number was too large or too little. Try with a number between {MIN_COLOR_NUMBER} and {MAX_COLOR_NUMBER}");
            }
            else
            {
                List<Colors> result = new List<Colors>();
                foreach (Colors col in Enum.GetValues(typeof(Colors)))
                {
                    result.Add(col);
                }

                for (int i = 0; i < (MAX_COLOR_NUMBER - n); i++)
                {
                    result.Remove(result[randColor.Next(MAX_COLOR_NUMBER - i)]);
                }
                return result;
            }
        }
    }
}
