﻿using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;
using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleListDto :DtoGetBase
    {
        public IList<Article> Articles { get; set; }
        
    }
}
