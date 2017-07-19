using System;

namespace SmartMallFramework
{
    class DefinePath
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// here is the define the Expoert storega path which it create the path in the same project folder 
        /// </summary>
        /// <param name="ProjectPath"></param>
        /// <returns></returns>
        public string setupExtenReportPath(out string ProjectPath) //(string ActualPath)
        {
            try
            {
                // Define the screen capture image directory folder             
                //string DesDirectroy = System.IO.Directory.GetCurrentDirectory();
                //string startupPath = Environment.CurrentDirectory;

                //Get the Project Directory Info
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualpath = path.Substring(0, path.LastIndexOf("bin"));
                string projectpath = new Uri(actualpath).LocalPath + "Reports";

                //create the Image directory. If the folder exits it will ignored else if not exits it will create the folder
                // Create Reports folder
                System.IO.Directory.CreateDirectory(projectpath);

                bool tmpresult = PathVerification.VerifyFile(projectpath);
                if (tmpresult == false)
                {
                    log.Fatal("Fail to create Extent report folder.Folder Name : " + projectpath);
                    ProjectPath = "";
                    return ProjectPath;
                }
                else
                {
                    ProjectPath = projectpath;
                    return ProjectPath;
                }
                    
                
            }
            catch (Exception e)
            {
                log.Fatal("Encounter Unknow Error in the Create Folders", e);
                ProjectPath = "";
                return ProjectPath;                
            }
        }

        /// <summary>
        /// setup the path of the capture the image path storage.
        /// </summary>
        /// <param name="ImagesPath"></param>
        /// <returns></returns>
        /// 
        public int add1(int a, int b, out int result)
        {
            result = a + b;
            return result;
        }

        public string setupExtenImagesPath(out string ImagesPath)
        {
            try
            {
                // Define the screen capture image directory folder             
                //string DesDirectroy = System.IO.Directory.GetCurrentDirectory();
                //string startupPath = Environment.CurrentDirectory;

                //Get the Project Directory Info
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualpath = path.Substring(0, path.LastIndexOf("bin"));

                // Create Images Folder Under Reports Folder
                string projectpath = new Uri(actualpath).LocalPath + "Reports\\Images\\";

                // Create Reports folder
                System.IO.Directory.CreateDirectory(projectpath);

                bool tmpresult = PathVerification.VerifyFile(projectpath);

                if (tmpresult == false)
                {
                    log.Fatal("Fail to create Images folder.Folder Name : " + projectpath);
                    ImagesPath = "";
                    return ImagesPath;
                }
                else
                {
                    ImagesPath = projectpath;
                    return ImagesPath;
                }             
            }
            catch (Exception e)
            {
                log.Fatal("Encounter Unknow Error in the Create Folders", e);
                ImagesPath = "";
                return ImagesPath;
            }
        }
  
        public string ActualPath { get; set; }
    }
}
