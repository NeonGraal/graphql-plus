using GqlPlus.Ast;
using GqlPlus.Token;
using NSubstitute;
using NSubstitute.Core;

namespace GqlPlus.Verifying;

public class VerifierBase
{
  protected TokenMessages Errors { get; } = [];
  protected static TResult For<TResult>()
    where TResult : class
    => Substitute.For<TResult>();

  protected static IVerify<TResult> VFor<TResult>()
    where TResult : class
    => Substitute.For<IVerify<TResult>>();

  protected static ITokenMessages MakeMessages(CallInfo callInfo)
    => MakeMessages(callInfo.ThrowIfNull().Arg<string>());

  protected static ITokenMessages MakeMessages(string message)
    => new TokenMessages { new TokenMessage(AstNulls.At, message) };
}
