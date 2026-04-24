//HintName: test_constraint-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

internal class testEnumCnstEnumInpEncoder : IEncoder<testEnumCnstEnumInp>
{
  public Structured Encode(testEnumCnstEnumInp input)
    => input.EncodeEnum("EnumCnstEnumInp");

  internal static testEnumCnstEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumCnstEnumInp>(testEnumCnstEnumInpEncoder.Factory);
}
