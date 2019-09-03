using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote.Models
{               //Consider making this an abstract class??
    public class CategoryListItem
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
