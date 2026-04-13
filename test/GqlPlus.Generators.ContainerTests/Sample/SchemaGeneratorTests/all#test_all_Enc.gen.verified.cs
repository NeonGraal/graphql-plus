//HintName: test_all_Enc.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

internal class testGuidEncoder : IEncoder<ItestGuid>
{
  public Structured Encode(ItestGuid input)
    => new(input.Value);
}

internal class testOneEncoder : IEncoder<testOne>
{
  public Structured Encode(testOne input)
    => new(input.ToString(), "_One");
}

internal class testManyEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestMany>
{
  private readonly IEncoder<ItestGuid> _guid = encoders.EncoderFor<ItestGuid>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestMany input)
    => input switch {
      { AsGuid: { } m } => _guid.Encode(m),
      { AsNumber: { } m } => _number.Encode(m),
      _ => Structured.Empty()
    };
}

internal class testFieldEncoder : IEncoder<ItestFieldObject>
{
  public Structured Encode(ItestFieldObject input)
    => Structured.Empty()
      .Add("strings", input.Strings.Encode());
}

internal class testParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestParamObject>
{
  private readonly IEncoder<ItestMany> _itestMany = encoders.EncoderFor<ItestMany>();
  public Structured Encode(ItestParamObject input)
    => Structured.Empty()
      .AddEncoded("afterId", input.AfterId, _itestMany)
      .AddEncoded("beforeId", input.BeforeId, _itestMany);
}

internal class testAllEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAllObject>
{
  private readonly IEncoder<ItestField> _itestField = encoders.EncoderFor<ItestField>();
  public Structured Encode(ItestAllObject input)
    => Structured.Empty()
      .AddEncoded("items", input.Items(null), _itestField);
}
