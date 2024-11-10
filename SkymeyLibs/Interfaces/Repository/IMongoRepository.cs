using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SkymeyLibs.Data;
using SkymeyLibs.Models.Tables.Posts;
using SkymeyLibs.Models.Tables.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SkymeyLibs.Interfaces.Data
{
    public interface IMongoRepository: IDisposable
    {
        Task<HttpStatusCode> CreatePost(POST_VIEW_MODEL VIEW_MODEL);
        Task<IEnumerable<API_TOKEN>> GetTokens();
        Task<List<TokenList>> GetTokenList();
        Task<bool> AddToken(API_TOKEN token);
    }
}
