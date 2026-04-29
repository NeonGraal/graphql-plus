//HintName: test_union-parent-dup_Enc.gen.cs
// Generated from {CurrentDirectory}union-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

internal class testUnionPrntDupEncoder(
  IEncoderRepository encoders
: testPrntUnionPrntDupEncoder, IEncoder<ItestUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : base.Encode(input);

  internal static testUnionPrntDupEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testPrntUnionPrntDupEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_union_parent_dupEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_union_parent_dupEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestUnionPrntDup>(testUnionPrntDupEncoder.Factory)
      .AddEncoder<ItestPrntUnionPrntDup>(testPrntUnionPrntDupEncoder.Factory);
}
