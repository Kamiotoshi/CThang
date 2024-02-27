using System;
using System.Collections.Generic;

// Định nghĩa một enum để biểu diễn trạng thái của công việc
public enum TaskStatus
{
    Todo,
    Done
}

// Định nghĩa một lớp để lưu trữ thông tin của một công việc
public class Task
{
    public string Name { get; }
    private TaskStatus status;
    public TaskStatus Status
    {
        get { return status; }
        set
        {
            if (status != value)
            {
                status = value;
                OnStatusChanged();
            }
        }
    }

    // Sự kiện được kích hoạt khi trạng thái của công việc thay đổi
    public event EventHandler StatusChanged;

    public Task(string name)
    {
        Name = name;
        Status = TaskStatus.Todo;
    }

    protected virtual void OnStatusChanged()
    {
        StatusChanged?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static List<Task> allTasks = new List<Task>();
    static List<Task> todoTasks = new List<Task>();
    static List<Task> doneTasks = new List<Task>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Task Manager!");

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. Mark a task as done");
            Console.WriteLine("3. List all tasks");
            Console.WriteLine("4. List todo tasks");
            Console.WriteLine("5. List done tasks");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    MarkTaskAsDone();
                    break;
                case "3":
                    ListAllTasks();
                    break;
                case "4":
                    ListTodoTasks();
                    break;
                case "5":
                    ListDoneTasks();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter the task name: ");
        string taskName = Console.ReadLine();
        Task newTask = new Task(taskName);
        newTask.StatusChanged += Task_StatusChanged; // Đăng ký sự kiện cho công việc mới
        allTasks.Add(newTask);
        todoTasks.Add(newTask); // Thêm vào danh sách công việc chưa hoàn thành
        Console.WriteLine("Task added successfully!");
    }

    static void Task_StatusChanged(object sender, EventArgs e)
    {
        Task task = (Task)sender;
        Console.WriteLine($"Task '{task.Name}' has been marked as {task.Status}.");
        if (task.Status == TaskStatus.Done)
        {
            doneTasks.Add(task); // Nếu công việc đã hoàn thành, thêm vào danh sách công việc đã hoàn thành
            todoTasks.Remove(task); // Xóa khỏi danh sách công việc chưa hoàn thành
        }
        else
        {
            todoTasks.Add(task); // Ngược lại, thêm vào danh sách công việc chưa hoàn thành
            doneTasks.Remove(task); // Xóa khỏi danh sách công việc đã hoàn thành
        }
    }

    static void MarkTaskAsDone()
    {
        if (todoTasks.Count == 0)
        {
            Console.WriteLine("No tasks available to mark as done.");
            return;
        }

        Console.WriteLine("Select the task to mark as done:");
        for (int i = 0; i < todoTasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todoTasks[i].Name}");
        }

        int index;
        while (true)
        {
            Console.Write("Enter the task number: ");
            if (int.TryParse(Console.ReadLine(), out index) && index >= 1 && index <= todoTasks.Count)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid task number.");
        }

        Task task = todoTasks[index - 1];
        task.Status = TaskStatus.Done;
    }

    static void ListAllTasks()
    {
        if (allTasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("List of all tasks:");
        foreach (var task in allTasks)
        {
            Console.WriteLine($"- {task.Name} [{task.Status}]");
        }
    }

    static void ListTodoTasks()
    {
        if (todoTasks.Count == 0)
        {
            Console.WriteLine("No todo tasks available.");
            return;
        }

        Console.WriteLine("List of todo tasks:");
        foreach (var task in todoTasks)
        {
            Console.WriteLine($"- {task.Name}");
        }
    }

    static void ListDoneTasks()
    {
        if (doneTasks.Count == 0)
        {
            Console.WriteLine("No done tasks available.");
            return;
        }

        Console.WriteLine("List of done tasks:");
        foreach (var task in doneTasks)
        {
            Console.WriteLine($"- {task.Name}");
        }
    }
}
