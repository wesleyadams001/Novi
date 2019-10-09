using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepaModule.DataAccess
{
    public static class KeepaFilter
    {
        private static void Filter(BufferBlock<IDataObject> broadcast, out BufferBlock<Student> outBuffer1, out BufferBlock<Grades> outBuffer2, out BufferBlock<Guardians> outBuffer3, out BufferBlock<SchoolClasses> outBuffer4)
        {
            //Configure the dataflow options
            DataflowLinkOptions opts = new DataflowLinkOptions
            {
                PropagateCompletion = true
            };

            //Create filters for each type
            Predicate<IDataObject> StudentFilter = (IDataObject r) => { return r.RecordType == RecordType.Student; };
            Predicate<IDataObject> GuardianFilter = (IDataObject r) => { return r.RecordType == RecordType.Guardian; };
            Predicate<IDataObject> GradeFilter = (IDataObject r) => { return r.RecordType == RecordType.Grade; };
            Predicate<IDataObject> ClassFilter = (IDataObject r) => { return r.RecordType == RecordType.Class; };

            //Create recieving buffers for each record type
            var bufferblock = new TransformBlock<IDataObject, Student>(x => {

                var dobj = (DataObject)x;
                var val = new Student(dobj.StudentNo, dobj.GuardianId, dobj.LastName, dobj.FirstName, dobj.City);
                return val;
            });
            var bufferblock2 = new TransformBlock<IDataObject, Grades>(x => {

                var dobj = (DataObject2)x;
                var val = new Grades(dobj.ClassId, dobj.StudentNo, dobj.GradeT1, dobj.GradeT2, dobj.GradeT3, dobj.PassFail);
                return val;
            });
            var bufferblock3 = new TransformBlock<IDataObject, Guardians>(x => {

                var dobj = (DataObject3)x;
                var val = new Guardians(dobj.StudentNo, dobj.ParentFirstName, dobj.ParentLastName, dobj.ContactNumber);
                return val;
            });
            var bufferblock4 = new TransformBlock<IDataObject, SchoolClasses>(x => {

                var dobj = (DataObject4)x;
                var val = new SchoolClasses(dobj.StudentNo, dobj.ClassId, dobj.Class);
                return val;
            });

            //Create outbound buffers
            outBuffer1 = new BufferBlock<Student>();
            outBuffer2 = new BufferBlock<Grades>();
            outBuffer3 = new BufferBlock<Guardians>();
            outBuffer4 = new BufferBlock<SchoolClasses>();

            //set up links using propogate oncompletion and appropriate filters
            broadcast.LinkTo(bufferblock, opts, StudentFilter);
            broadcast.LinkTo(bufferblock2, opts, GradeFilter);
            broadcast.LinkTo(bufferblock3, opts, GuardianFilter);
            broadcast.LinkTo(bufferblock4, opts, ClassFilter);

            //Out put the transformed values through the outbound buffers
            bufferblock.LinkTo(outBuffer1, opts);
            bufferblock2.LinkTo(outBuffer2, opts);
            bufferblock3.LinkTo(outBuffer3, opts);
            bufferblock4.LinkTo(outBuffer4, opts);

        }
    }
}
