using BaseProjectMinimalApi.Data;
using BaseProjectMinimalApi.Models;
using BaseProjectMinimalApi.Repositories;
using static BaseProjectMinimalApi.Repositories.ExampleRepository;

namespace BaseProjectMinimalApi.Routes
{
    public class ExampleController
    {
        public WebApplication App { get; private set; }
        public ExampleController(WebApplication app)
        {
            App = app;
        }

        public void Init()
        {
            Get();
            Post();
        }

        public void Get()
        {
            App.MapGet("/Examples", async (AppContextDB db) =>
            {
                var repository = new ExampleRepository(db);
                return Results.Ok(await repository.ListExamples());
            })
            .WithName("ListExample")
            .WithTags("Examples");
        }

        public void Post()
        {
            App.MapPost("/Examples", async (AppContextDB db, RecordRequestExample request) =>
            {
                var repository = new ExampleRepository(db);
                var example = new ExampleModel { Id = Guid.NewGuid().ToString(), Name = request.name, Description = request.description };
                var result = repository.CreateExample(example);

                if (result == null) return Results.BadRequest("Erro na inserção do banco de dados");

                return Results.Ok(result);
            })
            .WithName("CreateExample")
            .WithTags("Examples")
            .Produces<ExampleModel>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
        }

    }

}
