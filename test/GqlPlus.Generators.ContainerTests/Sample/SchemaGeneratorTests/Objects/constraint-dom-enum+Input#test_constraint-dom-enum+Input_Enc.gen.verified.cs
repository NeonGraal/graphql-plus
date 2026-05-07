//HintName: test_constraint-dom-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

internal class testCnstDomEnumInpEncoder : IEncoder<ItestCnstDomEnumInpObject>
{
  public Structured Encode(ItestCnstDomEnumInpObject input)
    => Structured.Empty();

  internal static testCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstDomEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumInpEncoder : IEncoder<testEnumCnstDomEnumInp>
{
  public Structured Encode(testEnumCnstDomEnumInp input)
    => input.EncodeEnum("EnumCnstDomEnumInp");

  internal static testEnumCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumInpEncoder : IEncoder<ItestJustCnstDomEnumInp>
{
  public Structured Encode(ItestJustCnstDomEnumInp input)
    => input.Value?.EncodeEnum("testEnumCnstDomEnumInp")!;

  internal static testJustCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_dom_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_dom_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstDomEnumInpObject>(testCnstDomEnumInpEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumInp>(testEnumCnstDomEnumInpEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumInp>(testJustCnstDomEnumInpEncoder.Factory);
}
