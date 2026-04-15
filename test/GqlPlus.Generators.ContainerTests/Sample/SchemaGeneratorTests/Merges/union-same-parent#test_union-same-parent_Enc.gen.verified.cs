//HintName: test_union-same-parent_Enc.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

internal class testUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSamePrnt>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSamePrnt input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();
}

internal class testPrntUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionSamePrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestPrntUnionSamePrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();
}

internal static class test_union_same_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_union_same_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestUnionSamePrnt>(r => new testUnionSamePrntEncoder(r))
      .AddEncoder<ItestPrntUnionSamePrnt>(r => new testPrntUnionSamePrntEncoder(r));
}
