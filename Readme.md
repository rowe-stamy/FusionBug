# Build the graph

dotnet fusion subgraph config set http --url http://localhost:5000/graphql -w .\ServiceA

dotnet fusion subgraph config set name ServiceA -w .\ServiceA

dotnet fusion subgraph config set http --url http://localhost:5001/graphql -w .\ServiceB

dotnet fusion subgraph config set name ServiceB -w .\ServiceB

dotnet run --project .\ServiceA -- schema export --output subgraph.schema.graphql

dotnet run --project .\ServiceB -- schema export --output subgraph.schema.graphql

dotnet fusion subgraph pack -w .\ServiceA -s .\ServiceA\subgraph.schema.graphql

dotnet fusion subgraph pack -w .\ServiceB -s .\ServiceB\subgraph.schema.graphql

dotnet fusion compose -p .\Gateway\gateway -s .\ServiceA

dotnet fusion compose -p .\Gateway\gateway -s .\ServiceB

# Example queries

The following query is causing an error:

```
query problem {
  foos {
    commonField
    barByCommonField {
      barField
    }
    fizzByCommonField {
      fizzField
    }
  }
}
```

The following queries work as expected:

```
query ok1 {
  foos {
    commonField
    fizzByCommonField {
      fizzField
    }
  }
}

query ok2 {
  foos {
    commonField
    barByCommonField {
      barField
    }
  }
}

```
