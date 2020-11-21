using BuildingBlocks.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Infrastructure.IntegrationEvents
{
    public class TemplateCreatedIntegrationEvent : Event
    {
        public string TemplateID{ get; private set; }

        public TemplateCreatedIntegrationEvent(string templateID)
        {
            TemplateID = templateID;
        }
    }
}
