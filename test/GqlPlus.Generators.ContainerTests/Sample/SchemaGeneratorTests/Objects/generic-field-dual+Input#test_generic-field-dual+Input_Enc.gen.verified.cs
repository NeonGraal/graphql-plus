//HintName: test_generic-field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

internal class testGnrcFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualInpObject>
{
  private readonly Encoder<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>> _itestRefGnrcFieldDualInp = encoders.EncoderFor<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>>();
  public IGqlpValue Encode(ItestGnrcFieldDualInpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualInp);

  internal static testGnrcFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldDualInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldDualInpEncoder : IEncoder<ItestAltGnrcFieldDualInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldDualInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_field_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_field_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcFieldDualInpObject>(testGnrcFieldDualInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualInpObject>(testAltGnrcFieldDualInpEncoder.Factory);
}
