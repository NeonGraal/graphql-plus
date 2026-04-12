namespace GqlPlus.Decoding;

internal class DecoderRepositoryBuilder
  : BaseFactory<IDecoderRepository>, IDecoderRepositoryBuilder
{
  internal readonly FactoryDict Decoders = [];
  internal Factory<INameFilterDecoder, IDecoderRepository>? _nameFilter;

  public IDecoderRepositoryBuilder AddDecoder<T>(Factory<IDecoder<T>, IDecoderRepository> factory)
    => this.FluentAction(b => b.Decoders[typeof(T)] = factory);

  public IDecoderRepositoryBuilder AddNameFilter(Factory<INameFilterDecoder, IDecoderRepository> factory)
    => this.FluentAction(b => b._nameFilter = factory);
}
