using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Events
{
    public class TemplateCreatedEvent : Event
    {
        public string TemplateID{ get; private set; }

        public TemplateCreatedEvent(string templateID)
        {
            TemplateID = templateID;
        }
    }
}
