// Elmo 
// 1/2/2026
// Lab 3 to do list
// Purpose of this code is task managment and user interface

using System;
using System.Collections.Generic;

class Task
{
    
    private int id;
    private string title;
    private string description;
    private bool isComplete;

    
    public Task(int id, string title, string description)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        isComplete = false;
    }


    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public bool IsComplete
    {
        get { return isComplete; }
        set { isComplete = value; }
    }

    
    public void DisplayTask()
    {
        string checkbox = isComplete ? "[X]" : "[ ]";
        Console.WriteLine($"{checkbox} {id}   {title}");
    }

    
    public void DisplayDescription()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Description: {description}");
        Console.WriteLine($"Completed: {isComplete}");
    }

    
    public void MarkAsCompleted()
    {
        isComplete = !isComplete;
    }
}

class Program
{
    static void Main()
    {
        List<Task> taskList = new List<Task>();
        
        while (true)
        {
            Console.Clear();
            DisplayTasks(taskList);
            Console.WriteLine();
            Console.WriteLine("press + to add a task");
            Console.WriteLine("press x to toggle whether or not the task is complete");
            Console.WriteLine("Press i to view a task's information.");
            Console.WriteLine("Press q to quit");
            
            string choice = Console.ReadLine();

            if (choice == "+")
            {
                Console.Write("task title ");
                string title = Console.ReadLine();
                Console.Write("task description ");
                string description = Console.ReadLine();
                
                int newId = taskList.Count + 1;
                taskList.Add(new Task(newId, title, description));
            }
            else if (choice == "i")
            {
                Console.Write("enter task ID: ");
                string input = Console.ReadLine();
                int id;
                
                if(int.TryParse(input, out id))
                {
                    Task task = FindTask(taskList, id);
                    if (task != null)
                    {
                        Console.Clear();
                        task.DisplayDescription();
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("task not found");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("invalid ID");
                    Console.ReadKey();
                }
            }
            else if (choice == "x")
            {
                Console.Write("enter task ID ");
                string input = Console.ReadLine();
                int id;
                
                if(int.TryParse(input, out id))
                {
                    Task task = FindTask(taskList, id);
                    if (task != null)
                    {
                        task.MarkAsCompleted();
                    }
                    else
                    {
                        Console.WriteLine("task not found");
                        Console.ReadKey();
                    }
                }
            }
            else if (choice == "q")
            {
                break;
            }
        }
    }

    static void DisplayTasks(List<Task> taskList)
    {
        Console.WriteLine("  ID  Task");
        Console.WriteLine("-----------------------------------");
        
        foreach (Task task in taskList)
        {
            task.DisplayTask();
        }
    }

    static Task FindTask(List<Task> taskList, int id)
    {
        foreach (Task task in taskList)
        {
            if (task.ID == id)
            {
                return task;
            }
        }
        return null;
    }
}
