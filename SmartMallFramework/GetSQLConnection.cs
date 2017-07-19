using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PefaMallFramework
{
    class GetSQLConnection
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Define the SQL connection
        // this is hardcoded way and below is the connect to local DB using the windows authentification
        // SqlConnection Con = new SqlConnection("data source=.; database=JX; integrated security =SSPI");
        // SqlConnection Con = new SqlConnection("data source=.; database=JX; User Id=sa; password=seahguan");


        //// set the SQL query command
        //// SqlCommand cmd = new SqlCommand("select count(*) from member", Con);

        ////Open the connection//
        //Con.Open();

        //    // Execute the command
        //    SqlDataReader rdr = cmd.ExecuteReader();

        //Console.WriteLine("SQL result : " + rdr);
        //    Console.ReadKey();
        //    // Close the connection
        //    Con.Close();

        public void Openconn()
        {
            //// to load the Ole DB connection string 
            //OdbcConnection con = new OdbcConnection();
            //con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //return con


            // string Constr = ConfigurationManager.ConnectionStrings["PEFADBCN"].ConnectionString.ToString();
            string Constr = ConfigurationManager.ConnectionStrings["PEFADBCN"].ConnectionString;
            try
            {
                SqlHelper helper = new SqlHelper(Constr);

                if (helper.IsConnection)
                {
                    // AppSetting setting = new AppSetting();
                    // setting.SaveConnectionString("cn", Constr);
                    log.Info("Successfull open the DB Connection.");
                    SqlConnection Conn = new SqlConnection(Constr);

                    Conn.Open();
                }
            }
            catch (Exception e)
            {
                log.Fatal("Fail to open the connectode in the program.", e);
            }
        }
    }
}
