//HintName: test_enum-parent-alias_Enc.gen.cs
// Generated from {CurrentDirectory}enum-parent-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_alias;

internal class testEnumPrntAliasEncoder : IEncoder<testEnumPrntAlias>
{
  public Structured Encode(testEnumPrntAlias input)
    => new(input.ToString(), "_EnumPrntAlias");
}

internal class testPrntEnumPrntAliasEncoder : IEncoder<testPrntEnumPrntAlias>
{
  public Structured Encode(testPrntEnumPrntAlias input)
    => new(input.ToString(), "_PrntEnumPrntAlias");
}
