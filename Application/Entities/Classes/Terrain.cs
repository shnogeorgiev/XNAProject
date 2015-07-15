using Application.Entities.Classes;
using Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Entities.Classes
{
    public class Terrain : SolidObject
    {
        public Terrain()
            : base()
        {
            base.width = Constants.LandDefaultWidth;
            base.height = Constants.LandDefaultHeight;
        }
    }
}
