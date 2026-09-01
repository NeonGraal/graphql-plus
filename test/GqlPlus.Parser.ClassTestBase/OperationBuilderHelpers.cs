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

  public static T Identified<T, T1>(this IMockBuilder builder, string name)
    where T : class, IAstIdentified
    where T1 : class
  {
    T result = builder.Error<T, T1>();
    result.Identifier.Returns(name);
    return result;
  }

  public static T Selection<T>(this IMockBuilder builder)
    where T : class, IAstSelection
  {
    T result = builder.Error<T, IAstSelection>();
    return result;
  }
}
