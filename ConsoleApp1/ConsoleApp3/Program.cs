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
    public TaskStatus Status { get; set; }

    public Task(string name)
    {
        Name = name;
        Status = TaskStatus.Todo;
    }
}

// Định nghĩa delegate để theo dõi sự thay đổi trạng thái của công việc
public delegate void TaskStatusChangedEventHandler(object sender, TaskStatusChangedEventArgs e);

// Định nghĩa một lớp chứa thông tin của sự kiện khi trạng thái của công việc thay đổi
public class TaskStatusChangedEventArgs : EventArgs
{
    public Task Task { get; }
    public TaskStatus NewStatus { get; }

    public TaskStatusChangedEventArgs(Task task, TaskStatus newStatus)
    {
        Task = task;
        NewStatus = newStatus;
    }
}

// Định nghĩa lớp quản lý danh sách công việc và các thao tác liên quan
public class TaskManager
{
    // Thay đổi phạm vi truy cập của thuộc tính tasks sang public
    public List<Task> tasks = new List<Task>();


    // Sự kiện được kích hoạt khi trạng thái của một công việc thay đổi
    public event TaskStatusChangedEventHandler TaskStatusChanged;

    // Phương thức để thêm một công việc mới vào danh sách
    public void AddTask(string name)
    {
        Task newTask = new Task(name);
        tasks.Add(newTask);
    }

    // Phương thức để hiển thị danh sách các công việc cùng trạng thái
    public void DisplayTasksByStatus(TaskStatus status)
    {
        Console.WriteLine($"Tasks with status {status}:");
        foreach (var task in tasks)
        {
            if (task.Status == status)
            {
                Console.WriteLine($"- {task.Name}");
            }
        }
    }

    // Phương thức để đánh dấu một công việc là đã hoàn thành hoặc chưa hoàn thành
    public void MarkTaskStatus(Task task, TaskStatus newStatus)
    {
        task.Status = newStatus;
        OnTaskStatusChanged(new TaskStatusChangedEventArgs(task, newStatus));
    }

    // Phương thức kích hoạt sự kiện khi trạng thái của một công việc thay đổi
    protected virtual void OnTaskStatusChanged(TaskStatusChangedEventArgs e)
    {
        TaskStatusChanged?.Invoke(this, e);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        // Đăng ký sự kiện để theo dõi thay đổi trạng thái của công việc
        taskManager.TaskStatusChanged += TaskStatusChangedHandler;

        taskManager.AddTask("Task 1");
        taskManager.AddTask("Task 2");
        taskManager.AddTask("Task 3");

        taskManager.DisplayTasksByStatus(TaskStatus.Todo);
        taskManager.MarkTaskStatus(taskManager.tasks[2], TaskStatus.Done);
        taskManager.DisplayTasksByStatus(TaskStatus.Done);
        taskManager.DisplayTasksByStatus(TaskStatus.Todo);
    }

    static void TaskStatusChangedHandler(object sender, TaskStatusChangedEventArgs e)
    {
        Console.WriteLine($"Task '{e.Task.Name}' has changed status to {e.NewStatus}");
    }
}
