//HintName: test_union-descr_Enc.gen.cs
// Generated from {CurrentDirectory}union-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_descr;

internal class testUnionDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_union_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_union_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestUnionDescr>(testUnionDescrEncoder.Factory);
}
