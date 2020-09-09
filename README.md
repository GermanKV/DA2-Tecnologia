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
|```dotnet ef migrations add NombreMigracion -p ../Ubicacion_DataAccess``` | Este comando creará la migración. Crea 3 archivos: 1) .cs: Contiene las operaciones Up() y Down() que se aplicaran a la BD para remover o añadir objetos. 2) .Designer.cs: Contiene la metadata que va a ser usada por EF Core. 3) .ModelSnapshot.cs: Contiene un snapshot del modelo actual. Que será usada para determinar qué cambio cuando se realice la siguiente migración.
|```dotnet ef database update -p ../Ubicacion_DataAccess```| Se encarga de ejecutar las queries creadas en la migracion para que en la base de datos se actualice las tablas, relaciones, tipo de datos sin la necesidad de perder los datos en la misma
