import { ApolloClient, ApolloProvider, InMemoryCache } from '@apollo/client';
import CategoriesDashboard from '../../features/categories/CategoriesDashboard';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './Layout';
import HomePage from '../../features/home/HomePage';
import FlashCardDashboard from '../../features/flashcards/FlasCardDashboard';
import CategoryPage from '../../features/categories/CategoryPage';
import FlashCardPage from '../../features/flashcards/FlashCardPage';

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
        <Route path="categories/:categoryID" element={<CategoryPage />} />
        <Route path="flashcards" element={<FlashCardDashboard />} />
        <Route path="flashcards/:flashCardID" element={<FlashCardPage />} />
        </Route>
      </Routes>
      </BrowserRouter>
    </ApolloProvider>
  );
}

export default App;
