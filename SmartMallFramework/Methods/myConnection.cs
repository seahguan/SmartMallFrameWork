using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace SmartMallFramework
{
    /// <summary>
    /// in the mid of investiga by setting the SQL connection to the DB 
    /// </summary>
    class myConnection
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public static SqlConnection getconn()
        //{
        //    string Constr = ConfigurationManager.ConnectionStrings["PEFADBCN"].ConnectionString;
        //    SqlConnection Conn = new SqlConnection(Constr);

        //    try
        //    {
        //        SqlHelper helper = new SqlHelper(Constr);

        //        if (helper.IsConnection)
        //        {
        //            log.Info("Successfull open the DB Connection.");
        //            Conn.Open();
        //            return Conn;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        log.Fatal("Fail to open the connectode in the program.", e);
        //    }
            
        //}
    }
}
