//HintName: test_enum-alias_Enc.gen.cs
// Generated from {CurrentDirectory}enum-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_alias;

internal class testEnumAliasEncoder : IEncoder<testEnumAlias>
{
  public Structured Encode(testEnumAlias input)
    => new(input.ToString(), "_EnumAlias");
}
