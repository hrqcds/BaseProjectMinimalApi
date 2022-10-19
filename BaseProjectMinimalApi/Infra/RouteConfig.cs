using BaseProjectMinimalApi.Routes;

namespace BaseProjectMinimalApi.Infra
{
    public class RouteConfig
    {
        public static void Start(WebApplication app)
        {
            var exampleController = new ExampleController(app);
            exampleController.Init();
        }
    }
}
