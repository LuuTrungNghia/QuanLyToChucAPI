﻿namespace QuanLyToChucAPI.Helpers
{
    public class JwtSetting
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
