
using MongoDB.Driver;
using StudentCourse.Abstraction.Courses.Entities;
using StudentCourse.Abstraction.Courses.Enums;
using StudentCourse.Abstraction.Courses.Repositories;
using StudentCourse.Core.Courses.Entities;
using StudentCourse.Core.Courses.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using ZA365Solutions.Platform.Common.Enums;

namespace StudentCourse.Infrastructure.Course.Data.Mongo
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MongoContext _context;
        public CourseRepository(MongoContext context)
        {
            _context = context;
        }
       

        public async Task<IEnumerable<ICourseEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType)
        {
            FilterDefinition<CourseEntity> filter = null;
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
                            filter = Builders<CourseEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value));
                        }
                        else
                        {
                            filter = Builders<CourseEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value)) & filter;
                        }
                        break;


                }

            }
            if (filter == null) throw new ArgumentException("Invalid search parameters specified");
            List<CourseEntity> result = await _context.Courses.Find(filter).ToListAsync();
            return result;
        }

        public async Task<ICourseEntity> LoadAggregateAsync(Guid id)
        {
            FilterDefinition<CourseEntity> filter = Builders<CourseEntity>.Filter.Ne("isDeleted", true);

            filter = Builders<CourseEntity>.Filter.Eq("_id", id) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid application search parameters specified");

            }
            var result = (await _context.Courses.FindAsync(filter)).FirstOrDefault();
            return result ?? EntityFactory.CreateCourse();
        }

        public async Task<Guid> SaveAggregateAsync(ICourseEntity aggregate)
        {
            FilterDefinition<CourseEntity> filter = Builders<CourseEntity>.Filter.Eq("_id", aggregate.Id);

            var result = await _context.Courses.FindAsync(filter);

            if (result.Any())
            {
                await _context.Courses.ReplaceOneAsync(filter, aggregate as CourseEntity);
            }
            else
            {
                await _context.Courses.InsertOneAsync(aggregate as CourseEntity);
            }
            return aggregate.Id;
        }

        public async Task<IEnumerable<ICourseEntity>> FindModelsAsync(List<SearchParameter> searchParameters)
        {
            FilterDefinition<CourseEntity> filter = Builders<CourseEntity>.Filter.Ne("isDeleted", true);
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
            List<CourseEntity> result = await _context.Courses.Find(filter).ToListAsync();
            return result;
        }

        public async Task<ICourseEntity> LoadModelAsync(Guid modelId)
        {
            var filter = Builders<CourseEntity>.Filter.Eq("_id", modelId);
            filter = Builders<CourseEntity>.Filter.Ne("isDeleted", true) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid  search parameters specified");
            }
            var result = await _context.Courses.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task<Guid> SaveModelAsync(ICourseEntity model)
        {
            FilterDefinition<CourseEntity> filter = Builders<CourseEntity>.Filter.Eq("_id", model.Id);

            var result = await _context.Courses.FindAsync(filter);

            if (result.Any())
            {
                await _context.Courses.ReplaceOneAsync(filter, model as CourseEntity);
            }
            else
            {
                await _context.Courses.InsertOneAsync(model as CourseEntity);
            }

            return model.Id;
        }
    }
}
