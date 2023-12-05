using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repositories
{
    public class RatingRepository: IRatingRepository
    {
        IConfiguration _configuration;

        public RatingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Rating> addRating(Rating rating)
        {
            string query = "INSERT INTO RATING(HOST, METHOD, PATH, REFERER ,USER_AGENT, Record_Date)" +
                "VALUES(@HOST, @METHOD, @PATH, @REFERER, @USER_AGENT, @Record_Date)";

            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("MyStore")))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@HOST", SqlDbType.NVarChar, 50).Value = rating.Host;
                cmd.Parameters.Add("@METHOD", SqlDbType.NChar, 10).Value = rating.Method;
                cmd.Parameters.Add("@PATH", SqlDbType.NVarChar, 50).Value = rating.Path;
                cmd.Parameters.Add("@REFERER", SqlDbType.NVarChar, 20).Value = rating.Referer;
                cmd.Parameters.Add("@USER_AGENT", SqlDbType.NVarChar, 100).Value = rating.UserAgent;
                cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = rating.RecordDate;


                cn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rating;
            }
        }
    }
}
