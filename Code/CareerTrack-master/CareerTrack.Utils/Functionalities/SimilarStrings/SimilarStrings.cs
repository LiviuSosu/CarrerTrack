using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerTrack.Utils.Functionalities.SimilarStrings
{
    public class SimilarStrings : ISimilarStrings
    {
        public bool StringComparer(string string1,string string2, int threshold)
        {
            bool similarStrings = true;

            string1 = string1.ToLower();
            string1 = RemoveFirstWhiteSpaces(string1);
            string1 = RemoveLastWhiteSpaces(string1);
            string1 = RemoveConsecutiveWhiteSpaces(string1);

            string2 = string2.ToLower();
            string2 = RemoveFirstWhiteSpaces(string2);
            string2 = RemoveLastWhiteSpaces(string2);
            string2 = RemoveConsecutiveWhiteSpaces(string2);

            int difference = GetNumberOfDifferentCharactes(string1, string2);
            if(difference > threshold)
            {
                similarStrings = false;
            }

            return similarStrings;
        }

        public string RemoveFirstWhiteSpaces(string str)
        {
            bool stop = false;
            for(int i=0;i<str.Length;i++)
            {
                if(stop==false)
                {
                    if(str[0]==' ')
                    {
                        str= str.Remove(0,1);
                    }
                    else
                    {
                        stop = true;
                    }
                }
            }
            return str;
        }

        public string RemoveLastWhiteSpaces(string str)
        {
            bool stop = false;
            for (int i = str.Length; i > 0; i--)
            {
                if (stop == false)
                {
                    if (str[str.Length-1] == ' ')
                    {
                        str = str.Remove(str.Length-1, 1);
                    }
                    else
                    {
                        stop = true;
                    }
                }
            }
            return str;
        }

        public string RemoveConsecutiveWhiteSpaces(string str)
        {
            for(int i=1; i<str.Length-1;i++)
            {
                if(str[i]==' '&& str[i+1]==' ')
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }

        public int GetNumberOfDifferentCharactes(string string1, string string2)
        {
            int count = 0;
            int lenght= string2.Length;

            if(string1.Length < string2.Length)
            {
                lenght = string1.Length;
            }

            else
            {
                for(int i =0;i< lenght; i++)
                {
                    if (string1[i]!= string2[i])
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
