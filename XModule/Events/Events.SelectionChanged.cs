using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;

namespace XModule.Events
{
    /// <summary>
    /// The selection changed event for request objects
    /// </summary>
    public class SelectionChangedEvent : PubSubEvent<RequestObject>{}

    
}
