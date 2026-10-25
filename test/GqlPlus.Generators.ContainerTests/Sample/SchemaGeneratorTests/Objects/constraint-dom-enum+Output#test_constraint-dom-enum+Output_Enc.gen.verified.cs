//HintName: test_constraint-dom-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

internal class testCnstDomEnumOutpEncoder : IEncoder<ItestCnstDomEnumOutpObject>
{
  public IGqlpValue Encode(ItestCnstDomEnumOutpObject input)
    => new GqlpUnit();

  internal static testCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstDomEnumOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumOutpEncoder : IEncoder<testEnumCnstDomEnumOutp>
{
  public IGqlpValue Encode(testEnumCnstDomEnumOutp input)
    => input.EncodeEnum("EnumCnstDomEnumOutp");

  internal static testEnumCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpEncoder : IEncoder<ItestJustCnstDomEnumOutp>
{
  public IGqlpValue Encode(ItestJustCnstDomEnumOutp input)
    => input.Value?.EncodeEnum("testEnumCnstDomEnumOutp")!;

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
