namespace GqlPlus.Structures;

internal sealed class EncodeString
  : IEncoder<string>
{
  public Structured Encode(string model)
    => model.Encode();
}
