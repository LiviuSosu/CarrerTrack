using CarrerTrack.Domain.Entities;
using System.Collections.Generic;

namespace CareerTrack.Utils.Functionalities.BrokenLink
{
    interface IBrokenLink
    {
        void SetBrokenLinks(IEnumerable<Article> articles);
    }
}
