using GqlPlus.Abstractions;
using GqlPlus.Ast;
using GqlPlus.Token;
using NSubstitute;

namespace GqlPlus;

public class SubstituteBase
{
  protected static TResult For<TResult>()
    where TResult : class
    => Substitute.For<TResult>();

  protected static T EFor<T>()
    where T : class, IGqlpError
  {
    T result = Substitute.For<T>();
    result.MakeError("").ReturnsForAnyArgs(c => MakeMessages(c.ThrowIfNull().Arg<string>()));
    return result;
  }

  protected static ITokenMessages MakeMessages(string message)
    => new TokenMessages { new TokenMessage(AstNulls.At, message) };
}
