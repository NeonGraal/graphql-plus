using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Modelling;

public class ModelException
  : Exception
{
  public ModelException()
  { }

  public ModelException(string message)
    : base(message)
  { }

  [ExcludeFromCodeCoverage]
  public ModelException(string message, Exception innerException)
    : base(message, innerException)
  { }
}
