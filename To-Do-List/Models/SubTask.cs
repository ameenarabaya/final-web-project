using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do_List.Models
{
    public class SubTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        [DefaultValue(false)]
        public bool Done { get; set; } = false;
        public int TaskModelId { get; set; }

        public TaskModel TaskModel { get; set; }
    }
}