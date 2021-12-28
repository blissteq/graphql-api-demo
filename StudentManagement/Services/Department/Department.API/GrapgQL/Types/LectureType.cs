
using HotChocolate.Types;
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using StudentDepartment.Abstraction.StudentDepartment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDepartment.API.GrapgQL.Types
{
    public class LectureType : ObjectType<ILecturerEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<ILecturerEntity> descriptor)
        {
            descriptor.Field(s => s.Id).Type<IdType>();
            descriptor.Field(s => s.DepartmentId).Type<UuidType>();
     
            descriptor.Field("department").Resolve(async(ctx, ct) => (await ctx.Service<IDemoGraphQLQueryHandler>().GetAllDepartments()).FirstOrDefault(a => a.Id == ctx.Parent<ILecturerEntity>().DepartmentId));
           


        }
    }
}
