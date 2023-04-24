using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Woolworths.FoodISO.WebClient.Models
{
    /// <summary>
    /// Used to bind selectable entities to a checkbox list in the UI.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public class CheckListItem<T>
        where T : class
    {
        /// <summary>
        /// Indicates if the entity has been selected.
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// The entity.
        /// </summary>
        public T Entity { get; set; }

        public CheckListItem(T entity)
        {
            Entity = entity;
            Selected = false;
        }

        public CheckListItem(T entity, bool selected)
        {
            Entity = entity;
            Selected = selected;
        }
    }
}
