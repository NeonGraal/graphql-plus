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
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal static class test_union_aliasEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_union_aliasEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestUnionAlias>(r => new testUnionAliasEncoder(r));
}
