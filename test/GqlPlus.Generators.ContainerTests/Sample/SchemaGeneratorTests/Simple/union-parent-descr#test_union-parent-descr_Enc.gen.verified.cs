//HintName: test_union-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}union-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_descr;

internal class testUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionPrntDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testPrntUnionPrntDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_union_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_union_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestUnionPrntDescr>(testUnionPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntUnionPrntDescr>(testPrntUnionPrntDescrEncoder.Factory);
}
