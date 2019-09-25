using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Interfaces
{
    /// <summary>
    /// The Interface that Pairs shoudl implement
    /// </summary>
    public interface IPair
    {
        /// <summary>
        /// The number of values in the Pair
        /// </summary>
        int Degree { get; }

    }
}
