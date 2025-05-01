using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Merging;
using GqlPlus.Token;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Verifying;

public class VerifierBase
  : SubstituteBase
{
  protected TokenMessages Errors { get; } = [];
  protected ILoggerFactory LoggerFactory { get; } = For<ILoggerFactory>();
  protected ILogger Logger { get; } = For<ILogger>();

  public VerifierBase()
  {
    Logger.IsEnabled(Arg.Any<LogLevel>())
      .ReturnsForAnyArgs(true);

    LoggerFactory.CreateLogger(Arg.Any<string>())
      .ReturnsForAnyArgs(Logger);
    LoggerFactory.CreateLogger<VerifierBase>()
      .ReturnsForAnyArgs(Logger);
  }

  protected static T EFor<T>()
    where T : class, IGqlpError
  {
    T result = Substitute.For<T>();
    result.MakeError("").ReturnsForAnyArgs(c => MakeMessages(c.ThrowIfNull().Arg<string>()));
    return result;
  }

  protected static T NFor<T>(string name)
    where T : class, IGqlpNamed
  {
    T result = EFor<T>();
    result.Name.Returns(name);
    return result;
  }

  protected static T[] NForA<T>(params string[] names)
    where T : class, IGqlpNamed
    => [.. names.Select(NFor<T>)];

  protected static ITokenMessages MakeMessages(string message)
    => new TokenMessages { new TokenMessage(AstNulls.At, message) };

  protected void LoggerCalled(LogLevel level, string message, int times = 1)
  {
    Logger.Received(times).Log(
      level,
      Arg.Any<EventId>(),
      Arg.Is<object>(o => $"{o}".Contains(message)),
      Arg.Any<Exception>(),
      Arg.Any<Func<object, Exception?, string>>()
    );
  }
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
