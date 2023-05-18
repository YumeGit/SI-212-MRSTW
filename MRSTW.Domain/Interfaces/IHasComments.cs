using MRSTW.Domain.Entities;
using System.Collections.Generic;

namespace MRSTW.Domain.Interfaces
{
    public interface IHasComments
    {
        List<Comment> Comments { get; set; }
    }
}
