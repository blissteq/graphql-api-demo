
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using StudentDepartment.Abstraction.StudentDepartment.Repositories;
using StudentDepartment.Abstraction.StudentDepartment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDepartment.Core.Services
{
    public class DemoGraphQLQueryHandler : IDemoGraphQLQueryHandler
    {
  
        private IDepartmentRepository _departmentRepository;

        private ILecturerRepository _lecturerRepository;
        public DemoGraphQLQueryHandler(IDepartmentRepository departmentRepository,ILecturerRepository lecturerRepository)
        {
           
            _departmentRepository = departmentRepository;
            _lecturerRepository = lecturerRepository;
           
        }


        public async Task<List<IDepartmentEntity>> GetAllDepartments()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var students = await _departmentRepository.FindModelsAsync(search);
            return students.ToList();
        }



        public async Task<IDepartmentEntity> GetDepartment(Guid id)
        {
            return await _departmentRepository.LoadModelAsync(id);
        }

       


        public async Task<ILecturerEntity> GetLecturer(Guid id)
        {
            return await _lecturerRepository.LoadModelAsync(id);
        }

        public async Task<List<ILecturerEntity>> GetAllLecturers()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var lecturers = await _lecturerRepository.FindModelsAsync(search);
            return lecturers.ToList();
        }
    }
}
