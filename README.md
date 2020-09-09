# DA2-Tecnologia
## [Cheat sheet (Lista de comandos desde la consola)](https://youtu.be/-pkbte8x6iw)

|Comando|Resultado  |
|--|--|
|```dotnet new sln``` |Creamos una solucion (principalmente util para VisualStudio, cuando queremos abir la solucion y levantar los proyectos asociados)
|```dotnet new webapi -n "Nombre del proyecto"```  | Crear un nuevo proyecto del template WebApi
| ```dotnet sln add```|Asociamos el proyecto creado al .sln 
| ```dotnet sln list``` | Vemos todos los proyectos asociados a la solucion 
| ```dotnet new classlib -n "Nombre del proyecto"``` | Crea una nueva libreria (standard)
|```dotnet add "Nombre del proyecto 1" reference "Nombre del proyecto 2"``` | Agrega una referencia del Proyecto 2 al Proyecto 1
|```dotnet add package "Nombre del package"``` | Instala el Package al proyecto actual. Similar a cuando se agregaban paquetes de Nuget en .NET Framework
|```dotnet clean``` | Borra lo compilado
|```dotnet build``` | Compila y genera los archivos prontos para ser desplegados
|```dotnet run``` | Compila y corre el proyecto
| ```dotnet -h``` | Ayuda para ejecutar un comando o para inspeccionar diferentes comandos
|```dotnet ef migrations add NombreMigracion -p ../Ubicacion_DataAccess``` | Crea una migracion, el NombreMigracion es el nombre que se le pone a la migracion para decir que es lo que cambio, Ubicacion_DataAccess tiene que ser la direccion en donde se encuentra el contexto
|```dotnet ef database update -p ../Ubicacion_DataAccess```| Se encarga de ejecutar las queries creadas en la migracion para que en la base de datos se actualice las tablas, relaciones, tipo de datos sin la necesidad de perder los datos en la misma
