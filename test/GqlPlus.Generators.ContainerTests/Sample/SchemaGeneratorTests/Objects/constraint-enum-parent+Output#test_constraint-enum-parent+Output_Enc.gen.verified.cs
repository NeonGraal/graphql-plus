//HintName: test_constraint-enum-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

internal class testCnstEnumPrntOutpEncoder : IEncoder<ItestCnstEnumPrntOutpObject>
{
  public Structured Encode(ItestCnstEnumPrntOutpObject input)
    => Structured.Empty();

  internal static testCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumPrntOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumPrntOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntOutpEncoder : IEncoder<testEnumCnstEnumPrntOutp>
{
  public Structured Encode(testEnumCnstEnumPrntOutp input)
    => input.EncodeEnum("EnumCnstEnumPrntOutp");

  internal static testEnumCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntOutpEncoder : IEncoder<testParentCnstEnumPrntOutp>
{
  public Structured Encode(testParentCnstEnumPrntOutp input)
    => input.EncodeEnum("ParentCnstEnumPrntOutp");

  internal static testParentCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_enum_parent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_enum_parent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstEnumPrntOutpObject>(testCnstEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumCnstEnumPrntOutp>(testEnumCnstEnumPrntOutpEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntOutp>(testParentCnstEnumPrntOutpEncoder.Factory);
}
