using System.ComponentModel.DataAnnotations;

namespace BasicCRUDWeb.Models
{
    public class Todo
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Dolist { get; set; }
        [Required]
        public int Priority { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
