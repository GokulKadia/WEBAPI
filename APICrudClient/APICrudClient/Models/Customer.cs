﻿using System.ComponentModel.DataAnnotations;

namespace APICrudClient.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }

        [StringLength(75)]
        public string firstName { get; set; }

        [StringLength(75)]
        public string lastName { get; set; }

        [StringLength(75)]
        public string phoneNo { get; set; }

        [StringLength(75)]
        public string emailId { get; set; }
    }

}
