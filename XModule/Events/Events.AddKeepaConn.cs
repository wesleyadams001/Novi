﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Events
{
    /// <summary>
    /// Adding a keepa connection string event
    /// </summary>
    public class AddKeepaConnEvent : PubSubEvent<string> { }
}
