
using HotChocolate.Types;
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using StudentDepartment.Abstraction.StudentDepartment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDepartment.API.GrapgQL.Types
{
    public class DepartmentType : ObjectType<IDepartmentEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<IDepartmentEntity> descriptor)
        {
            descriptor.Field(d => d.Id).Type<IdType>();
          
            descriptor.Field("lecturer").Resolve(async(ctx, ct) => (await ctx.Service<IDemoGraphQLQueryHandler>().GetAllLecturers()).Where(a => a.DepartmentId == ctx.Parent<IDepartmentEntity>().Id).ToList());
         

        }
    }
}
