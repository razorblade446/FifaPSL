using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.Common.Models;

namespace FifaPSL.BL.Services.Interfaces
{
    public interface IGroupService
    {

        Group[] getGroups();

        Group getGroup(int groupId);

    }
}
