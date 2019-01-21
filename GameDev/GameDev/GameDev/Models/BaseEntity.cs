using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.Models
{
    public class BaseEntity<T>
    {
        public string Id { get; set; }

        public string Guid { get; set; }

        public BaseEntity()
        {
            Guid = System.Guid.NewGuid().ToString();
            Id = Guid;
        }
    }
}
