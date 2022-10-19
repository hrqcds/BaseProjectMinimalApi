using BaseProjectMinimalApi.Data;
using BaseProjectMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseProjectMinimalApi.Repositories
{
    public class ExampleRepository
    {
        private readonly AppContextDB db;
        public ExampleRepository(AppContextDB _db)
        {
            db = _db;
        }

        public async Task<List<ExampleModel>> ListExamples()
        {
            return await db.Examples.ToListAsync();
        }
        public async Task<ExampleModel?> CreateExample(ExampleModel example)
        {
            db.Examples.Add(example);
            await db.SaveChangesAsync();
            return example;

        }

        public record RecordRequestExample(string name, string? description);

    }
}
