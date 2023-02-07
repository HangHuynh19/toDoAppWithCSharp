using System.Runtime.Serialization;

namespace ToDoAppWithCSharp.Contracts.Util;
public enum Status {
    //[EnumMember(Value="Not Started")]
    NotStarted = 0, 
    //[EnumMember(Value="On Going")]
    OnGoing = 1, 
    //[EnumMember(Value="Completed")]
    Completed = 2
}
