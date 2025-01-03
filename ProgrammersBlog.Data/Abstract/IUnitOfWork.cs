﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        IArticleRepository Articles { get; }    //unitofwork.articles

        ICategoryRepository Categories { get; }

        ICommentRepository Comments { get; }

        IRoleRepository Roles { get; }
        IUserRepository Users { get; }  //_UNİTOFWORK.CATEGORİES.ADDASYNC();

        Task<int>SaveAsync();

    }
}
