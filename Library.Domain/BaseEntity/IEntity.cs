﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public interface IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelted { get; set; }

    }
}
