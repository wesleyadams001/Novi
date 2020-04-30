using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NtfsModule.Tools
{
    public class IncrementalNumberGenerator
    {
        private ulong _currentValue;
        private readonly EventWaitHandle _waitHandle;

        public IncrementalNumberGenerator()
        {
            //Set the wait handle
            _waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, Guid.NewGuid().ToString("N"));

            //load current value
            _currentValue = Properties.Settings.Default.IncNumber;
            
        }

        /// <summary>
        /// Gets the next value
        /// </summary>
        /// <returns></returns>
        public ulong Next()
        {
            try
            {
                //get wait handle
                _waitHandle.WaitOne();

                //increment value
                _currentValue++;

                //update persistence
                Properties.Settings.Default.IncNumber = _currentValue;

                //save properties
                Properties.Settings.Default.Save();

                //refresh previously updated properties
                Properties.Settings.Default.Reload();

                return _currentValue;
            }
            finally
            {
                //allow threads
                _waitHandle.Set();
            }
        }

        /// <summary>
        /// Resets the current value
        /// </summary>
        /// <returns></returns>
        public bool CheckReset()
        {
            bool isModified = false;
            try
            {
                //blocks for current operation
                _waitHandle.WaitOne();

                //Check value
                var currentValue = Properties.Settings.Default.IncNumber;

                if (currentValue > 0)
                {
                    //set value
                    Properties.Settings.Default.IncNumber = 0;

                    //save properties
                    Properties.Settings.Default.Save();

                    //refresh previously updated properties
                    Properties.Settings.Default.Reload();

                    //indicate change
                    isModified = true;
                }
            }
            finally
            {
                //release
                _waitHandle.Set();
            }

            //Indicates whether value in file was reset
            return isModified;    
            
        }
    }
}
