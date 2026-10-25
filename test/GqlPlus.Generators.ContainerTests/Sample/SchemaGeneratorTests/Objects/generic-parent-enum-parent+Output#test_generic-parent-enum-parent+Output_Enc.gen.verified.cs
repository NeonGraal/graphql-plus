//HintName: test_generic-parent-enum-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

internal class testGnrcPrntEnumPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntOutpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>> _itestFieldGnrcPrntEnumPrntOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumPrntOutpObject input)
    => _itestFieldGnrcPrntEnumPrntOutp.Encode(input);

  internal static testGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumPrntOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumPrntOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntOutpEncoder : IEncoder<testEnumGnrcPrntEnumPrntOutp>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumPrntOutp input)
    => input.EncodeEnum("EnumGnrcPrntEnumPrntOutp");

  internal static testEnumGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntOutpEncoder : IEncoder<testParentGnrcPrntEnumPrntOutp>
{
  public IGqlpValue Encode(testParentGnrcPrntEnumPrntOutp input)
    => input.EncodeEnum("ParentGnrcPrntEnumPrntOutp");

  internal static testParentGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_enum_parent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_parent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntEnumPrntOutpObject>(testGnrcPrntEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumPrntOutp>(testEnumGnrcPrntEnumPrntOutpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumPrntOutp>(testParentGnrcPrntEnumPrntOutpEncoder.Factory);
}
