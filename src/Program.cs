using System;
using Trendwatchgroep.Tasks;

Console.WriteLine("Trendwatchgroep Tasks Demo");

var repo = new InMemoryTaskRepository();

// Create
var task = new TaskItem { Title = "Schrijf code", Description = "Implementeer Task CRUD" };
task = await repo.CreateAsync(task);
Console.WriteLine($"Created: {task.Id} - {task.Title}");

// Read
var fetched = await repo.GetByIdAsync(task.Id);
Console.WriteLine($"Fetched: {fetched?.Id} - {fetched?.Title}");

// Update
fetched!.IsCompleted = true;
await repo.UpdateAsync(fetched);
var afterUpdate = await repo.GetByIdAsync(fetched.Id);
Console.WriteLine($"Updated: {afterUpdate?.Id} - Completed={afterUpdate?.IsCompleted}");

// List
var all = await repo.GetAllAsync();
Console.WriteLine($"Total tasks: {all?.Count()}");

// Delete
var deleted = await repo.DeleteAsync(task.Id);
Console.WriteLine($"Deleted: {deleted}");

Console.WriteLine("Demo finished.");
