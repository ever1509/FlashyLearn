import { ApolloClient, ApolloProvider, InMemoryCache } from '@apollo/client';
import React from 'react';
import CategoriesDashboard from '../../features/categories/CategoriesDashboard';
const client  = new ApolloClient({
  cache: new InMemoryCache({
    typePolicies: {}
  }),
  uri: "https://localhost:7096/graphql"
})

function App() {
  return (
    <ApolloProvider client={client}>
      <CategoriesDashboard />
    </ApolloProvider>
  );
}

export default App;
