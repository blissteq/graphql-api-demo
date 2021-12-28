

using HotChocolate.Types;
using StudentDetails.Abstraction.Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphQL.API.GrapgQL.Types
{
    public class StudentType : ObjectType<IStudentEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<IStudentEntity> descriptor)
        {
            descriptor.Field(s => s.Id).Type<UuidType>();
            descriptor.Field(s => s.DepartmentId).Type<UuidType>();
            //    descriptor.Field("department").Resolve(async (ctx, ct) =>
            //    {
            //        return (await ctx.Service<IDemoGraphQLQueryHandler>().GetAllDepartments()).FirstOrDefault(a => a.Id == ctx.Parent<IStudentEntity>().DepartmentId);
            //    });
            //    descriptor.Field("course").Resolve(async(ctx, ct) => (await ctx.Service<IDemoGraphQLQueryHandler>().GetAllCourses()).Where(a => a.Level == ctx.Parent<IStudentEntity>().Level).Where(a => a.DepartmentId == ctx.Parent<IStudentEntity>().DepartmentId).ToList());

            //}
        }
    }
}
