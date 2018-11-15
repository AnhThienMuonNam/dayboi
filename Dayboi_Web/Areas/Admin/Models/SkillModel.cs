﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dayboi_Web.Areas.Admin.Models
{
    public class SkillModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string MetaKeyword { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        //default columns
        public int? DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public List<string> Tags { get; set; }
    }
}