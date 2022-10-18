using Demo.Todo.Application.Todo.Dtos;
using Demo.Todo.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Todo.Application.Todo.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<TodoDto[]>
    {
        public TodoStatus Status { get; set; }
    }
}
