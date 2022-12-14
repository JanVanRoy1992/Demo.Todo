using Demo.Todo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Todo.Application.Todo.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public DateTime DueDate { get; set; }
    }
}
