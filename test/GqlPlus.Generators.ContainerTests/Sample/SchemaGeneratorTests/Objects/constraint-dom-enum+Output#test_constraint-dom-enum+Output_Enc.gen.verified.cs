//HintName: test_constraint-dom-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

internal class testCnstDomEnumOutpEncoder : IEncoder<ItestCnstDomEnumOutpObject>
{
  public Structured Encode(ItestCnstDomEnumOutpObject input)
    => Structured.Empty();

  internal static testCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstDomEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumOutpEncoder : IEncoder<testEnumCnstDomEnumOutp>
{
  public Structured Encode(testEnumCnstDomEnumOutp input)
    => new(input.ToString(), "_EnumCnstDomEnumOutp");

  internal static testEnumCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpEncoder : IEncoder<ItestJustCnstDomEnumOutp>
{
  public Structured Encode(ItestJustCnstDomEnumOutp input)
    => new((decimal?)input.Value);

  internal static testJustCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_dom_enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_dom_enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstDomEnumOutpObject>(testCnstDomEnumOutpEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumOutp>(testEnumCnstDomEnumOutpEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumOutp>(testJustCnstDomEnumOutpEncoder.Factory);
}
