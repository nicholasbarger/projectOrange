using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entities = projectOrange.Models.Inventory.Entities;
using DTOs = projectOrange.Models.Inventory.DTOs;
using AutoMapper;

namespace projectOrange.BusinessDataLogic.Mappers
{
    public class ItemModelToFullItemDTO : Mapper<Entities.Item, DTOs.FullItem>
    {
        public override DTOs.FullItem Map(Entities.Item t)
        {
            Mapper.CreateMap<Entities.Item, DTOs.FullItem>();
            return Mapper.Map<Entities.Item, DTOs.FullItem>(t);
        }
    }
}
