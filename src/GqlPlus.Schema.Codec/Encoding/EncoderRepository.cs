using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Encoding;

internal class EncoderRepository(
  EncoderRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IEncoderRepository>(loggerFactory)
  , IEncoderRepository
{
  public IEncoder<T> EncoderFor<T>([CallerMemberName] string callerName = "")
    => Cached<T, IEncoder<T>>(builder.Encoders, "encoder for " + callerName, this);

  private readonly ConcurrentDictionary<Type, IEnumerable<object>> _lists = new();

  public IEnumerable<TList> EncodersFor<TList>([CallerMemberName] string callerName = "")
    where TList : class
    => (IEnumerable<TList>)_lists.GetOrAdd(
      typeof(TList),
      _ => builder.FactoriesFor<TList>(callerName).Select(f => f(this)));
}
