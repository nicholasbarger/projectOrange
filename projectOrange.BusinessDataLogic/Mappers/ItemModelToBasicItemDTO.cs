using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entities = projectOrange.Models.Inventory.Entities;
using DTOs = projectOrange.Models.Inventory.DTOs;
using AutoMapper;

namespace projectOrange.BusinessDataLogic.Mappers
{
    public class ItemModelToBasicItemDTO : Mapper<Entities.Item, DTOs.BasicItem>
    {
        public override DTOs.BasicItem Map(Entities.Item t)
        {
            Mapper.CreateMap<Entities.Item, DTOs.BasicItem>();
            return Mapper.Map<Entities.Item, DTOs.BasicItem>(t);
        }
    }
}
