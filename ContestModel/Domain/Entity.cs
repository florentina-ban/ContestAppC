﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContestModel.Domain
{
    [Serializable]
    public abstract class Entity <ID>
    {
        public ID Id { get; set; }

        protected Entity(ID id)
        {
            Id = id;
        }
    }
}
