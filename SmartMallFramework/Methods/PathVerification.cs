using System.IO;

namespace SmartMallFramework
{
    /// <summary>
    /// to used as to verify the destination path exists or not.
    /// </summary>
    public static class PathVerification
    {
        public static bool VerifyFile(string FilePath)
        {
            //System.IO.File.Exists(FilePath);
          
            if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), FilePath)))
                return false;
            else
                return true;            
        }

    }
}
