//HintName: test_generic-parent-enum-child+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

internal class testGnrcPrntEnumChildOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>> _itestFieldGnrcPrntEnumChildOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>>();
  public Structured Encode(ItestGnrcPrntEnumChildOutpObject input)
    => _itestFieldGnrcPrntEnumChildOutp.Encode(input);

  internal static testGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumChildOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumChildOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildOutpEncoder : IEncoder<testEnumGnrcPrntEnumChildOutp>
{
  public Structured Encode(testEnumGnrcPrntEnumChildOutp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumChildOutp");

  internal static testEnumGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildOutpEncoder : IEncoder<testParentGnrcPrntEnumChildOutp>
{
  public Structured Encode(testParentGnrcPrntEnumChildOutp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildOutp");

  internal static testParentGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_enum_child_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_child_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntEnumChildOutpObject>(testGnrcPrntEnumChildOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumChildOutp>(testEnumGnrcPrntEnumChildOutpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumChildOutp>(testParentGnrcPrntEnumChildOutpEncoder.Factory);
}
