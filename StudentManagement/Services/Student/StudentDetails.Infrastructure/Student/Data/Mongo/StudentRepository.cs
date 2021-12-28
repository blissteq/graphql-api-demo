
using MongoDB.Driver;
using StudentDetails.Abstraction.Enums;
using StudentDetails.Abstraction.Repositories;
using StudentDetails.Abstraction.Student.Entities;
using StudentDetails.Core.Entities;
using StudentDetails.Core.Services;
using StudentDetails.Infrastructure.Data.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using ZA365Solutions.Platform.Common.Enums;

namespace StudentDetails.Infrastruture.Data.Mongo
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MongoContext _context;
        public StudentRepository(MongoContext context)
        {
            _context = context;
        }

        public StudentRepository(string serverName, string databaseName)
        {
            _context = new MongoContext(serverName, databaseName);
        }


        public async Task<IEnumerable<IStudentEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType)
        {
            FilterDefinition<StudentEntity> filter = null;
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
                            filter = Builders<StudentEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value));
                        }
                        else
                        {
                            filter = Builders<StudentEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value)) & filter;
                        }
                        break;


                }

            }
            if (filter == null) throw new ArgumentException("Invalid search parameters specified");
            List<StudentEntity> result = await _context.Studentss.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IStudentEntity> LoadAggregateAsync(Guid id)
        {
            FilterDefinition<StudentEntity> filter = Builders<StudentEntity>.Filter.Ne("isDeleted", true);

            filter = Builders<StudentEntity>.Filter.Eq("_id", id) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid application search parameters specified");

            }
            var result = (await _context.Studentss.FindAsync(filter)).FirstOrDefault();
            return result ?? EntityFactory.CreateStudent();
        }

        public async Task<Guid> SaveAggregateAsync(IStudentEntity aggregate)
        {
            FilterDefinition<StudentEntity> filter = Builders<StudentEntity>.Filter.Eq("_id", aggregate.Id);

            var result = await _context.Studentss.FindAsync(filter);

            if (result.Any())
            {
                await _context.Studentss.ReplaceOneAsync(filter, aggregate as StudentEntity);
            }
            else
            {
                await _context.Studentss.InsertOneAsync(aggregate as StudentEntity);
            }
            return aggregate.Id;
        }

        public async Task<IEnumerable<IStudentEntity>> FindModelsAsync(List<SearchParameter> searchParameters)
        {
            FilterDefinition<StudentEntity> filter = Builders<StudentEntity>.Filter.Ne("isDeleted", true);
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
            List<StudentEntity> result = await _context.Studentss.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IStudentEntity> LoadModelAsync(Guid modelId)
        {
            var filter = Builders<StudentEntity>.Filter.Eq("_id", modelId);
            filter = Builders<StudentEntity>.Filter.Ne("isDeleted", true) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid  search parameters specified");
            }
            var result = await _context.Studentss.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task<Guid> SaveModelAsync(IStudentEntity model)
        {
            FilterDefinition<StudentEntity> filter = Builders<StudentEntity>.Filter.Eq("_id", model.Id);

            var result = await _context.Studentss.FindAsync(filter);

            if (result.Any())
            {
                await _context.Studentss.ReplaceOneAsync(filter, model as StudentEntity);
            }
            else
            {
                await _context.Studentss.InsertOneAsync(model as StudentEntity);
            }

            return model.Id;
        }

    }
    }
