
using StudentCourse.Abstraction.Courses.Models;

using StudentCourse.Core.Courses.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentCourse.Core.Courses.Aggregates
{
    public class CourseAggregate : BaseAggregate<CourseEntity>
    {
        ValidationResult validationResult = new ValidationResult();
        public CourseAggregate(CourseEntity entity) : base(entity)
        {

        }

        private ValidationResult ValidateAsset(Course course)
        {
            return validationResult;
        }


        public ValidationResult Register(Course course)
        {
            if (ValidateAsset(course).IsValid)
            {
                course.Id = Entity.Id;
                SetDetails(course);
                //AddEvent(new SAdded(register));
            }
            return validationResult;
        }



        public ValidationResult Update(Course course)
        {
            if (ValidateAsset(course).IsValid)
            {
                SetDetails(course);


            }
            return validationResult;
        }


        public void Delete()
        {
            Entity.IsDeleted = true;

        }
        private void SetDetails(Course course)
        {
            Entity.Id = course.Id;
            Entity.Name = course.Name;
            Entity.DepartmentId = course.DepartmentId;
            Entity.LecturerId = course.LecturerId;
            Entity.Level = course.Level;
          
           

        }


    }
}
