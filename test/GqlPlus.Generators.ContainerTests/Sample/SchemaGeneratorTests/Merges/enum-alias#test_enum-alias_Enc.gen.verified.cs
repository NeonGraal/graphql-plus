//HintName: test_enum-alias_Enc.gen.cs
// Generated from {CurrentDirectory}enum-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_alias;

internal class testEnumAliasEncoder : IEncoder<testEnumAlias>
{
  public Structured Encode(testEnumAlias input)
    => new(input.ToString(), "_EnumAlias");

  internal static testEnumAliasEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_enum_aliasEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_aliasEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumAlias>(testEnumAliasEncoder.Factory);
}
