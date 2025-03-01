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
using SkymeyLibs.Models.Tables.Bonds;
using SkymeyLibs.Models.Tables.Stocks;
using System.Runtime.InteropServices.Marshalling;

namespace SkymeyLibs.Data
{
    public class MongoPostRepository : IMongoRepository
    {
        //private readonly MongoClient client;
        private readonly ApplicationMongoContext _db;
        //private readonly IOptions<MainSettings> _options;

        public MongoPostRepository(MongoClient client, MongoDatabase db)
        {
            //_options = options;
            //client = new MongoClient(_options.Value.MongoDatabase.DBServer);
            _db = ApplicationMongoContext.Create(client.GetDatabase(db.DBName));
        }
        public async Task<IEnumerable<API_TOKEN>> GetTokens()
        {
            return (from i in _db.API_TOKEN select i).AsNoTracking();
        }
        public async Task<API_TOKEN> GetToken(string slug)
        {
            return (from i in _db.API_TOKEN where i.Slug == slug select i).AsNoTracking().FirstOrDefault();
        }
        public async Task<IEnumerable<stock_bonds>> GetBonds()
        {
            return (from i in _db.stock_bonds select i).AsNoTracking();
        }
        public async Task<IEnumerable<stock_stocks>> GetStocks()
        {
            return (from i in _db.stock_stocks select i).AsNoTracking();
        }
        public async Task<IEnumerable<stock_bonds>> GetBondsParams(int skip, int take)
        {
            return (from i in _db.stock_bonds select i).Skip(skip).Take(take).AsNoTracking();
        }
        public async Task<IEnumerable<stock_stocks>> GetStocksParams(int skip, int take)
        {
            return (from i in _db.stock_stocks select i).Skip(skip).Take(take).AsNoTracking();
        }
        public async Task<List<TokenList>> GetTokenList()
        {
           
            return await (from i in _db.crypto_index_page_tokens select i).ToListAsync();
            
        }
        public async Task<bool> AddToken(API_TOKEN token)
        {
            token._id = ObjectId.GenerateNewId();
            token.Slug = token.Name.ToLower();
            await _db.API_TOKEN.AddAsync(token);
            await _db.SaveChangesAsync();
            return true;

        }
        public async Task<bool> AddBond(stock_bonds bond)
        {
            bond._id = ObjectId.GenerateNewId();
            await _db.stock_bonds.AddAsync(bond);
            await _db.SaveChangesAsync();
            return true;

        }
        public async Task<bool> AddStock(stock_stocks stock)
        {
            stock._id = ObjectId.GenerateNewId();
            await _db.stock_stocks.AddAsync(stock);
            await _db.SaveChangesAsync();
            return true;

        }
        public async Task<HttpStatusCode> CreatePost(POST_VIEW_MODEL VIEW_MODEL)
        {
            try
            {
                
                    Console.WriteLine("1");
                    VIEW_MODEL.API_POST._id = ObjectId.GenerateNewId();
                    await _db.API_POST.AddAsync(VIEW_MODEL.API_POST);
                    await _db.SaveChangesAsync();
                    //_db.SaveChanges();
                    foreach (var item in VIEW_MODEL.API_POST_TAGS)
                    {
                        item._id = ObjectId.GenerateNewId();
                        item.POST_ID = VIEW_MODEL.API_POST._id;
                    }
                    Console.WriteLine("2");
                    await _db.API_POST_TAGS.AddRangeAsync(VIEW_MODEL.API_POST_TAGS);
                    await _db.SaveChangesAsync();
                    //_db.SaveChanges();
                    foreach (var item in VIEW_MODEL.API_POST_RESPONSES)
                    {
                        item._id = ObjectId.GenerateNewId();
                        item.POST_ID = VIEW_MODEL.API_POST._id;
                    }
                    Console.WriteLine("3");
                    await _db.API_POST_RESPONSES.AddRangeAsync(VIEW_MODEL.API_POST_RESPONSES);
                    await _db.SaveChangesAsync();
                    //_db.SaveChanges();
                    foreach (var item in VIEW_MODEL.API_POST_PARAMS)
                    {
                        item._id = ObjectId.GenerateNewId();
                        item.POST_ID = VIEW_MODEL.API_POST._id;
                    }
                    Console.WriteLine("4");
                    await _db.API_POST_PARAMS.AddRangeAsync(VIEW_MODEL.API_POST_PARAMS);
                    await _db.SaveChangesAsync();
                    //_db.SaveChangesAsync();
                    foreach (var item in VIEW_MODEL.API_POST_CODE_SAMPLES)
                    {
                        item._id = ObjectId.GenerateNewId();
                        item.POST_ID = VIEW_MODEL.API_POST._id;
                    }
                    Console.WriteLine("5");
                    await _db.API_POST_CODE_SAMPLES.AddRangeAsync(VIEW_MODEL.API_POST_CODE_SAMPLES);
                    await _db.SaveChangesAsync();
                    Console.WriteLine("6");

                    Console.WriteLine("7");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return HttpStatusCode.OK;
        }
        ~MongoPostRepository()
        {

        }

        public void Dispose()
        {
        }
    }
}
