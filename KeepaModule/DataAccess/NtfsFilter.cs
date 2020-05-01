
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using XModule.Interfaces;
using static XModule.Constants.Enums;


namespace NtfsModule.DataAccess
{
    /// <summary>
    /// The Ntfs Specific Allocator
    /// </summary>
    public class Allocator //: IAllocator
    {
        private const int BATCH_SIZE = 10000;
        /// <summary>
        /// Default constructor of Allocator
        /// </summary>
        public Allocator()
        {
            
            this.TopBlock = new BufferBlock<IRecord>();

            this.LinkOptions = new DataflowLinkOptions { PropagateCompletion = true };


        }
        private BufferBlock<IRecord> TopBlock { get; set; }

        private DataflowLinkOptions LinkOptions { get; set; }


        /// <summary>
        /// Allocate IRecords to appropriate queues
        /// </summary>
        /// <param name="broadcast"></param>
        public void Filter(IRecord broadcast)
        {

            this.TopBlock.Post(broadcast);

        }


    }
}
