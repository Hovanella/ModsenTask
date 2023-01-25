namespace ModsenTask.Exceptions;

public class NameAlreadyExistsException : Exception
{
    public NameAlreadyExistsException(string message) : base(message)
    {
    }
}