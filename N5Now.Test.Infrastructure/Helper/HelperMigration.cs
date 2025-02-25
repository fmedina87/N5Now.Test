using System.Text;

namespace N5Now.Test.Infrastructure.Helper
{
    public abstract class HelperMigration
    {
        public static string ReadSqlFile(string fileName)
        {
            string appDirectory = AppContext.BaseDirectory;
            string uploadTablesDirectory = Path.Combine(appDirectory, "LoadData");
            string scriptPath = Path.Combine(uploadTablesDirectory, fileName);
            string textFile = ReadFile(scriptPath);
            return textFile;
        }       
        private static string ReadFile(string scriptPath)
        {
            var encoding = Encoding.Latin1;
            using StreamReader sr = new(scriptPath, encoding);
            string contenido = sr.ReadToEnd();
            return contenido;
        }        
    }
}
