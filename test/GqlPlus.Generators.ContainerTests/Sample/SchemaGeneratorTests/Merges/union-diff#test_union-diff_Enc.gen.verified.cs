//HintName: test_union-diff_Enc.gen.cs
// Generated from {CurrentDirectory}union-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_diff;

internal class testUnionDiffEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDiff>
{
  private readonly DeferOne<IEncoder<bool>> _boolean = encoders.EncoderFor<bool>();
  private readonly DeferOne<IEncoder<decimal>> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDiff input)
    => input.HasA<bool>() ? _boolean.I.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.I.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionDiffEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_union_diffEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_union_diffEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestUnionDiff>(testUnionDiffEncoder.Factory);
}
