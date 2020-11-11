using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BusinessLogicInterface;
using BusinessLogicInterface.Utils;
using Domain;
using ImportInterface;

namespace BusinessLogic
{
    public class ImporterLogic : IImporterLogic
    {
        private readonly IMovieLogic movieLogic;
        private readonly string configurationPath;
        public ImporterLogic(IMovieLogic movieLogic, string path)
        {
            this.movieLogic = movieLogic;
            this.configurationPath = path;
        } 

        public List<string> GetNames()
        {
            //REFLECTION
            /*
            1- Traer todas las clases que implementen la interfaz
            2- Retornarla
            */
            
            /*
            Sacar de archivo de configuracion
            */
            List<string> names = new List<string>();
            
            var directory = new DirectoryInfo(configurationPath);
            FileInfo[] files = directory.GetFiles("*.dll");

            foreach (var file in files)
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedImplementation = assemblyLoaded.GetTypes().Where(t => typeof(IImport).IsAssignableFrom(t) && t.IsClass).FirstOrDefault();

                if (loadedImplementation == null)
                {
                    Console.WriteLine("Nadie implementa la interfaz: {0} en el assembly: {1} ", nameof(IImport), file.FullName);
                }
                else
                {
                    var implementation = Activator.CreateInstance(loadedImplementation) as IImport;
                    names.Add(implementation.GetName());
                }
            }

            return names;
        }  

        public void Import(ImporterModel import)
        {
            //REFLECTION
            /*
            1- Traigo la implementacion especifica
            2- La uso
            3- Guardo la nueva pelicula
            4- Termino
            */

            List<string> names = new List<string>();
            string configurationPath = "C:\\Users\\Daniel\\Documents\\GitHub\\DA2-Tecnologia\\Codigo\\Nocturno\\Vidly\\WebApi\\bin\\Debug\\netcoreapp3.1\\Importers";
            
            var directory = new DirectoryInfo(configurationPath);
            FileInfo[] files = directory.GetFiles("*.dll");

            foreach (var file in files)
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedImplementation = assemblyLoaded.GetTypes().Where(t => typeof(IImport).IsAssignableFrom(t) && t.IsClass).FirstOrDefault();

                if (loadedImplementation == null)
                {
                    Console.WriteLine("Nadie implementa la interfaz: {0} en el assembly: {1} ", nameof(IImport), file.FullName);
                }
                else
                {
                    var implementation = Activator.CreateInstance(loadedImplementation) as IImport;
                    if(implementation.GetName() == import.Name)
                    {
                        var parseo = implementation.Import(import.Path);

                        this.movieLogic.Add(new Movie()
                        {
                            Name = parseo.Name,
                            Description = parseo.Description
                        });
                    }
                }
            }
        }
    }
}