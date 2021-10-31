using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonsSkills.Models
{
    public class Person
    {
        [Key] [Required] 
        public long PersonId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        [Required] 
        public virtual List<Skill> Skills { get; set; }
    }
}
