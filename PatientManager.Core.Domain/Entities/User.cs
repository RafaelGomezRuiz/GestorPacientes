﻿using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string?  UserName { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; }
    }
}
