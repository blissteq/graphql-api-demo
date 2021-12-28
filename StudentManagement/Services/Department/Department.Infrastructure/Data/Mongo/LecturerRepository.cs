
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
  public  class LecturerRepository : ILecturerRepository
    {
        private readonly MongoContext _context;

        public LecturerRepository(MongoContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<ILecturerEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType)
        {
            FilterDefinition<LecturerEntity> filter = null;
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
                            filter = Builders<LecturerEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value));
                        }
                        else
                        {
                            filter = Builders<LecturerEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value)) & filter;
                        }
                        break;


                }

            }
            if (filter == null) throw new ArgumentException("Invalid search parameters specified");
            List<LecturerEntity> result = await _context.Lecturers.Find(filter).ToListAsync();
            return result;
        }

        public async Task<ILecturerEntity> LoadAggregateAsync(Guid id)
        {
            FilterDefinition<LecturerEntity> filter = Builders<LecturerEntity>.Filter.Ne("isDeleted", true);

            filter = Builders<LecturerEntity>.Filter.Eq("_id", id) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid application search parameters specified");

            }
            var result = (await _context.Lecturers.FindAsync(filter)).FirstOrDefault();
            return result ?? EntityFactory.CreateLecturer();
        }

        public async Task<Guid> SaveAggregateAsync(ILecturerEntity aggregate)
        {
            FilterDefinition<LecturerEntity> filter = Builders<LecturerEntity>.Filter.Eq("_id", aggregate.Id);

            var result = await _context.Lecturers.FindAsync(filter);

            if (result.Any())
            {
                await _context.Lecturers.ReplaceOneAsync(filter, aggregate as LecturerEntity);
            }
            else
            {
                await _context.Lecturers.InsertOneAsync(aggregate as LecturerEntity);
            }
            return aggregate.Id;
        }

        public async Task<IEnumerable<ILecturerEntity>> FindModelsAsync(List<SearchParameter> searchParameters)
        {
            FilterDefinition<LecturerEntity> filter = Builders<LecturerEntity>.Filter.Ne("isDeleted", true);
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
            List<LecturerEntity> result = await _context.Lecturers.Find(filter).ToListAsync();
            return result;
        }

        public async Task<ILecturerEntity> LoadModelAsync(Guid modelId)
        {
            var filter = Builders<LecturerEntity>.Filter.Eq("_id", modelId);
            filter = Builders<LecturerEntity>.Filter.Ne("isDeleted", true) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid  search parameters specified");
            }
            var result = await _context.Lecturers.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task<Guid> SaveModelAsync(ILecturerEntity model)
        {
            FilterDefinition<LecturerEntity> filter = Builders<LecturerEntity>.Filter.Eq("_id", model.Id);

            var result = await _context.Lecturers.FindAsync(filter);

            if (result.Any())
            {
                await _context.Lecturers.ReplaceOneAsync(filter, model as LecturerEntity);
            }
            else
            {
                await _context.Lecturers.InsertOneAsync(model as LecturerEntity);
            }

            return model.Id;
        }
    }
}
