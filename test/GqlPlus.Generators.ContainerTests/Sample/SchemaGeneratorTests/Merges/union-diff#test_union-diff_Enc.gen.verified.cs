//HintName: test_union-diff_Enc.gen.cs
// Generated from {CurrentDirectory}union-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_diff;

internal class testUnionDiffEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDiff>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDiff input)
    => input switch {
      { AsBoolean: { } m } => _boolean.Encode(m),
      { AsNumber: { } m } => _number.Encode(m),
      _ => Structured.Empty()
    };
}
