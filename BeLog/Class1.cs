

namespace Entity
{
    using global::System;

    public class BeLog
    {
        public string idUser { get; set; }
        public string Application { get; set; }
        public DateTime dateTime { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        public string IpClient { get; set; }
    }
}

