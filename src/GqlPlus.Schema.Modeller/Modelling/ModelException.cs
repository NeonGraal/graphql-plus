namespace GqlPlus.Modelling;

public class ModelException
  : Exception
{
  public ModelException()
  { }

  public ModelException(string message)
    : base(message)
  { }

  public ModelException(string message, Exception innerException)
    : base(message, innerException)
  { }
}
