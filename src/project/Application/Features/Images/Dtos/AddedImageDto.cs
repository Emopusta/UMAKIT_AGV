﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Dtos
{
    public class AddedImageDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
