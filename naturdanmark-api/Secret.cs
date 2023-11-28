namespace naturdanmark_api
{
    public class Secret
    {
        private static readonly string _secret = "Data Source=mssql12.unoeuro.com;Initial Catalog=welcome_to_my_domain_dk_db_domain;User ID=welcome_to_my_domain_dk;Password=BcF9ezDfmR2npgyd364w;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static string  secret { get { return _secret; } }

    }
}
