# GraphQL-learning
<img src="https://img.shields.io/badge/GrahpQL-.NET CORE-brightgreen" />

this repo is used to learn GraphQL. And below is the main features will list in this repo.

<div align="center">
  <img  src="https://github-readme-streak-stats.herokuapp.com?user=dongyuanwai&theme=onedark&date_format=M%20j%5B%2C%20Y%5D" />
</div>

### What is GraphQL?
GraphQL is a query language as well as a server-side runtime to build efficient and high-performance Web APIs. It was developed by Facebook in 2012 and then it was made public in 2015. It is now overseen by the GraphQL Foundation. GraphQL specification is open source therefore we now have dozens of implementations of GraphQL in every major programming language. GraphQL is designed to make APIs fast, flexible, and developer-friendly. Unlike REST, GraphQL APIs can accept all incoming requests at a single endpoint, and data can be pulled and served from multiple data.

In GraphQL, a client has full control over the data that API should return from the server. The client typically sends a POST request in JSON format to get exactly the data it needs.

### 👇An Example GraphQL API Request

```
query {
    team {
        id
        name
    }
}
```

### 👇An Example GraphQL API Response

```
{
  "data": {
    "team": [
      {
        "id": "1",
        "name": "Liverpool"
      },
      {
        "id": "1",
        "name": "Arsenal"
      },
      {
        "id": "1",
        "name": "Chelsea"
      }
    ]
  }
}
```
The server handles incoming queries, parses those queries, validates the queries using the defined schema, and finally used resolvers to fetch and aggregate data which is then returned in the response usually in JSON format.
### 👇Workflow for GraphQL
![alt text](https://github.com/kulala2014/GraphQL-learning/blob/main/GraphQL-Execution-Engine.png?raw=true)

### 👇GraphQL vs. REST
Both GraphQL and REST are used to build Web APIs but there are a lot of differences between the two technologies.
<ol>
<li> <strong>The number of endpoints</strong>  - In REST, we normally use multiple API endpoints to obtain the data we need whereas GraphQL exposes just one endpoint and the client can get all required information using that endpoint. It is also much easier to maintain and scale GraphQL APIs as there is only one endpoint involved.</li>
<li><strong>Allowed HTTP Verbs</strong> - In REST, we are allowed to use any HTTP verb, e.g. GET, POST, PUT, etc. whereas GraphQL supports only POST requests.</li>
<li><strong>Available Protocol</strong> - REST only works with HTTP, while GraphQL does not need HTTP.</li>
<li><strong>Request/Response Definition</strong> - In REST, the server-side API code defines the request and response format whereas GraphQL gives complete control to the client to define the request and response as per requirement.</li>
<li><strong>No versioning problems</strong> - In REST, we normally implement different API versions for supporting clients with different requirements. GraphQL doesn’t need versioning because every client can request exactly what data it needs.</li>
<li><strong>Fewer round trips to the server</strong> - GraphQL requires fewer round trips to the server because the client can request all the data in a single request. In REST, we usually require multiple API calls to load data from the server.</li>
<li><strong>No over-fetching or under-fetching</strong> - in REST, we sometimes receive unnecessary data from APIs whereas GraphQL let the client specify what information it needs so the client will never get too little or too much data from the server.</li>
<li><strong>Reduced bandwidth</strong> - Due to fewer requests to the server and not over-fetching any unnecessary data, the GraphQL APIs reduce the bandwidth and resource usage significantly.</li>
<li><strong>Learning curve</strong> - REST APIs are very simple to learn and implement and there are hundreds of books and training courses available whereas GraphQL presents a steep learning curve for developers.</li>
</ol>

### 👇What Problem GraphQL Solves
There are many downsides of REST APIs but a few of the major problems GraphQL solves are the following:
<ul>
  <li><strong>Over-fetching - </strong>REST API sends you more data than you need</li>
  <li><strong>Under-fetching – </strong>REST API sends you less data than you need</li>
  <li><strong>Multiple requests or round trips - </strong>You require multiple requests and round trips to the server to get the data you need</li>
</ul>
```TODO sample to explain this`````

## 👇Major Components of GraphQL👇
Following are the major components of GraphQL APIs.
### 👇GraphQL Schema
The GraphQL Schema describes the data clients can request using the GraphQL API. It is basically a contract between the client and the server and defines what an API can do and can’t do and how clients can request data using the API. The schema can be defined using the GraphQL Schema Definition Language (SDL) and it describes the object types associated with each node. The following code snippet is an example of a schema and you can see how each element has a type definition associated with it.
#### Sample
```
type Book {
    id: ID
    title: String
    published: Date
    author: Author
}
type Author {
    id: ID
    name: String
    book: [Book]
}
```
### 👇GraphQL Query
The queries are used to fetch and consume data from the server. While writing GraphQL queries, the client can traverse multiple related objects and their fields to fetch lots of related data in one request, instead of making several round trips. The following is an example of a GraphQL query that asks for a book and author by its ID number.

#### GraphQL Query Request Example
```
{
  hero {
    name
    friends {
      name
    }
  }
}
```
#### GraphQL Query Response Example
```
{
  "data": {
    "hero": {
      "name": "Superman",
      "friends": [
        {
          "name": "Spiderman"
        },
        {
          "name": "Batman"
        }
      ]
    }
  }
}
```

### 👇GraphQL Mutations
Mutations allow GraphQL clients to insert, update or delete data on the server. These are pretty much equivalent to POST, PUT, PATCH, or DELETE requests we use in REST APIs. Mutations are defined in GraphQL schema on the server-side and the client can only manipulate data exposed by the mutations.

#### GraphQL Mutation Definition
```
mutation AddNewPost ($name: String!, $postType: PostType) {
  addPost(name: $name, postType: $postType) {
    id
    name
    postType
  }
}
```
#### GraphQL Mutation Request Example
```
{
  "name": "Introduction to GraphQL",
  "postType": "ARTICLE"
}
```

### 👇GraphQL Subscriptions
In GraphQL, subscriptions allow a server to send data to its clients, notifying them when events occur. These are usually implemented using WebSockets and can be useful when you want to send real-time notifications from servers to clients. GraphQL subscriptions use an Event-based approach where a client subscribes for some particular events to the server and the server informs the client whenever these events trigger.
An Example GraphQL Subscription:
```
subscription StoryLikeSubscription($input: StoryLikeSubscribeInput) {
  storyLikeSubscribe(input: $input) {
    story {
      likers { count }
      likeSentence { text }
    }
  }
}
```

### 👇GraphQL Resolvers
Resolver is a GraphQL query handler that tells GraphQL how and where to fetch the data corresponding to a given field in the query. Whenever a GraphQL client queries for a particular field, the resolver for that field fetches the requested data from the appropriate data source. These data sources can be databases, microservices, REST APIs, or even other GraphQL queries.  
An Example GraphQL Resolver:
```
Query: {
  book(obj, args, context, info) {
    return context.db.loadBookById(args.id).then(
      bookData => new Book(bookData)
    )
  }
}
```
## 👇Summary👇
GraphQL has solved a lot of problems using its single round-trip based standardized architecture which is always a better, cheaper, and faster alternative to REST APIs. There are still some shortcomings that are bound to be resolved over time as more and more developers are choosing GraphQL over REST, especially for new projects. If you want to learn how to implement GraphQL APIs then read my post, Getting Started with GraphQL in ASP.NET Core in which I will show you how to build a GraphQL API in ASP.NET Core. I hope you have found this post useful. If you have any comments or suggestions, please leave your comments below. Don’t forget to share this tutorial with your friends or community.

#reference link: https://www.ezzylearning.net/tutorial/a-beginners-guide-to-graphql
