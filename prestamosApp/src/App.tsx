import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { NavBar } from './components/NavBar'
import { HomePage } from './pages/HomePage'
import { Footer } from './components/Footer'
import { LibrosPage } from './pages/LibrosPage';

function App() {
  return (
    <BrowserRouter>
      <NavBar />
      <main className="py-4">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/libros" element={ <LibrosPage /> } />
          <Route path="/usuarios" element={<></>} />
          <Route path="/prestamos" element={<></>} />
        </Routes>
      </main>
      <Footer/>
    </BrowserRouter>
  )
}

export default App
