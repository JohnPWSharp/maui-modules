﻿using System;
using System.Collections.Generic;

namespace PartsClient.Data
{
    [Serializable]
    public class Part
    {
        public string PartID { get; set; }
        public string PartName { get; set; }
        public List<string> Suppliers { get; set; }
        public DateTime PartAvailableDate { get; set; }
        public string PartType { get; set; }
        public string Href => $"api/parts/{PartID}";
        public string SupplierString
        {
            get
            {
                string result = String.Empty;
                foreach (string supplier in Suppliers)
                {
                    result += $"{supplier}, ";
                }
                result = result.Trim(',', ' ');
                return result;
            }
        }
    }
}