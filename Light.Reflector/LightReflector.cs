using System.Reflection;
using System.Linq;

namespace Light.Reflector {
    public class LightReflector {

        /// <summary>
        /// Creates a new object from the values of another object
        /// without the need of them to be of the same type.
        /// </summary>
        /// <typeparam name="Source">Source object type</typeparam>
        /// <typeparam name="Target">Target object type</typeparam>
        /// <param name="fromObject">Object to take it's values from</param>
        /// <returns>A new object with the values of the source object</returns>
        public Target CreateNewObject<Source, Target>(Source fromObject) where Target : new() {
            var newItem = new Target();
            AssignValues(fromObject, newItem);
            return newItem;
        }

        /// <summary>
        /// This method does take an object and copies the 
        /// values of it's public properties to 
        /// the public properties of the target, the public
        /// properties on the target must have setters.
        /// - This method doesn't work for static instances.
        /// - This method needs public properties with setters.
        /// </summary>
        /// <typeparam name="Source">Source object type</typeparam>
        /// <typeparam name="Target">Target object type</typeparam>
        /// <param name="from">The object to take it's values from</param>
        /// <param name="to">The object to copy the source values to</param>
        public void AssignValues<Source, Target>(Source from, Target to) {
            var sourcePublicProperties = typeof(Source).GetProperties((BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)).ToDictionary(I => I.Name);
            var targetPublicProperties = typeof(Target).GetProperties((BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.SetProperty));
            foreach (var property in targetPublicProperties) { 
                if (sourcePublicProperties.TryGetValue(key: property.Name, value: out var sourceMatchingProperty)) { 
                    to.GetType().GetProperty(property.Name).SetValue(obj: to, value: sourceMatchingProperty.GetValue(from));
                }
            }
        }

    }
}
