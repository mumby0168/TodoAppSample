using System;

namespace WpfApp2.Models
{
    public class TodoItem
    {

        public TodoItem(string name, DateTime completedBy)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }

            if (completedBy.Date < DateTime.Now.Date)
            {
                throw new InvalidOperationException();
            }

            IsCompleted = false;
            Name = name;
            CompletedBy = completedBy;
            Id = Guid.NewGuid();
        }

        public void CompleteTask()
        {
            if (IsCompleted == true)
            {
                throw new InvalidOperationException();
            }

            CompletedOn = DateTime.Now;

            IsCompleted = true;
        }

        public Guid Id { get; }

        public DateTime CompletedOn { get; private set; }

        public string Name { get; private set; }

        public DateTime CompletedBy { get; private set; }

        public bool IsCompleted { get; private set; }
    }
}
