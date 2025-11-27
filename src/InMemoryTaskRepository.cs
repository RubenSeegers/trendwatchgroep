using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trendwatchgroep.Tasks
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly ConcurrentDictionary<Guid, TaskItem> _store = new();

        public Task<TaskItem> CreateAsync(TaskItem item)
        {
            item.Id = Guid.NewGuid();
            item.CreatedAt = DateTime.UtcNow;
            _store[item.Id] = item;
            return System.Threading.Tasks.Task.FromResult(item);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return System.Threading.Tasks.Task.FromResult(_store.TryRemove(id, out _));
        }

        public Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return System.Threading.Tasks.Task.FromResult(_store.Values.AsEnumerable());
        }

        public Task<TaskItem?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var item);
            return System.Threading.Tasks.Task.FromResult(item);
        }

        public Task<TaskItem?> UpdateAsync(TaskItem item)
        {
            if (!_store.ContainsKey(item.Id)) return System.Threading.Tasks.Task.FromResult<TaskItem?>(null);
            _store[item.Id] = item;
            return System.Threading.Tasks.Task.FromResult<TaskItem?>(item);
        }
    }
}