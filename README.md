# IntelutionsTest
Pequeño ABM utilizando .Net Core 3.1 para el back end y Vue Js 2 para el front end. Para el acceso de datos se utilizó EntityFrameworksCore para mapear con una base de datos relacional. En las vistas web utilizó el framework CSS Bootstrap en su versión 4.5.3.

## Para consumir la API desarrollada en .NET Core se utilizaron las siguientes direcciones:

### Para Listar los Permisos se utilizó un metodo GET a la siguiente dirección:
https://localhost:44378/api/Permisos/List

### Para Insertar un nuevo Permiso se utilizó un metodo POST a la siguiente dirección:
https://localhost:44378/api/Permisos/Create

Enviando un Json con la siguiente estructura:
```
{
    "nombreEmpleado": "Juan",
    "apellidosEmpleado": "Mamani",
    "tipoPermiso": 1,
    "fechaPermiso": "2020-10-07"
}
```

### Para Editar Permiso se utilizó un metodo PUT a la siguiente dirección:
https://localhost:44378/api/Permisos/Update

Enviando un Json con la siguiente estructura:
```
{
  "id": 4,
  "nombreEmpleado": "Johanna Soledad",
  "apellidosEmpleado": "Zurita",
  "tipoPermiso": 1,
  "fechaPermiso": "2020-10-07"
}
```

### Para Eliminar un Permiso se utilizó un metodo DELETE a la siguiente dirección:
https://localhost:44378/api/Permisos/Delete/{id}

En todos los sacos es recomendable establecer la siguiente cabecera:
```
{
  Content-Type: "application/json"
}
```
