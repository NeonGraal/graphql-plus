using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Merging;
using GqlPlus.Token;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace GqlPlus.Verifying;

public class VerifierBase
  : SubstituteBase
{
  protected TokenMessages Errors { get; } = [];
  protected ILoggerFactory Logger { get; } = For<ILoggerFactory>();

  protected static TResult EFor<TResult>()
    where TResult : class, IGqlpError
  {
    TResult result = Substitute.For<TResult>();
    result.MakeError("").ReturnsForAnyArgs(c => MakeMessages(c.ThrowIfNull().Arg<string>()));
    return result;
  }

  protected static TResult NFor<TResult>(string name)
    where TResult : class, IGqlpNamed
  {
    TResult result = EFor<TResult>();
    result.Name.Returns(name);
    return result;
  }

  protected static ITokenMessages MakeMessages(string message)
    => new TokenMessages { new TokenMessage(AstNulls.At, message) };
}

internal readonly struct ForVU<TResult>
  where TResult : class, IGqlpError
{
  internal IVerifyUsage<TResult> Intf { get; }

  public ForVU() => Intf = Substitute.For<IVerifyUsage<TResult>>();

  internal void Called() => Intf.ReceivedWithAnyArgs().Verify(Arg.Any<UsageAliased<TResult>>(), Arg.Any<ITokenMessages>());
  internal void NotCalled() => Intf.DidNotReceiveWithAnyArgs().Verify(Arg.Any<UsageAliased<TResult>>(), Arg.Any<ITokenMessages>());
}

internal readonly struct ForVA<TResult>
  where TResult : class, IGqlpAliased
{
  internal IVerifyAliased<TResult> Intf { get; }

  public ForVA() => Intf = Substitute.For<IVerifyAliased<TResult>>();

  internal void Called() => Intf.ReceivedWithAnyArgs().Verify(Arg.Any<TResult[]>(), Arg.Any<ITokenMessages>());
  internal void NotCalled() => Intf.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TResult[]>(), Arg.Any<ITokenMessages>());
}

internal readonly struct ForV<TResult>
{
  internal IVerify<TResult> Intf { get; }

  public ForV() => Intf = Substitute.For<IVerify<TResult>>();

  internal void Called() => Intf.ReceivedWithAnyArgs().Verify(Arg.Any<TResult>(), Arg.Any<ITokenMessages>());
  internal void NotCalled() => Intf.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TResult>(), Arg.Any<ITokenMessages>());
}

internal readonly struct ForM<TItem>
  where TItem : IGqlpError
{
  internal IMerge<TItem> Intf { get; }

  public ForM() => Intf = Substitute.For<IMerge<TItem>>();

  internal void Called() => Intf.ReceivedWithAnyArgs().CanMerge(Arg.Any<IEnumerable<TItem>>());
  internal void NotCalled() => Intf.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<TItem>>());
}
