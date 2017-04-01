using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class StringHandler
    {
        public static string InsertSpaces(this string source)
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {

                    if (Char.IsUpper(letter))
                    {
                        builder.Append(" ");

                    }
                    if (!Char.IsWhiteSpace(letter))
                    {
                        builder.Append(letter);
                    }
                    
                }
            }

            return builder.ToString().Trim();

        }
    }
}
