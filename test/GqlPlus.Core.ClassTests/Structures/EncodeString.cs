namespace GqlPlus.Structures;

internal sealed class EncodeString
  : IEncoder<string>
{
  public IGqlpValue Encode(string model)
    => model.Encode();
}
