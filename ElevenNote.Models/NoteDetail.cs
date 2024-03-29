﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
   public class NoteDetail
    {
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name="Created")]
        public int CategoryId { get; set; }
        public virtual Data.Category Category { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }

}
