namespace GqlPlus.Structures;

internal sealed class EncodeMap
  : IEncoder<Map<string>>
{
  public Structured Encode(Map<string> model)
    => model.Encode(s => new(s));
}
