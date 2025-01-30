using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using SkymeyLibs.Interfaces.Data;
using SkymeyLibs.Models.Tables.Posts;
using System.Net;
using Microsoft.Extensions.Options;
using SkymeyLibs.Models.Tables.Tokens;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SkymeyLibs.Enums.User;
using SkymeyLibs.Models.User;
using SkymeyLibs.Repository.User;
using BC = BCrypt.Net.BCrypt;
using System.Security.Claims;
using System.Text.Json;

namespace SkymeyLibs.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoClient client;
        private readonly ApplicationMongoContext _db;
        private readonly IOptions<MainSettings> _options;
        private readonly IOptions<JWTSettings> _config;

        public UserRepository(IOptions<MainSettings> options, IOptions<JWTSettings> config)
        {
            _options = options;
            client = new MongoClient(_options.Value.MongoDatabase.DBServer);
            _db = ApplicationMongoContext.Create(client.GetDatabase(_options.Value.MongoDatabase.DBName));
            _config = config;
        }

        #region Login/Register
        public async Task<AuthenticatedResponse> Register(SU_001 user)
        {
            var find_user = await GetUserByEmail(user.Email);
            AuthenticatedResponse aresp = new AuthenticatedResponse();
            aresp.Status = 0;
            if (find_user == null)
            {
                user.Password = BC.HashPassword(user.Password);
                await CreateUser(user);
                LoginTemplate loginTemplate = new LoginTemplate();
                loginTemplate.SU_001 = user;
                System.Net.HttpStatusCode status_code = System.Net.HttpStatusCode.Accepted;
                return await Login(user);
            }
            else
            {
                return aresp;
            }
        }

        public async Task<AuthenticatedResponse> Login(SU_001 user)
        {
            LoginTemplate login_template = new LoginTemplate();
            var find_user = await GetUserByEmail(user.Email);
            AuthenticatedResponse aresp = new AuthenticatedResponse();
            if (find_user != null)
            {
                login_template.SU_001 = find_user;
                var user_group = await GetUserInGroup(find_user._id);
                var group_data = await GetGroup(user_group.SG001_GroupNr);
                login_template.SG_010 = group_data;
                login_template.SG_001 = user_group;
                CreateJWTToken cjwttoken = new CreateJWTToken(_config);
                List<Claim> claims = new List<Claim>
            {
                new Claim("Name", find_user.Email),
                new Claim(ClaimTypes.Name, find_user.Email),
                new Claim("GroupSid", login_template.SG_001.SG001_GroupNr.ToString()),
                new Claim(ClaimTypes.GroupSid, login_template.SG_001.SG001_GroupNr.ToString()),
                new Claim("Role", login_template.SG_010.SU010_Name),
                new Claim(ClaimTypes.Role, login_template.SG_010.SU010_Name)
            };
                
                await _db.SaveChangesAsync();
                if (!BC.Verify(user.Password, find_user.Password))
                {
                    aresp.Status = 1;
                    return aresp;
                }
                else
                {
                    aresp.AccessToken = cjwttoken.GenerateAccessToken(claims);
                    aresp.RefreshToken = cjwttoken.GenerateRefreshToken();
                    find_user.RefreshToken = aresp.RefreshToken;
                    find_user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(43200);
                    aresp.Status = 100;
                    return aresp;
                }
            }
            else
            {
                aresp.Status = 2;
                return aresp;
            }
        }

        #endregion

        #region Functions
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

        public async Task<bool> AddGroup(SG_010 group)
        {
            await _db.SG_010.AddAsync(group);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateUser(SU_001 user)
        {
            user._id = ObjectId.GenerateNewId();
            await _db.SU_001.AddAsync(user);
            await _db.SaveChangesAsync();
            await AddUserToGroup(user, SU010_Types.User);
            return true;
        }

        #endregion

        public void Dispose()
        {
        }
    }
}
