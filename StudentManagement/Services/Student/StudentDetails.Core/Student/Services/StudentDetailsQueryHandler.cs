

using StudentDetails.Abstraction.Repositories;
using StudentDetails.Abstraction.Service;
using StudentDetails.Abstraction.Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentDetails.Core.Services
{
    public class StudentDetailsQueryHandler : IStudentDetailsQueryHandler
    {
        private IStudentRepository _studentRepository;
    
        public StudentDetailsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
           
        }

        public async Task<List<IStudentEntity>> GetAllStudents()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var students = await _studentRepository.FindModelsAsync(search);
            return students.ToList();
        }

      

        public async Task<IStudentEntity> GetStudent(Guid id)
        {
            return await _studentRepository.LoadModelAsync(id);
        }

       
    }
}
