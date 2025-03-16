
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SkymeyLibs.Data;
using SkymeyLibs.Models.Tables.Bonds;
using SkymeyLibs.Models.Tables.Posts;
using SkymeyLibs.Models.Tables.Stocks;
using SkymeyLibs.Models.Tables.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SkymeyLibs.Interfaces.Data
{
    public interface IMongoRepository : IDisposable
    {
        Task<HttpStatusCode> CreatePost(POST_VIEW_MODEL VIEW_MODEL);
        #region Crypto
        Task<IEnumerable<API_TOKEN>> GetTokens();
        Task<List<TokenList>> GetTokenList();
        Task<API_TOKEN> GetToken(string slug);
        Task<bool> AddToken(API_TOKEN token);
        #endregion

        #region Bonds
        Task<IEnumerable<stock_bonds>> GetBonds();
        Task<IEnumerable<stock_bonds>> GetBondsParams(int skip, int take);
        Task<bool> AddBond(stock_bonds bond);
        #endregion

        #region Stocks
        Task<IEnumerable<stock_stocks>> GetStocks();
        Task<IEnumerable<stock_stocks>> GetStocksParams(int skip, int take);
        Task<stock_stocks> GetStock(string isin);
        Task<bool> AddStock(stock_stocks bond);
        #endregion
    }
}
