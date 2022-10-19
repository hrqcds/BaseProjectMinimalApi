using BaseProjectMinimalApi.Infra;

var app = BuilderConfig.Run();
AppConfig.Run(app);
RouteConfig.Start(app);

app.Run();

