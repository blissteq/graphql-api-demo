

using StudentDetails.Abstraction.Models;
using StudentDetails.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDetail.Core.Aggregates
{
   public  class StudentAggregate : BaseAggregate<StudentEntity>
    {
        ValidationResult validationResult = new ValidationResult();
        public StudentAggregate(StudentEntity entity) : base(entity)
        {

        }

        private ValidationResult ValidateAsset(StudentDTO student)
        {
            return validationResult;
        }

        
        public ValidationResult Register(StudentDTO student)
        {
            if (ValidateAsset(student).IsValid)
            {
                student.Id = Entity.Id;
                SetDetails(student);
                //AddEvent(new SAdded(register));
            }
            return validationResult;
        }

       
       
        public ValidationResult Update(StudentDTO student)
        {
            if (ValidateAsset(student).IsValid)
            {
                SetDetails(student);
               

            }
            return validationResult;
        }

        
        public void Delete()
        {
            Entity.IsDeleted = true;
            
        }
        private void SetDetails(StudentDTO student)
        {
            Entity.Id = student.Id;
            Entity.Name = student.Name;
            Entity.DepartmentId = student.DepartmentId;
            Entity.Gender = student.Gender;
            Entity.Address = student.Address;
            Entity.Level = student.Level;
            
        }


    }
}

