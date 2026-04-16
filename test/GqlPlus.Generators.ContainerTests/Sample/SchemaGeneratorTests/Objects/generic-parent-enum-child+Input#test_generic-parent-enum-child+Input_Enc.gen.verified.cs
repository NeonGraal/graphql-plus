//HintName: test_generic-parent-enum-child+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

internal class testEnumGnrcPrntEnumChildInpEncoder : IEncoder<testEnumGnrcPrntEnumChildInp>
{
  public Structured Encode(testEnumGnrcPrntEnumChildInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumChildInp");

  internal static testEnumGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildInpEncoder : IEncoder<testParentGnrcPrntEnumChildInp>
{
  public Structured Encode(testParentGnrcPrntEnumChildInp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildInp");

  internal static testParentGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_enum_child_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_child_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumGnrcPrntEnumChildInp>(testEnumGnrcPrntEnumChildInpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumChildInp>(testParentGnrcPrntEnumChildInpEncoder.Factory);
}
