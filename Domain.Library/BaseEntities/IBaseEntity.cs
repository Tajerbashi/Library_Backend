﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.BaseEntities
{
    public interface IBaseEntity
    {
    }
    public abstract class BaseEntity<T> : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T ID { get; set; }
        public Guid Guid { get; set; }
        public T CreateByID { get; set; }
        public T UpdateByID { get; set; }
        public T DeleteByID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    public abstract class BaseEntity: BaseEntity<long>
    {
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
    public abstract class GeneralEntity : BaseEntity
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
