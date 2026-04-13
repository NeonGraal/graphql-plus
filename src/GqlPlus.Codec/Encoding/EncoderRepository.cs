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

  public IEnumerable<TList> EncodersFor<TList>()
    where TList : class
    => builder.FactoriesFor<TList>().Select(f => f(this));
}
