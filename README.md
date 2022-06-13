# Permission Manager

Aplicacion web (API, SPA) para asignacion y manejo de permisos desarrolladas con el fin de probar ciertas caracteristica de diseño y arquitectura de sofware.

Las funcionalidades a destacar son:

* Programación en capas
* Patrón repository
* Uso de dependency injection
* Uso de composition API para la construcion del projecto de Vue
* Excepciones personalizadas
* Exception Filter para estandarizar las respuestas de error desde el API
* Pruebas unitarias


## Tecnologias
* ASP.NET core 6
* C# 10
* Entity Framework Core 6
* FluentValidation
* Vue 3
* Vue Router
* Pinia
* Bootstrap 5 
* XUnit, FluentAssertions, FakeItEasy

## Guia de inicio
Para la correcta ejecución del proyecto e iniciar debemos instalar los componentes necesarios para la correcta ejecucion del proyecto, listados a continuación:

1. Instalar la ultima version de [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Instalar la ultima version estable de [Node LTS](https://nodejs.org/en/)

### Base de Datos
Ir al archivo AppSetting.json y colocar el connection string del motor de SQL y verificar la url del proyecto cliente

```
ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=PermissionManager;User Id=app;Password=MyPass@word;App=PermissionManager"
  },
  "AppSetting": {
    "ClientURL": "http://localhost:3000"
  }, 
  ...
  ```
### Migraciones de base de datos
Cuando el proyecto se ejecuta el **Debug mode** el proyecto automaticamente ejecuta las migraciones en la instancia de base de datos registrada en el AppSetting.json. En caaso de querer ejecutarla manualmente de debe ejecutar lo siguiente:

Desde la consola, navegar a `PermissionManager.WebAPI` desde la carpeta raiz del proyecto y ejecutar `dotnet ef database update`

### API
Ejecutar el proyecto desde visual studio.

### Vue App
Navegar al archivo `PermissionManager.WebApp/constants.js` y colocar la url del API
```
export const BASE_URL = "https://localhost:7067/api/"
```
Desde la consola, navegar a `PermissionManager.WebApp` desde la carpeta raiz del proyecto y ejecutar 
```
npm install
npm run dev
```
