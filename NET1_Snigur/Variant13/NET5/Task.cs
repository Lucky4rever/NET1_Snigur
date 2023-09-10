using System;
using System.Text;

namespace DOTNET.Variant13.NET5
{
    class Task
    {
        public readonly string Description;
        private int Assessment;

        private Solution Solution = null;

        public Task(string description)
        {
            this.Description = description;
            this.Assessment = 0;
        }

        public void SetTaskStatus(TaskStatus state)
        {
            if (this.Solution != null)
            {
                this.Solution.SetTaskStatus(state);
            }
        }

        public void SetTaskSolution(Solution solution)
        {
            this.Solution = solution;
        }

        public void Resolve()
        {
            try
            {
                this.Solution.Start();
                this.Solution.SetTaskStatus(TaskStatus.Checked);
            }
            catch (Exception)
            {
                this.SetTaskStatus(TaskStatus.Incompleted);
            }
        }

        public TaskStatus ShowStatus()
        {
            if (this.Solution != null)
            {
                return this.Solution.ShowStatus();
            }

            return TaskStatus.Incompleted;
        }

        public void SetAssessment(int assessment)
        {
            this.Assessment = assessment;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Task: {this.Description}");
            builder.AppendLine($"Process: {this.ShowStatus()}");
            builder.AppendLine($"Assessment: {this.Assessment}");

            return builder.ToString();
        }
    }
}
