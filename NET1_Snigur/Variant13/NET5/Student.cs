using System;

namespace DOTNET.Variant13.NET5
{
    class Student
    {
        public string Name { get; private set; }
        private int Assessment { get; set; }
        private Task Task { get; set; }

        public Student(string name)
        {
            this.Name = name;
            this.Assessment = 0;
            this.Task = null;
        }

        public void GiveTask(string description)
        {
            this.Task = new Task(description);
        }

        public void GiveTask(Task task)
        {
            this.Task = task;
        }

        public Task ShowTask()
        {
            return this.Task;
        }

        public void SetTaskStatus(TaskStatus status)
        {
            this.Task.SetTaskStatus(status);
        }

        public void MakeSolution(Solution solution)
        {
            this.Task.SetTaskSolution(solution);
        }

        public void MakeSolution(Action action)
        {
            this.Task.SetTaskSolution(new Solution(action));
        }

        public void Resolve()
        {
            this.Task.Resolve();
        }

        public void SetAssessment(int assessment)
        {
            if (this.Task == null) return;

            if (assessment == 0)
            {
                this.Task.SetTaskStatus(TaskStatus.Incompleted);
            }
            else
            {
                this.Task.SetAssessment(assessment);
                this.Task.SetTaskStatus(TaskStatus.Completed);

                this.Assessment += assessment;
            }
        }

        public int ShowAssessment()
        {
            return this.Assessment;
        }

        public TaskStatus ShowTaskStatus()
        {
            if (this.Task == null) return TaskStatus.Incompleted;

            return this.Task.ShowStatus();
        }
    }
}
