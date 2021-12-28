using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;
using ZA365Solutions.Platform.Common.Enums;

namespace StudentDepartment.Abstraction.StudentDepartment.Repositories
{
  public  interface IRepository<T,TId>where T : IAggregateRoot
    {
        Task<IEnumerable<T>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);
        Task<T> LoadAggregateAsync(TId id);
        Task<TId> SaveAggregateAsync(T aggregate);

        Task<T> LoadModelAsync(TId modelId);
        Task<IEnumerable<T>> FindModelsAsync(List<SearchParameter> searchParameters);


        Task<TId> SaveModelAsync(T model);
    }
}
