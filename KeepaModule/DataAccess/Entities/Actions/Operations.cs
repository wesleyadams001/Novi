using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using XModule.Interfaces;

namespace KeepaModule.DataAccess.Entities.Actions
{
    public static class Operations<TEntity> where TEntity : class
    {
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BatchBlock<TEntity> broadcast, KeepaContext context) 
        {
            // Create a BatchBlock<best_sellers> that holds several best_seller objects and
            // then propagates them out as an array.
            //var batchRecs = new BatchBlock<TEntity>(1000);
            //var queue = new BufferBlock<best_sellers>();

            // Create an ActionBlock<best_seller[]> object that adds multiple
            // best_seller entries to the database.
            var insertEmployees = new ActionBlock<TEntity[]>(a =>
               context.Set<TEntity>().AddRange(a)
               );

            //Link broadcast to batch
            broadcast.LinkTo(insertEmployees, new DataflowLinkOptions { PropagateCompletion = true });

            // Link the batch block to the action block.
            //batchRecs.LinkTo(insertEmployees, new DataflowLinkOptions { PropagateCompletion = true });

            // When the batch block completes, set the action block also to complete.
            broadcast.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            broadcast.Complete();
            insertEmployees.Completion.Wait();
        }
    }
}

