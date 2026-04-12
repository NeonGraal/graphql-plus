using Microsoft.Extensions.Logging;

namespace GqlPlus.Encoding;

internal class EncoderRepository
  : BaseRepository<IEncoderRepository>
  , IEncoderRepository
{
  private readonly EncoderRepositoryBuilder _builder;
  private readonly Lazy<IEnumerable<ITypeEncoder>> _typeEncoders;

  public EncoderRepository(EncoderRepositoryBuilder builder, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _builder = builder;
    _typeEncoders = new(() => [.. builder.TypeEncoderFactories.Select(f => (ITypeEncoder)f(this))]);
  }

  public IEncoder<T> EncoderFor<T>()
    where T : IModelBase
    => Cached<T, IEncoder<T>>(_builder.Encoders, "encoder", this);

  public IEnumerable<ITypeEncoder> TypeEncoders => _typeEncoders.Value;
}
