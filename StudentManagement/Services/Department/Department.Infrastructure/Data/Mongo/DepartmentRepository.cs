
using MongoDB.Driver;
using StudentDepartment.Abstraction.StudentDepartment.Entities;
using StudentDepartment.Abstraction.StudentDepartment.Enums;
using StudentDepartment.Abstraction.StudentDepartment.Repositories;
using StudentDepartment.Core.Entities;
using StudentDepartment.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using ZA365Solutions.Platform.Common.Enums;

namespace StudentDepartment.Infrastructure.Data.Mongo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MongoContext _context;

        public DepartmentRepository(MongoContext context)
        {
            _context = context;
        }
      
 

        public async Task<IEnumerable<IDepartmentEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType)
        {
            FilterDefinition<DepartmentEntity> filter = null;
            foreach (var parameter in searchParameters.Where(
                    parameter => !string.IsNullOrEmpty(parameter.Name) && !string.IsNullOrEmpty(parameter.Value)))
            {
                var validParameter = Enum.TryParse(parameter.Name.ToUpper(), out SearchOptions option);
                if (!validParameter)
                {
                    continue;
                }
                switch (option)
                {
                    case SearchOptions.ID:
                        if (filter == null)
                        {
                            filter = Builders<DepartmentEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value));
                        }
                        else
                        {
                            filter = Builders<DepartmentEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value)) & filter;
                        }
                        break;


                }

            }
            if (filter == null) throw new ArgumentException("Invalid search parameters specified");
            List<DepartmentEntity> result = await _context.Departments.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IDepartmentEntity> LoadAggregateAsync(Guid id)
        {
            FilterDefinition<DepartmentEntity> filter = Builders<DepartmentEntity>.Filter.Ne("isDeleted", true);

            filter = Builders<DepartmentEntity>.Filter.Eq("_id", id) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid application search parameters specified");

            }
            var result = (await _context.Departments.FindAsync(filter)).FirstOrDefault();
            return result ?? EntityFactory.CreateDepartment();
        }

        public async Task<Guid> SaveAggregateAsync(IDepartmentEntity aggregate)
        {
            FilterDefinition<DepartmentEntity> filter = Builders<DepartmentEntity>.Filter.Eq("_id", aggregate.Id);

            var result = await _context.Departments.FindAsync(filter);

            if (result.Any())
            {
                await _context.Departments.ReplaceOneAsync(filter, aggregate as DepartmentEntity);
            }
            else
            {
                await _context.Departments.InsertOneAsync(aggregate as DepartmentEntity);
            }
            return aggregate.Id;
        }

        public async Task<IEnumerable<IDepartmentEntity>> FindModelsAsync(List<SearchParameter> searchParameters)
        {
            FilterDefinition<DepartmentEntity> filter = Builders<DepartmentEntity>.Filter.Ne("isDeleted", true);
            foreach (var parameter in searchParameters.Where(
                    parameter => !string.IsNullOrEmpty(parameter.Name) && !string.IsNullOrEmpty(parameter.Value)))
            {
                var validParameter = Enum.TryParse(parameter.Name.ToUpper(), out SearchOptions option);
                if (!validParameter)
                {
                    continue;
                }


            }
            if (filter == null) throw new ArgumentException("Invalid search parameters specified");
            List<DepartmentEntity> result = await _context.Departments.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IDepartmentEntity> LoadModelAsync(Guid modelId)
        {
            var filter = Builders<DepartmentEntity>.Filter.Eq("_id", modelId);
            filter = Builders<DepartmentEntity>.Filter.Ne("isDeleted", true) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid  search parameters specified");
            }
            var result = await _context.Departments.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task<Guid> SaveModelAsync(IDepartmentEntity model)
        {
            FilterDefinition<DepartmentEntity> filter = Builders<DepartmentEntity>.Filter.Eq("_id", model.Id);

            var result = await _context.Departments.FindAsync(filter);

            if (result.Any())
            {
                await _context.Departments.ReplaceOneAsync(filter, model as DepartmentEntity);
            }
            else
            {
                await _context.Departments.InsertOneAsync(model as DepartmentEntity);
            }

            return model.Id;
        }
    }
}
