using UnityEngine;
using Cofdream.ToolKitRuntime.Core;

public enum UIEventType : byte
{
    None = 0,

    OpenMainView,
    //CloseMainView,

    OpenArchivesView,
    //CloseArchivesView,

}

public class UIEventDisatcher
{
    public static EventArgDispatcher<byte> Dispatcher { get; private set; } = new EventArgDispatcher<byte>();


}