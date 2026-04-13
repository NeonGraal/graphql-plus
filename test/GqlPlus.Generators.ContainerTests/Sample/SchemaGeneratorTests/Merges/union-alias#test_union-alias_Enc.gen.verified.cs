//HintName: test_union-alias_Enc.gen.cs
// Generated from {CurrentDirectory}union-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_alias;

internal class testUnionAliasEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionAlias>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionAlias input)
    => input switch {
      { AsBoolean: { } m } => _boolean.Encode(m),
      { AsNumber: { } m } => _number.Encode(m),
      _ => Structured.Empty()
    };
}
