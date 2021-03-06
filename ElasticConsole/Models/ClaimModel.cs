﻿using System;

namespace ElasticConsole.Models
{
    public class ClaimModel
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
        public int Size { get; set; }
        public ClientType Origin { get; set; }
    }
}
