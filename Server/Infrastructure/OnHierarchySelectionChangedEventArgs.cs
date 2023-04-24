using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Woolworths.FoodISO.WebClient.Infrastructure
{
    public class OnHierarchySelectionChangedEventArgs
    {
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public int? SubclassId { get; set; }
        public int WeekNo { get; set; }
    }
}
