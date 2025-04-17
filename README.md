# 📚 PrestamoAPI

**PrestamoAPI** es una API RESTful construida con **.NET 8** que permite gestionar libros, usuarios y préstamos para un sistema de biblioteca.

---

## 🚀 Características

- 📖 **Gestión de Libros**: Crear, listar, buscar, actualizar y eliminar libros.
- 👤 **Gestión de Usuarios**: Crear, listar, buscar, actualizar y eliminar usuarios.
- 🔄 **Gestión de Préstamos**: Crear, listar, buscar, actualizar y eliminar préstamos.
- ✅ **Filtrado de Préstamos Activos**.

---

## ⚙️ Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Una base de datos configurada (por ejemplo, **SQL Server**)

---

## 🛠️ Instalación

```bash
# 1. Clona el repositorio
git clone https://github.com/Jorge22L/PrestamoAPI

# 2. Navega al directorio del proyecto, restaura dependencias y configura la base de datos
cd PrestamoAPI
dotnet restore
# Edita el archivo appsettings.json para configurar tu cadena de conexión

# 3. Aplica las migraciones
dotnet ef database update

# 4. Ejecuta la API
dotnet run
