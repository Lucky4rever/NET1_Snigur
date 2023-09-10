using System;

namespace DOTNET.Variant13.NET5
{
    class Solution
    {
        private TaskStatus Status;
        private readonly Action Result;

        public Solution(Action result)
        {
            this.Result = result;
            this.Status = TaskStatus.Issued;
        }

        public TaskStatus ShowStatus()
        {
            return this.Status;
        }

        public void SetTaskStatus(TaskStatus state)
        {
            this.Status = state;
        }

        public void Start()
        {
            try
            {
                this.Result();
            }
            catch (Exception)
            {
                this.Status = TaskStatus.Incompleted;
            }
        }
    }
}
