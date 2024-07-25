namespace Friends.DAL
{
    public class Data
    {
        private readonly string _connectionString = "server=ELAD\\SA;initial catalog=Friends; user id=sa;" +
           "password=1234;TrustServerCertificate=Yes";
        private static Data _data;
        private DataLayer DataLayer;
        private Data()
        {
            DataLayer = new DataLayer(_connectionString);
        }
        public static DataLayer Get
        {
            get
            {
                if(_data == null)
                    _data = new Data();
                return _data.DataLayer;
            }
        }
    }
}
