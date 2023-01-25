namespace ModsenTask.Exceptions;

public class ForbiddenEventException : Exception
{
    public ForbiddenEventException(string message) : base(message)
    {
    }
}