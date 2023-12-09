# GraphQL-learning
<img src="https://img.shields.io/badge/GrahpQL-.NET CORE-brightgreen" />

this repo is used to learn GraphQL. And below is the main features will list in this repo.
#REFE: https://www.ezzylearning.net/tutorial/a-beginners-guide-to-graphql
<ol>
<li>foo</li>
<li>bar</li>
</ol>
<ol start="3">
<li>baz</li>
</ol>

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
