using System;

namespace ToDoList.Domain.Shared
{
    public class ResultData
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
