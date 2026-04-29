//HintName: test_union-same-parent_Enc.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

internal class testUnionSamePrntEncoder(
  IEncoderRepository encoders
: testPrntUnionSamePrntEncoder, IEncoder<ItestUnionSamePrnt>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSamePrnt input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : base.Encode(input);

  internal static testUnionSamePrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionSamePrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestPrntUnionSamePrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();

  internal static testPrntUnionSamePrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_union_same_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_union_same_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestUnionSamePrnt>(testUnionSamePrntEncoder.Factory)
      .AddEncoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntEncoder.Factory);
}
