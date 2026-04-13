using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Encoding;

internal class EncoderRepository(
  EncoderRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IEncoderRepository>(loggerFactory)
  , IEncoderRepository
{
  public IEncoder<T> EncoderFor<T>()
    => Cached<T, IEncoder<T>>(builder.Encoders, "encoder", this);

  private readonly ConcurrentDictionary<Type, IEnumerable<object>> _lists = new();

  public IEnumerable<TList> EncodersFor<TList>()
    where TList : class
    => (IEnumerable<TList>)_lists.GetOrAdd(
      typeof(TList),
      _ => builder.FactoriesFor<TList>().Select(f => f(this)));
}
