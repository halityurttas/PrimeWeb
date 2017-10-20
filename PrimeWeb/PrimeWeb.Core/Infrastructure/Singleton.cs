using System;
using System.Collections.Generic;

namespace PrimeWeb.Core.Infrastructure
{

    /// <summary>
    /// A generic singleton pattern
    /// </summary>
    public class Singleton
    {
        private static Dictionary<Type, object> dictionary = new Dictionary<Type, object>();

        /// <summary>
        /// Add an object in signleton dictionary
        /// Warning: if dictionary contains an object instance that remove current
        /// </summary>
        /// <typeparam name="TObject">Type of object</typeparam>
        /// <param name="instance">TObject instance</param>
        public static void Add<TObject>(TObject instance)
        {
            if (dictionary.ContainsKey(typeof(TObject)))
            {
                dictionary.Remove(typeof(TObject));
            }
            dictionary.Add(typeof(TObject), instance);
        }

        /// <summary>
        /// Resolve an object from singleton dictionary
        /// </summary>
        /// <typeparam name="TObject">Type of object</typeparam>
        /// <returns>TObject instance</returns>
        public static TObject Get<TObject>()
        {
            if (dictionary.ContainsKey(typeof(TObject)))
            {
                return (TObject)dictionary[typeof(TObject)];
            }
            return default(TObject);
        }

        /// <summary>
        /// Remove TObject instance
        /// </summary>
        /// <typeparam name="TObject">Type of object</typeparam>
        public static void Remove<TObject>()
        {
            if (dictionary.ContainsKey(typeof(TObject)))
            {
                dictionary.Remove(typeof(TObject));
            }
        }
    }
}
