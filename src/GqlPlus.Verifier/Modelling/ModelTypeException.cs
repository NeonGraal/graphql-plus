namespace GqlPlus.Verifier.Modelling;

public class ModelTypeException<TModel>(object? type)
  : Exception(ModelTypeMessage(type))
{
  private static string ModelTypeMessage(object? type)
    => $"Type '{type?.GetType().ExpandTypeName() ?? "null"}' Model is not '{typeof(TModel).ExpandTypeName()}'";
}
