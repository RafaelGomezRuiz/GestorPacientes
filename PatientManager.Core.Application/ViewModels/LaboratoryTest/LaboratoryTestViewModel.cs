﻿using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.LaboratoryTest
{
    public class LaboratoryTestViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoomViewModel ConsultingRoom { get; set; }
    }
}
