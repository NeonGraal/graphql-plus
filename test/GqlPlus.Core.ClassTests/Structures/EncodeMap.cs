namespace GqlPlus.Structures;

internal sealed class EncodeMap
  : IEncoder<Map<string>>
{
  public IGqlpValue Encode(Map<string> model)
    => model.Encode(s => s.Encode());
}
