using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;
using XModule.Interfaces;

namespace XModule.Services
{
    public interface IAvailableRequestsService
    {
        ObservableConcurrentCollection<string> GetRequests();
    }
}
