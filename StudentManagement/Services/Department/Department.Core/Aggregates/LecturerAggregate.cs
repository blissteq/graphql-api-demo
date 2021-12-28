
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
    public class LecturerAggregate : BaseAggregate<LecturerEntity>
    {
        ValidationResult validationResult = new ValidationResult();
        public LecturerAggregate(LecturerEntity entity) : base(entity)
        {

        }

        private ValidationResult ValidateAsset(Lecturer lecturer)
        {
            return validationResult;
        }


        public ValidationResult Register(Lecturer lecturer)
        {
            if (ValidateAsset(lecturer).IsValid)
            {
                lecturer.Id = Entity.Id;
                SetDetails(lecturer);
                //AddEvent(new SAdded(register));
            }
            return validationResult;
        }



        public ValidationResult Update(Lecturer lecturer)
        {
            if (ValidateAsset(lecturer).IsValid)
            {
                SetDetails(lecturer);


            }
            return validationResult;
        }


        public void Delete()
        {
            Entity.IsDeleted = true;

        }
        private void SetDetails(Lecturer lecturer)
        {
            Entity.Id = lecturer.Id;
            Entity.Name = lecturer.Name;
            Entity.DepartmentId = lecturer.DepartmentId;
            Entity.CourseId = lecturer.CourseId;
            
           
        }


    }
}
