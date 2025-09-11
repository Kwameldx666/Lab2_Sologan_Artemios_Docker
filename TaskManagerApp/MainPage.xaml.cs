using TaskManagerApp.Models;
using TaskManagerApp.Services;

namespace TaskManagerApp;

public partial class MainPage : ContentPage
{
    private readonly TaskService _taskService;
    private readonly CategoryService _categoryService;

    public MainPage(TaskService taskService, CategoryService categoryService)
    {
        InitializeComponent();
        _taskService = taskService;
        _categoryService = categoryService;
    }

    private async void OnLoadTasksClicked(object? sender, EventArgs e)
    {
        try
        {
            StatusLabel.Text = "Loading tasks...";
            var tasks = await _taskService.GetAllTasksAsync();
            TasksCollectionView.ItemsSource = tasks;
            StatusLabel.Text = $"Loaded {tasks.Count} tasks successfully!";
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error loading tasks: {ex.Message}";
        }
    }

    private async void OnCreateTaskClicked(object? sender, EventArgs e)
    {
        try
        {
            StatusLabel.Text = "Creating sample task...";
            var newTask = new TaskItem
            {
                Title = $"Sample Task {DateTime.Now:HH:mm:ss}",
                IsComplete = false
            };

            var createdTask = await _taskService.CreateTaskAsync(newTask);
            if (createdTask != null)
            {
                StatusLabel.Text = $"Task '{createdTask.Title}' created successfully!";
                // Refresh the list
                OnLoadTasksClicked(sender, e);
            }
            else
            {
                StatusLabel.Text = "Failed to create task";
            }
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error creating task: {ex.Message}";
        }
    }

    private async void OnLoadCategoriesClicked(object? sender, EventArgs e)
    {
        try
        {
            StatusLabel.Text = "Loading categories...";
            var categories = await _categoryService.GetAllCategoriesAsync();
            CategoriesCollectionView.ItemsSource = categories;
            StatusLabel.Text = $"Loaded {categories.Count} categories successfully!";
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error loading categories: {ex.Message}";
        }
    }

    private async void OnCreateCategoryClicked(object? sender, EventArgs e)
    {
        try
        {
            StatusLabel.Text = "Creating sample category...";
            var newCategory = new Category
            {
                Name = $"Sample Category {DateTime.Now:HH:mm:ss}",
                TaskIds = new List<int>()
            };

            var createdCategory = await _categoryService.CreateCategoryAsync(newCategory);
            if (createdCategory != null)
            {
                StatusLabel.Text = $"Category '{createdCategory.Name}' created successfully!";
                // Refresh the list
                OnLoadCategoriesClicked(sender, e);
            }
            else
            {
                StatusLabel.Text = "Failed to create category";
            }
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error creating category: {ex.Message}";
        }
    }
}
