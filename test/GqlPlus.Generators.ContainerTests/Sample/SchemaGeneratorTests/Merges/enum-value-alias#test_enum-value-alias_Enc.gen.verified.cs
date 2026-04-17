//HintName: test_enum-value-alias_Enc.gen.cs
// Generated from {CurrentDirectory}enum-value-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_value_alias;

internal class testEnumValueAliasEncoder : IEncoder<testEnumValueAlias>
{
  public Structured Encode(testEnumValueAlias input)
    => new(input.ToString(), "_EnumValueAlias");

  internal static testEnumValueAliasEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_enum_value_aliasEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_value_aliasEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumValueAlias>(testEnumValueAliasEncoder.Factory);
}
