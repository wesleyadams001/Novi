using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XModule.Services
{
    public interface IKeyService
    {
        ObservableConcurrentDictionary<string, string> GetKeys();

        ObservableConcurrentDictionary<string, string> GetConnections();
    }
}
