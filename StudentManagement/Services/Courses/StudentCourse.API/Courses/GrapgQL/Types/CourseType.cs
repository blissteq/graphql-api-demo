
using HotChocolate.Types;
using StudentCourse.Abstraction.Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.API.Courses.GrapgQL.Types
{
    public class CourseType : ObjectType<ICourseEntity>
    {
        protected override void  Configure(IObjectTypeDescriptor<ICourseEntity> descriptor)
        {
            descriptor.Field(s => s.Id).Type<IdType>();
            descriptor.Field(s => s.DepartmentId).Type<UuidType>();
            descriptor.Field(s => s.LecturerId).Type<UuidType>();
            //descriptor.Field("department").Resolve(async(ctx, ct) => (await ctx.Service<IDemoGraphQLQueryHandler>().GetAllDepartments()).FirstOrDefault(a => a.Id == ctx.Parent<ICourseEntity>().DepartmentId));
            //descriptor.Field("lecturer").Resolve(async(ctx, ct) =>(await ctx.Service<IDemoGraphQLQueryHandler>().GetAllLecturers()).FirstOrDefault(a => a.Id == ctx.Parent<ICourseEntity>().LecturerId));


        }
    }
}
