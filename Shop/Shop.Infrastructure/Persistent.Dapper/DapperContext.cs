using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Dapper
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);


        public string Inventories => "[seller].Inventories";
        public string UserAddresses => "[user].Addresses";
        public string OrderItems => "[order].Items";
        public string Products => "[product].Products";
        public string Sellers => "[seller].Sellers";
        public string UserTokens => "[user].Tokens";
    }
}
