//HintName: test_union-parent_Enc.gen.cs
// Generated from {CurrentDirectory}union-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent;

internal class testUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestUnionPrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();
}

internal class testPrntUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrnt>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrnt input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}
