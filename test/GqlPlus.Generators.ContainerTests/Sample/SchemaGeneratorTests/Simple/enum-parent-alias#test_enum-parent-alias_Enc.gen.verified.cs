//HintName: test_enum-parent-alias_Enc.gen.cs
// Generated from {CurrentDirectory}enum-parent-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_alias;

internal class testEnumPrntAliasEncoder : IEncoder<testEnumPrntAlias>
{
  public Structured Encode(testEnumPrntAlias input)
    => new(input.ToString(), "_EnumPrntAlias");

  internal static testEnumPrntAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntAliasEncoder : IEncoder<testPrntEnumPrntAlias>
{
  public Structured Encode(testPrntEnumPrntAlias input)
    => new(input.ToString(), "_PrntEnumPrntAlias");

  internal static testPrntEnumPrntAliasEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_enum_parent_aliasEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_parent_aliasEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumPrntAlias>(testEnumPrntAliasEncoder.Factory)
      .AddEncoder<testPrntEnumPrntAlias>(testPrntEnumPrntAliasEncoder.Factory);
}
