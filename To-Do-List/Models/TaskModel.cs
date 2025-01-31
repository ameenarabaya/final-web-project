using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace To_Do_List.Models
{
    public class TaskModel
    {
    

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [DefaultValue(false)]
        public bool Complete { get; set; } = false;
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
    }

}
