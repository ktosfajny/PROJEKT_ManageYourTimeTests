using NUnit.Framework;
using System;

namespace ManageYourTime.Tests
{
    public class TasksCollectionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0,10)]
        [TestCase(2, 10)]
        [TestCase(5, 10)]
        [TestCase(8, 10)]
        [TestCase(10, 10)]
        public void GetImportantTasksNumber_GivenNumberOfImportantTasks_ReturnsImportantTasksNumber(int importantTasksQuantanity, int allTasks)
        {
            // Arange
            TasksCollection tasksCollection = new TasksCollection();

            for (int i = 0; i < allTasks; i++)
            {
                Task task = new Task(
                    "Task Title",
                    "Task Type",
                    i < importantTasksQuantanity ? true : false,
                    DateTime.Today
                    );
                tasksCollection.ListWithTasks.Add(task);
            }

            // Act
            var result = tasksCollection.getImportantTasksNumber();


            // Assert
            Assert.AreEqual(result, importantTasksQuantanity);
        }





        [Test]
        public void CheckIfTaskExists_TaskExists_ReturnsTrue()
        {
            // Arange
            TasksCollection tasksCollection = new TasksCollection();
            Task task = new Task("pass the test", "meeting", false, DateTime.Today);
            tasksCollection.ListWithTasks.Add(task);

            Task newTask = new Task("pass the test", "meeting", false, DateTime.Today);

            // Act
            bool taskExists = tasksCollection.checkIfTaskExists(newTask.Tytul, DateTime.Today);
            
            // Assert
            Assert.IsTrue(taskExists);
        }
    }
}