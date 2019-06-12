using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.AutoMapper
{
    public class MapConfiguration
    {
        public static void RegisterMapProfile()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<MapProfile>();
            });
        }
    }
}
