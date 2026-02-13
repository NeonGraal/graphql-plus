using GqlPlus.Merging;
using GqlPlus.Verifying;
using Microsoft.Extensions.Logging;

namespace GqlPlus;

public class VerifierTestsBase
  : SubstituteBase
{
  protected Messages Errors { get; } = [];

  protected ILoggerFactory LoggerFactory { get; } = A.Of<ILoggerFactory>();
  private readonly ILogger _logger = A.Of<ILogger>();

  public VerifierTestsBase()
  {
    _logger.IsEnabled(Arg.Any<LogLevel>())
      .ReturnsForAnyArgs(true);

    LoggerFactory.CreateLogger(Arg.Any<string>())
      .ReturnsForAnyArgs(_logger);
  }

  protected void LoggerCalled(LogLevel level, string message, int times = 1)
  {
#pragma warning disable CA1873 // Avoid potentially expensive logging
    _logger.Received(times).Log(
      level,
      Arg.Any<EventId>(),
      Arg.Is<object>(o => $"{o}".Contains(message)),
      Arg.Any<Exception>(),
      Arg.Any<Func<object, Exception?, string>>()
    );
#pragma warning restore CA1873 // Avoid potentially expensive logging
  }
}

internal readonly struct ForVU<TResult>
  where TResult : class, IGqlpError
{
  internal IVerifyUsage<TResult> Intf { get; }

  public ForVU() => Intf = Substitute.For<IVerifyUsage<TResult>>();

  internal void Called() => Intf.ReceivedWithAnyArgs().Verify(Arg.Any<UsageAliased<TResult>>(), Arg.Any<IMessages>());
  internal void NotCalled() => Intf.DidNotReceiveWithAnyArgs().Verify(Arg.Any<UsageAliased<TResult>>(), Arg.Any<IMessages>());
}

internal readonly struct ForVA<TResult>
  where TResult : class, IGqlpAliased
{
  internal IVerifyAliased<TResult> Intf { get; }

  public ForVA() => Intf = Substitute.For<IVerifyAliased<TResult>>();

  internal void Called() => Intf.ReceivedWithAnyArgs().Verify(Arg.Any<TResult[]>(), Arg.Any<IMessages>());
  internal void NotCalled() => Intf.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TResult[]>(), Arg.Any<IMessages>());
}

internal readonly struct ForV<TResult>
{
  internal IVerify<TResult> Intf { get; }

  public ForV() => Intf = Substitute.For<IVerify<TResult>>();

  internal void Called() => Intf.ReceivedWithAnyArgs().Verify(Arg.Any<TResult>(), Arg.Any<IMessages>());
  internal void NotCalled() => Intf.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TResult>(), Arg.Any<IMessages>());
}

internal readonly struct ForM<TItem>
  where TItem : IGqlpError
{
  internal IMerge<TItem> Intf { get; }

  public ForM() => Intf = Substitute.For<IMerge<TItem>>();

  internal void CanMergeReturns(IMessages errors)
    => Intf.CanMerge(Arg.Any<IEnumerable<TItem>>()).ReturnsForAnyArgs(errors);

  internal void Called() => Intf.ReceivedWithAnyArgs().CanMerge(Arg.Any<IEnumerable<TItem>>());
  internal void NotCalled() => Intf.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<TItem>>());
}
