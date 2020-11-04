using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.Interfaces
{
    public interface IAgriCropSpecsService
    {
        bool Insert(AgriCropSpec agriCropSpecsService);
        bool Update(AgriCropSpec agriCropSpec);
        AgriCropSpec GetAgriCropSpec(int id);
        List<AgriCropSpec> GetAgriCropSpecs();
        bool Delete(int id);
    }
}
