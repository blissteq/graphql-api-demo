
using StudentDepartment.Abstraction.StudentDepartment.Models;
using StudentDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDepartment.Core.Aggregates
{
    public class DepartmentAggregate : BaseAggregate<DepartmentEntity>
    {
        ValidationResult validationResult = new ValidationResult();
        public DepartmentAggregate(DepartmentEntity entity) : base(entity)
        {

        }

        private ValidationResult ValidateAsset(Department department)
        {
            return validationResult;
        }


        public ValidationResult Register(Department department)
        {
            if (ValidateAsset(department).IsValid)
            {
                department.Id = Entity.Id;
                SetDetails(department);
                //AddEvent(new SAdded(register));
            }
            return validationResult;
        }



        public ValidationResult Update(Department department)
        {
            if (ValidateAsset(department).IsValid)
            {
                SetDetails(department);


            }
            return validationResult;
        }


        public void Delete()
        {
            Entity.IsDeleted = true;

        }
        private void SetDetails(Department department )
        {
            Entity.Id = department.Id;
            Entity.Name = department.Name;
         
           

        }


    }
}
