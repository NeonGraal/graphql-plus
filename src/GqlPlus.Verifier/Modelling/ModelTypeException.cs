namespace GqlPlus.Verifier.Modelling;

[ExcludeFromCodeCoverage]
public class ModelTypeException<TModel>
  : Exception
{
  private static string ModelTypeMessage(object? type)
    => $"Type '{type?.GetType().ExpandTypeName() ?? "null"}' Model is not '{typeof(TModel).ExpandTypeName()}'";

  public ModelTypeException(object? type)
    : base(ModelTypeMessage(type))
  { }

  public ModelTypeException()
  { }

  public ModelTypeException(string message)
    : base(message)
  { }

  public ModelTypeException(string message, Exception innerException)
    : base(message, innerException)
  { }
}
