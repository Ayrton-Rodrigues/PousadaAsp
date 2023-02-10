﻿using System;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Entity
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
