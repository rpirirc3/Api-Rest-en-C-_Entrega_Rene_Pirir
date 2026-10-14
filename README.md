# TiendaTecnologiaAPI

video de explicación: 
https://youtu.be/jXLLN5apP4c

Sección B, 
Alumno :  Rene Abraham Pirir Cuc
Carné: 7690-23-22174

Proyecto de **Programación II** desarrollado en ASP.NET Core Web API (.NET 8) utilizando Entity Framework Core y SQLite.

## Objetivo

Demostrar operaciones CRUD mediante controladores REST. contiene como mínimo consultas SELECT, INSERT y UPDATE; el proyecto también incluye DELETE.

## Entidades

- Marcas
- Productos
- Clientes

## Endpoints principales

### Marcas
- GET `/api/Marcas`
- GET `/api/Marcas/{id}`
- POST `/api/Marcas`
- PUT `/api/Marcas/{id}`
- DELETE `/api/Marcas/{id}`

### Productos
- GET `/api/Productos`
- GET `/api/Productos/{id}`
- POST `/api/Productos`
- PUT `/api/Productos/{id}`
- DELETE `/api/Productos/{id}`

### Clientes
- GET `/api/Clientes`
- GET `/api/Clientes/{id}`
- POST `/api/Clientes`
- PUT `/api/Clientes/{id}`
- DELETE `/api/Clientes/{id}`

## Requisitos para ejecutar

- Visual Studio 2022 con la carga de trabajo **ASP.NET y desarrollo web**.
- SDK de .NET 8.
- Conexión a Internet la primera vez para restaurar los paquetes NuGet si no están en caché.

No es necesario instalar ni configurar un servidor de base de datos. SQLite utiliza un archivo local que se crea automáticamente al iniciar la aplicación.

## Ejecución

1. Abrir `TiendaTecnologiaAPI.sln` en Visual Studio 2022.
2. Esperar la restauración de paquetes NuGet.
3. Seleccionar el perfil **https**.
4. Presionar F5 o el botón Ejecutar.
5. Swagger se abrirá automáticamente.
6. La base `tienda_tecnologia.db` se crea automáticamente con datos iniciales de prueba.

## Prueba rápida en Swagger

1. Ejecutar GET `/api/Marcas` para comprobar SELECT.
2. Ejecutar POST `/api/Marcas` con:

```json
{
  "nombre": "HP"
}
```

3. Usar el `idMarca` devuelto para ejecutar PUT `/api/Marcas/{id}` con:

```json
{
  "idMarca": 4,
  "nombre": "HP Inc."
}
```


## Repositorio

https://github.com/rpirirc3/Api-Rest-en-C-_Entrega_Rene_Pirir
