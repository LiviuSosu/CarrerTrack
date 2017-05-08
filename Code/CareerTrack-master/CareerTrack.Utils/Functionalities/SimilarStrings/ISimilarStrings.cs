using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerTrack.Utils.Functionalities.SimilarStrings
{
    public interface ISimilarStrings
    {
        bool StringComparer(string string1, string string2, int threshold);
    }
}
