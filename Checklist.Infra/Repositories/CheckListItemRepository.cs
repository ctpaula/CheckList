﻿using CheckList.Domain;
using CheckList.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Infra.Repositories
{
    public class CheckListItemRepository : RepositoryBase<CheckListItem>, ICheckListItemRepository
    {
        protected CheckListItemRepository(RDbContext context) : base(context)
        {
        }
    }
}
