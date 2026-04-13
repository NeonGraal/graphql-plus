//HintName: test_union-parent-dup_Enc.gen.cs
// Generated from {CurrentDirectory}union-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

internal class testUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDup input)
    => input switch {
      { AsNumber: { } m } => _number.Encode(m),
      _ => Structured.Empty()
    };
}

internal class testPrntUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDup input)
    => input switch {
      { AsNumber: { } m } => _number.Encode(m),
      _ => Structured.Empty()
    };
}
