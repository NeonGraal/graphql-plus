using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Schema;
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

  protected static T NFor<T>(string name, string contents = "")
    where T : class, IGqlpNamed
  {
    T result = EFor<T>();
    result.Name.Returns(name);
    result.Description.Returns(contents);
    return result;
  }

  protected static T[] NForA<T>(params string[] names)
    where T : class, IGqlpNamed
    => [.. names.Select(static n => NFor<T>(n))];

  protected static ITokenMessages MakeMessages(string message)
    => new TokenMessages { new TokenMessage(AstNulls.At, message) };
}
