using FInspectData.Models;
using System.Collections.Generic;

namespace FInspectData.Interfaces
{
    public interface IAssemblyDetails
    {
        Assembly GetAssemblyDetails(string PartNumber);
    }
}
