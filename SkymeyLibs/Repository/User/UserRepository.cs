using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using SkymeyLibs.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;
using SkymeyLibs.Models.Tables.Posts;
using System.Net;
using Microsoft.Extensions.Options;
using SkymeyLibs.Models.Tables.Tokens;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SkymeyLibs.Enums.User;
using SkymeyLibs.Models.User;

namespace SkymeyLibs.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoClient client;
        private readonly ApplicationMongoContext _db;
        private readonly IOptions<MainSettings> _options;

        public UserRepository(IOptions<MainSettings> options)
        {
            _options = options;
            client = new MongoClient(_options.Value.MongoDatabase.DBServer);
            _db = ApplicationMongoContext.Create(client.GetDatabase(_options.Value.MongoDatabase.DBName));
        }

        public async Task<bool> AddUserToGroup(SU_001 user, SU010_Types group_nr)
        {
            SG_001 group = new SG_001();
            group._id = ObjectId.GenerateNewId();
            group.SU001_Id_User = user._id;
            group.SG001_GroupNr = (int)group_nr;
            await _db.SG_001.AddAsync(group);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<SG_001> GetUserInGroup(ObjectId id_user)
        {
            return await _db.SG_001.Where(x => x.SU001_Id_User == id_user).FirstOrDefaultAsync();
        }

        public async Task<SG_010> GetGroup(int group_nr)
        {
            return await _db.SG_010.Where(x => x.SG010_Group_Nr == group_nr).FirstOrDefaultAsync();
        }

        public async Task<SU_001> GetUserByEmail(string email)
        {
            return await _db.SU_001.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<SU_001>> GetUsers()
        {
            return await _db.SU_001.ToListAsync();
        }

        public async Task<bool> CreateUser(SU_001 user)
        {
            user._id = ObjectId.GenerateNewId();
            await _db.SU_001.AddAsync(user);
            await _db.SaveChangesAsync();
            await AddUserToGroup(user, SU010_Types.User);
            return true;
        }

        public void Dispose()
        {
        }
    }
}
