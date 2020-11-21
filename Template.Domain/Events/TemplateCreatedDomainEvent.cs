using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Events
{
    public class TemplateCreatedDomainEvent : DomainEvent
    {
        public string TemplateID { get; set; }
    }
}
