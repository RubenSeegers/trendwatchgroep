using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trendwatchgroep.Tasks
{
    public interface ITaskRepository
    {
        Task<TaskItem> CreateAsync(TaskItem item);
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> UpdateAsync(TaskItem item);
        Task<bool> DeleteAsync(Guid id);
    }
}