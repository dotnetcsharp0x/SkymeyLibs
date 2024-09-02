using Microsoft.AspNetCore.Mvc;
using SkymeyLibs.Models.Tables.Posts;
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
    }
}
