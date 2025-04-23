﻿
namespace GenericRepository.BaseItems
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set;}
        public DateTime CreatedDate { get; set;} = DateTime.Now;
    }
}
