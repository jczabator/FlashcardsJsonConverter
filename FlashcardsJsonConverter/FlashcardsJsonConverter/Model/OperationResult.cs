namespace FlashcardsJsonConverter.Model
{
  public class OperationResult
  {
    private string _message;
    private bool _isFailed;

    public OperationResult(bool isFailed = false)
    {           
      _isFailed = isFailed;
    }

    public OperationResult(string message, bool isFailed)
    {
      _message = message;
      _isFailed = isFailed;
    }

    public string Message => _message;

    public bool IsFailed => _isFailed;

    public static OperationResult Success()
    {
      return new OperationResult();
    }

    public static OperationResult Failed(string message)
    {
      return new OperationResult(message, true);
    }
  }

  public class OperationResult<T>
    where T: class
  {
    private T _value;
    private string _message;
    private bool _isFailed;

    public OperationResult(T value, string message = null, bool isFailed = false)
    {
      _value = value;
      _message = message;
      _isFailed = isFailed;
    }    

    public OperationResult(string message, bool isFailed)
    {
      _message = message;
      _isFailed = isFailed;
    }

    public T Value => _value;

    public string Message => _message;

    public bool IsFailed => _isFailed;

    public static OperationResult<T> Success(T value)
    {
      return new OperationResult<T>(value);
    }

    public static OperationResult<T> Failed(string message)
    {
      return new OperationResult<T>(message, true);
    }
  }
}
