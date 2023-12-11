# GraphQL-learning Demo in Asp.net Core
<img src="https://img.shields.io/badge/GrahpQL-.NET CORE-brightgreen" />
this repo is used to learn GraphQL with Asp.net Core under .NET 8.

## How to use GraphQL in ASP.NET Core?
We need to install third-party libraries or packages to use GraphQL in ASP.NET Core. here are several options available but two of the most popular libraries are [GraphQL .NET](https://graphql-dotnet.github.io/) and [Hot Chocolate](https://chillicream.com/docs/hotchocolate). Both libraries are very powerful and support a vast array of features but in the recent past, Hot Chocolate is gaining a lot of momentum due to its performance and advanced features.
### 👇Hot Chocolate👇
Hot Chocolate is an open-source GraphQL library that is compliant with the latest GraphQL specs. It takes away a lot of the complexity of building a full-fledge GraphQL server and lets you focus on writing your APIs. It is also very simple to set up and configure and removes the clutter from creating GraphQL schemas. Hot Chocolate comes with integration to the ASP.NET Core endpoints API and the middleware implementation follows the current GraphQL specification over HTTP. Another amazing feature of Hot Chocolate is that it has a built-in tool called Banana Cake Pop that makes it very easy and enjoyable to test our GraphQL server implementation.
<div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/graphQLSample01.JPG" />
</div>

### 👇Setup an ASP.NET Core Web Application👇
In this demo, I will use Visual Studio 2022, Entity Framework Core, and ASP.NET Core with .NET 8.0. I will be using a database name FootballDb that has the following tables in it.
<ul>
  <li>Let’s create a new ASP.NET Core Web Application and make sure the application is building and running fine in the browser.</li>
  <li>Install below packages with NuGet package manager or Package Manager Console:
  <ol>
    <li>Microsoft.EntityFrameworkCore.SqlServer</li>
    <li>Microsoft.EntityFrameworkCore.Tools</li>
    <li>HotChocolate.AspNetCore</li>
    </ol>
    <div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/GrapQLSample02.JPG" />
</div>
  </li>
</ul>

### 👇Setup DB and use EFCore to create Models (DB First)👇
Set DB connection string in the appsettings.json file:

```
"ConnectionStrings": {
    "DefaultConnection": "Server=YourDbServerName; Database=FootballDb;Trusted_Connection=True; MultipleActiveResultSets=true;Encrypt=False;"
  }
```
Create DB context and Models:

```
Scaffold-DbContext -Connection "Server=.; Database=FootballDb;Trusted_Connection=True; MultipleActiveResultSets=true;Encrypt=False;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Models" -ContextDir "Data" -Context "SportsDbContext" –NoOnConfiguring
```
Configure the Entity Framework Core provider in Program.cs like below code: 

```
builder.Services.AddDbContext<SportsDbContext>(options => 
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### 👇Implementing Business Service👇
Create a Services folder in the project and create the following IPlayersService interface.

<strong>IPlayersService.cs</strong>

```
public interface IPlayerService
{
    Task<IEnumerable<Player>> GetPlayersAsync();        
}
```

Create a PlayersService class in the Services folder and implement the IPlayersService interface on the class.

<strong>PlayersService.cs</strong>

```
public class PlayerService : IPlayerService
{
    private readonly SportsDbContext _context;
 
    public PlayerService(SportsDbContext context)
    {
        _context = context;
    }
 
    public async Task<IEnumerable<Player>> GetPlayersAsync()
    {
        return await _context.Players
            .Include(x => x.Position)
            .ToListAsync();
    } 
}
```
<strong>Register the above service in the Program.cs</strong>

```
builder.Services.AddScoped<IPlayerService, PlayerService>();
```

### 👇Writing GraphQL Queries in ASP.NET Core👇
We are now ready to create our first GraphQL Query. Create an Api folder in the project and then add the following Query class in the folder. The class has only one method called GetPlayersAsync in which we are injecting our IPlayerService interface. Inside the method, we are calling the GetPlayersAsync method of IPlayerService which returns the list of players from the database.

```
public class Query
{
    public async Task<IEnumerable<Player>> GetPlayersAsync(
        [Service] IPlayerService playerService)
    {
        return await playerService.GetPlayersAsync();
    }
}
```

In ASP.NET Core, we normally inject services through the constructor of the class and you may have already noticed that we haven’t used the typical constructer-based dependency injection approach in the above Query class. We are injecting IPlayerService directly into the method using the [Service] attribute. This is the preferred way of resolving services in Hot Chocolate as most of the time the services only have a request lifetime.

It is also important to note that if we are using Hot Chocolate with ASP.NET Core then we do not need to think about setting up dependency injection because it is already done for us. Hot Chocolate support dependency injection via the IServiceProvider interface and this service provider is automatically passed in with the request.

### 👇Configuring GraphQL Server in ASP.NET Core👇
Now we have defined a Query type that exposes the data and types, e.g. Player, Position, etc. we need to build our GraphQL server and you can do this by calling the AddGraphQLServer method in the Program.cs file as follows.

```
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
```
The AddGraphQLServer method returns an IRequestExecutorBuilder, which has many extension methods, similar to an IServiceCollection, that can be used to configure the GraphQL schema. In the above example, we are specifying the Query type that should be exposed by our GraphQL server.

Once the necessary services are configured, we need to expose the GraphQL server to an endpoint. Hot Chocolate comes with a set of ASP.NET Core middleware used for making the GraphQL server available via HTTP and WebSockets. You can simply call the MapGraphQL method in Program.cs file to register the middleware a standard GraphQL server requires.

```
app.MapGraphQL();
```
The middleware registered by MapGraphQL makes the GraphQL server available at /graphql per default. We can customize the endpoint at which the GraphQL server is hosted like the following.

```
app.MapGraphQL("/my/graphql/endpoint");
```
Accessing the endpoint from a browser will load the GraphQL IDE Banana Cake Pop which is an amazing tool to test GraphQL queries during development.

### 👇Browsing GraphQL Schema and Types👇
 Hot Chocolate has a built-in tool Banana Cake Pop that makes it very easy to test GraphQL APIs. We can run the demo project and use the endpoint: https://localhost:44347/my/graphql/endpoint/ (Port may different on your local).

<div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/BananaCake01.JPG" />
</div>

Click the Create document button and you will be presented with a Connection Settings dialog. Make sure the Schema Endpoint input field has the correct URL under which our GraphQL endpoint is available. Click the Apply button if everything seems correct to you.

<div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/BananaCakeSetConnection.JPG" />
</div>

Now you should be seeing the full-fledge GraphQL editor as shown below. The green-colored online status on the top right corner is what tells us that the GraphQL server is set up correctly and we are ready to browser our GraphQL schema and run our queries.

<div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/BananaCake001.JPG" />
</div>

The above editor is split into four panes. The top-left pane is where we enter the queries and the result will be displayed in the top-right pane. Variables and headers can be modified in the bottom left pane and recent queries can be viewed in the bottom right pane. You can also click the Schema Reference tab next to the Operations tab to view details of your schema.

<div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/SchemaRef.JPG" />
</div>

And we also check the GraphQL schema.

<div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/SchemaDefinition.JPG" />
</div>

### 👇Running GraphQL Queries in ASP.NET Core👇
It is now time to write and send our first GraphQL query to the server. Please write the following query into the left pane of the editor and hit the Run button. The results of your query should be displayed in the right pane in JSON format.

<div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/RunQuery01.JPG" />
</div>

And also we can include the position information in the query.

<div align="center">
  <img  src="https://github.com/kulala2014/GraphQL-learning/blob/master/RunQuery02.JPG" />
</div>

## 👇Summary
we have built our first GraphQL server using the Hot Chocolate library and you can see that we just wrote a few lines of code to set up everything.
And if we want to learn more about the HotChocolate, we can use [this guide](https://chillicream.com/docs/hotchocolate/v13/get-started-with-graphql-in-net-core) to go through more basic about HotChocolate.
And also we can learn more about Defining a GraphQL schema with [this guide](https://chillicream.com/docs/hotchocolate/defining-a-schema).
