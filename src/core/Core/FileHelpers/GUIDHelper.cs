﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FileHelpers
{
    public static class GUIDHelper
    {
        public static string CreateGuid()
        {

            return Guid.NewGuid().ToString();

        }
    }
}
