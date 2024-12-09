using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth.ManagementSystem.UnitTests
{
    internal class MapperHelper
    {
        public static IMapper CreateMapper(Profile profile)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile);
            });

            return mappingConfig.CreateMapper();
        }
    }
}
