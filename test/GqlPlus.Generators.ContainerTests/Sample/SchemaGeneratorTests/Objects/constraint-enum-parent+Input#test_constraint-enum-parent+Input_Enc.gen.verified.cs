//HintName: test_constraint-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

internal class testEnumCnstEnumPrntInpEncoder : IEncoder<testEnumCnstEnumPrntInp>
{
  public Structured Encode(testEnumCnstEnumPrntInp input)
    => input.EncodeEnum("EnumCnstEnumPrntInp");

  internal static testEnumCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntInpEncoder : IEncoder<testParentCnstEnumPrntInp>
{
  public Structured Encode(testParentCnstEnumPrntInp input)
    => input.EncodeEnum("ParentCnstEnumPrntInp");

  internal static testParentCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_enum_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_enum_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumCnstEnumPrntInp>(testEnumCnstEnumPrntInpEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntInp>(testParentCnstEnumPrntInpEncoder.Factory);
}
