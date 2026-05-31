using GqlPlus.Ast.Operation;

namespace GqlPlus;

public static class OperationBuilderHelpers
{
  public static T Identified<T>(this IMockBuilder builder, string name)
    where T : class, IAstIdentified
  {
    T result = builder.Error<T>();
    result.Identifier.Returns(name);
    return result;
  }
}
