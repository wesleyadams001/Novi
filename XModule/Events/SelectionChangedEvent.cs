using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;

namespace XModule.Events
{
    public class SelectionChangedEvent : PubSubEvent<RequestObject>{}
}
