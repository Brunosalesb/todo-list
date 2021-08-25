using System.ComponentModel;

namespace ToDoList.Domain.Shared
{
    public enum EGenericOperations
    {
        [Description("Record saved successfully.")]
        Record_Saved_Successfully,

        [Description("Record updated successfully.")]
        Record_Updated_Successfully,

        [Description("Record deleted successfully.")]
        Record_Deleted_Successfully,
    }
}
