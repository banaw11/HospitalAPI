﻿using HospitalAPI.Helpers.Enums;

namespace HospitalAPI.Entities
{
    public class Employee : User
    {
        public Profession Profession { get; set; }
        public Specialization Specialization { get; set; }
        public string RtPPNumber { get; set; }
    }
}
