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
    /// The collection changed event for observable collections
    /// </summary>
    public class CollectionChangedEvent : PubSubEvent<IEnumerable<RequestObject>> { }
    
}
