namespace GqlPlus.Decoding;

internal class DecoderRepositoryBuilder
  : BaseFactory<IDecoderRepository>, IDecoderRepositoryBuilder
{
  internal readonly FactoryDict Decoders = [];

  public IDecoderRepositoryBuilder AddDecoder<T>(Factory<IDecoder<T>, IDecoderRepository> factory)
    => this.FluentAction(b => b.Decoders[typeof(T)] = factory);

  IDecoderRepositoryBuilder IDecoderRepositoryBuilder.AddDecoder<TDecoder, TBase>(Factory<TDecoder, IDecoderRepository> factory)
    => this.FluentAction(b => b.Decoders[typeof(TDecoder)] = factory);
}
