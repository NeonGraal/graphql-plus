//HintName: test_constraint-dom-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

internal class testEnumCnstDomEnumInpEncoder : IEncoder<testEnumCnstDomEnumInp>
{
  public Structured Encode(testEnumCnstDomEnumInp input)
    => new(input.ToString(), "_EnumCnstDomEnumInp");

  internal static testEnumCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumInpEncoder : IEncoder<ItestJustCnstDomEnumInp>
{
  public Structured Encode(ItestJustCnstDomEnumInp input)
    => new((decimal?)input.Value);

  internal static testJustCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_dom_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_dom_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumCnstDomEnumInp>(testEnumCnstDomEnumInpEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumInp>(testJustCnstDomEnumInpEncoder.Factory);
}
