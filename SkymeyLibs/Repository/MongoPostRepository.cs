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

namespace SkymeyLibs.Data
{
    public class MongoPostRepository : IMongoRepository
    {
        MongoClient client;
        ApplicationMongoContext _db;
        private readonly IOptions<MainSettings> _options;

        public MongoPostRepository(IOptions<MainSettings> options)
        {
            _options = options;
            client = new MongoClient(_options.Value.MongoDatabase.DBServer);
            _db = ApplicationMongoContext.Create(client.GetDatabase(_options.Value.MongoDatabase.DBName));
        }
        public async Task<HttpStatusCode> CreatePost(POST_VIEW_MODEL VIEW_MODEL)
        {
            try
            {
                using (var session = await client.StartSessionAsync())
                {
                    session.StartTransaction();
                    VIEW_MODEL.API_POST._id = ObjectId.GenerateNewId();
                    await _db.API_POST.AddAsync(VIEW_MODEL.API_POST);
                    //_db.SaveChanges();
                    foreach (var item in VIEW_MODEL.API_POST_TAGS)
                    {
                        item._id = ObjectId.GenerateNewId();
                        item.POST_ID = VIEW_MODEL.API_POST._id;
                    }
                    await _db.API_POST_TAGS.AddRangeAsync(VIEW_MODEL.API_POST_TAGS);
                    //_db.SaveChanges();
                    foreach (var item in VIEW_MODEL.API_POST_RESPONSES)
                    {
                        item._id = ObjectId.GenerateNewId();
                        item.POST_ID = VIEW_MODEL.API_POST._id;
                    }
                    await _db.API_POST_RESPONSES.AddRangeAsync(VIEW_MODEL.API_POST_RESPONSES);
                    //_db.SaveChanges();
                    foreach (var item in VIEW_MODEL.API_POST_PARAMS)
                    {
                        item._id = ObjectId.GenerateNewId();
                        item.POST_ID = VIEW_MODEL.API_POST._id;
                    }
                    await _db.API_POST_PARAMS.AddRangeAsync(VIEW_MODEL.API_POST_PARAMS);
                    //_db.SaveChangesAsync();
                    foreach (var item in VIEW_MODEL.API_POST_CODE_SAMPLES)
                    {
                        item._id = ObjectId.GenerateNewId();
                        item.POST_ID = VIEW_MODEL.API_POST._id;
                    }
                    await _db.API_POST_CODE_SAMPLES.AddRangeAsync(VIEW_MODEL.API_POST_CODE_SAMPLES);
                    await _db.SaveChangesAsync();
                    await session.CommitTransactionAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return HttpStatusCode.OK;
        }

        public void Dispose()
        {
        }
    }
}
