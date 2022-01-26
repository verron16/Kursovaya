using Kursovaya.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.TypeGetter
{
    public static class ClassGetter
    {
        public static List<T> GetEnumerableOfType<T>() where T : class
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && (myType.IsSubclassOf(typeof(T)) || myType.GetInterfaces().Contains(typeof(T)))))
            {
                objects.Add((T)Activator.CreateInstance(type));
            }
            return objects;
        }

        public static T GetInstanceOfType<T>() where T : class
        {
            T instance = null;
            Type type = Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && (myType.IsSubclassOf(typeof(T)) || myType.GetInterfaces().Contains(typeof(T)))).FirstOrDefault();
            if(type == null)
            {
                throw new InstanceIsNullException(typeof(T).ToString());
            }
            instance = (T)Activator.CreateInstance(type);
            return instance;
        }
    }
}
