using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using SkymeyLibs.Data;
using SkymeyLibs.Enums.User;
using SkymeyLibs.Models.Tables.Posts;
using SkymeyLibs.Models.Tables.Tokens;
using SkymeyLibs.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SkymeyLibs.Interfaces.Data
{
    public interface IUserRepository: IDisposable
    {
        Task<bool> AddUserToGroup(SU_001 user, SU010_Types group_nr);
        Task<SG_001> GetUserInGroup(ObjectId id_user);
        Task<SG_010> GetGroup(int group_nr);
        Task<SU_001> GetUserByEmail(string email);
        Task<List<SU_001>> GetUsers();
        Task<bool> CreateUser(SU_001 user);
    }
}
