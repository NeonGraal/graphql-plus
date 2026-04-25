//HintName: test_generic-parent-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

internal class testEnumGnrcPrntEnumPrntInpEncoder : IEncoder<testEnumGnrcPrntEnumPrntInp>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntInp input)
    => input.EncodeEnum("EnumGnrcPrntEnumPrntInp");

  internal static testEnumGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntInpEncoder : IEncoder<testParentGnrcPrntEnumPrntInp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntInp input)
    => input.EncodeEnum("ParentGnrcPrntEnumPrntInp");

  internal static testParentGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_enum_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumGnrcPrntEnumPrntInp>(testEnumGnrcPrntEnumPrntInpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumPrntInp>(testParentGnrcPrntEnumPrntInpEncoder.Factory);
}
