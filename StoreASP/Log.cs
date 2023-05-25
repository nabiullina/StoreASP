namespace StoreASP {
    public class Log {
        public string path = "Log.txt";
        public void WriteLog(string log) {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(log);
            sw.WriteLine();
            sw.Close();
        }
    }
}
