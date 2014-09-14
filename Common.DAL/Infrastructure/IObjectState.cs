
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.DAL
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}