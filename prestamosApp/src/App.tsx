import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { NavBar } from './components/NavBar'
import { HomePage } from './pages/HomePage'
import { Footer } from './components/Footer'
import { LibrosPage } from './pages/LibrosPage';
import { UsuariosPage } from './pages/UsuariosPage';
import { PrestamosPage } from './pages/PrestamosPage';

function App() {
  return (
    <BrowserRouter>
      <NavBar />
      <main className="py-4">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/libros" element={ <LibrosPage /> } />
          <Route path="/usuarios" element={ <UsuariosPage /> } />
          <Route path="/prestamos" element={ <PrestamosPage /> } />
        </Routes>
      </main>
      <Footer/>
    </BrowserRouter>
  )
}

export default App
