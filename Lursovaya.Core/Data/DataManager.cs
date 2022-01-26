using Kursovaya.Core.TypeGetter;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Kursovaya.Core.Data
{
    public static class DataManager
    {
        public static List<(Type, object)> CacheDataManagers = new List<(Type, object)>();
        public static T GetDataManager<T>() where T : class
        {
            var dataManager = CacheDataManagers.Where(x => x.Item1 == typeof(T)).FirstOrDefault();
            if(dataManager.Item2 == null)
            {
                dataManager = (typeof(T), ClassGetter.GetInstanceOfType<T>());
                CacheDataManagers.Add(dataManager);
            }
            return (T)dataManager.Item2;
        }
    }
}
