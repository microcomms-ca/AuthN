﻿namespace Server.Models
{
    public class TokenResponse
    {
        public string id_token { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }

        public string code { get; set; }

        public string error { get; set; }
        public bool HasError => !string.IsNullOrEmpty(error);

    }
}