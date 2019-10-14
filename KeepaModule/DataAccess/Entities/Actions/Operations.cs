using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace KeepaModule.DataAccess.Entities.Actions
{
    public static class Operations
    {
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<best_sellers> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<best_sellers>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<best_sellers>(a =>
               context.best_sellers.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }

        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<category> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<category>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<category>(a =>
               context.categories.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<category_tree> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<category_tree>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<category_tree>(a =>
               context.category_tree.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<fba_fees> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<fba_fees>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<fba_fees>(a =>
               context.fba_fees.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<feature> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<feature>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<feature>(a =>
               context.features.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<language> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<language>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<language>(a =>
               context.languages.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<most_rated_sellers> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<most_rated_sellers>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<most_rated_sellers>(a =>
               context.most_rated_sellers.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<price_history> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<price_history>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<price_history>(a =>
               context.price_history.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<product> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<product>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<product>(a =>
               context.products.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<seller> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<seller>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<seller>(a =>
               context.sellers.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<sellers_listed_items> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<sellers_listed_items>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<sellers_listed_items>(a =>
               context.sellers_listed_items.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<variation> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<variation>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<variation>(a =>
               context.variations.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<ean> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<ean>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<ean>(a =>
               context.eans.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<freq_bought_together> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<freq_bought_together>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<freq_bought_together>(a =>
               context.freq_bought_together.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<statistic> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<statistic>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<statistic>(a =>
               context.statistics.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
        /// <summary>
        /// Inserts records of the appropriate type to the database
        /// </summary>
        /// <param name="broadcast"></param>
        /// <param name="batchSize"></param>
        /// <param name="context"></param>
        public static void Insert(BufferBlock<upc> broadcast, KeepaContext context)
        {
            // Create a BatchBlock<Employee> that holds several Employee objects and
            // then propagates them out as an array.
            //var batchEmployees = new BatchBlock<Student>(batchSize);
            var queue = new BufferBlock<upc>();
            // Create an ActionBlock<Employee[]> object that adds multiple
            // employee entries to the database.
            var insertEmployees = new ActionBlock<upc>(a =>
               context.upcs.Add(a));//InsertEmployees(a, connectionString)

            //Link broadcast to batch
            broadcast.LinkTo(queue);

            // Link the batch block to the action block.
            queue.LinkTo(insertEmployees);

            // When the batch block completes, set the action block also to complete.
            queue.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

            // Set the batch block to the completed state and wait for 
            // all insert operations to complete.
            queue.Complete();
            insertEmployees.Completion.Wait();
        }
    }
}