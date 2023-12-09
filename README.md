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
