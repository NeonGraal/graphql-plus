namespace GqlPlus.Structures;

public interface IEncoder<TInput>
{
  Structured Encode(TInput input);
}

public class Encoder<TInput>(
  Encoder<TInput>.D factory
) : DeferOne<IEncoder<TInput>>(factory)
  , IEncoder<TInput>
{
  public Structured Encode(TInput input)
    => Value.Encode(input);

  public static implicit operator Encoder<TInput>(D factory)
    => new(factory.ThrowIfNull());
}

public interface IDecoder<TOutput>
{
  IMessages Decode(IValue input, out TOutput? output);
}

public class Decoder<TOutput>(
  Decoder<TOutput>.D factory
) : DeferOne<IDecoder<TOutput>>(factory)
  , IDecoder<TOutput>
{
  public IMessages Decode(IValue input, out TOutput? output)
    => Value.Decode(input, out output);

  public static implicit operator Decoder<TOutput>(D factory)
    => new(factory.ThrowIfNull());
}
