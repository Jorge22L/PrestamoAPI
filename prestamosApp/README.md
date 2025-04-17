# PrestamoApp

Aplicación web para la gestión de préstamos, desarrollada con React, TypeScript y Vite.

## Descripción
PrestamoApp es una plataforma que permite gestionar préstamos de manera eficiente. Incluye funcionalidades como registro de usuarios, gestión de préstamos, historial y reportes.

## Tecnologías utilizadas
- [React](https://react.dev/)
- [TypeScript](https://www.typescriptlang.org/)
- [Vite](https://vitejs.dev/)

## Instalación
1. Clona el repositorio:
   ```bash
   git clone https://github.com/Jorge22L/PrestamoAPI.git
   ```
2. Instala las dependencias:
   ```bash
   npm install
   ```
3. Inicia la aplicación:
   ```bash
   npm run dev
   ```

## Estructura del proyecto
- `src/`
  - `components/` — Componentes reutilizables como NavBar y Footer
  - `pages/` — Páginas principales de la aplicación (HomePage, etc.)
  - `App.tsx` — Componente principal de la aplicación
  - `main.tsx` — Punto de entrada de la aplicación

## Uso
Accede a la aplicación en `http://localhost:5173` después de iniciar el servidor de desarrollo.

## Contribución
1. Haz un fork del repositorio
2. Crea una rama (`git checkout -b feature/nueva-funcionalidad`)
3. Realiza tus cambios y haz commit (`git commit -am 'Agrega nueva funcionalidad'`)
4. Haz push a la rama (`git push origin feature/nueva-funcionalidad`)
5. Abre un Pull Request

## Licencia
Este proyecto está bajo la licencia MIT.

export default tseslint.config({
  plugins: {
    // Add the react-x and react-dom plugins
    'react-x': reactX,
    'react-dom': reactDom,
  },
  rules: {
    // other rules...
    // Enable its recommended typescript rules
    ...reactX.configs['recommended-typescript'].rules,
    ...reactDom.configs.recommended.rules,
  },
})
```
