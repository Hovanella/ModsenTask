namespace ModsenTask.Exceptions;

public class EventsNotFoundException : Exception
{
    public EventsNotFoundException(string message) : base(message)
    {
    }
}