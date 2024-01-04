﻿using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.DTOs.Characteristics
{
    public class CharacteristicDto
    {
        public Guid Guid { get; set; }
        public string BusinessField { get; set; }
        public string CompanyType { get; set; }

        public static implicit operator Characteristic(CharacteristicDto dto)
        {
            return new Characteristic
            {
                Guid = dto.Guid,
                BusinessField = dto.BusinessField,
                CompanyType = dto.CompanyType,
                ModifiedDate = DateTime.Now
            };
        }

        public static explicit operator CharacteristicDto(Characteristic characteristic)
        {
            return new CharacteristicDto
            {
                Guid = characteristic.Guid,
                BusinessField = characteristic.BusinessField,
                CompanyType = characteristic.CompanyType
            };
        }
    }
}