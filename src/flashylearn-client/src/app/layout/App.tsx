import { ApolloClient, ApolloProvider, InMemoryCache } from '@apollo/client';
import CategoriesDashboard from '../../features/categories/CategoriesDashboard';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './Layout';
import HomePage from '../../features/home/HomePage';
import FlashCardDashboard from '../../features/flashcards/FlasCardDashboard';

const client  = new ApolloClient({
  cache: new InMemoryCache({
    typePolicies: {}
  }),
  uri: process.env.REACT_APP_API_SCHEMA_URL
})

function App() {
  return (
    <ApolloProvider client={client}>
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}> 
        <Route index element={<HomePage />}/>
        <Route path="categories" element={<CategoriesDashboard />} />
        <Route path="flashcards" element={<FlashCardDashboard />} />
        </Route>
      </Routes>
      </BrowserRouter>
    </ApolloProvider>
  );
}

export default App;
