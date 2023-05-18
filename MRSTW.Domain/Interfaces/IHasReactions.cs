using MRSTW.Domain.Entities;
using System.Collections.Generic;

namespace MRSTW.Domain.Interfaces
{
    public interface IHasReactions
    {
        List<Reaction> Reactions { get; set; }
    }
}
