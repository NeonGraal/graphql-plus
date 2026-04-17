//HintName: test_generic-field-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

internal class testGnrcFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualOutpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>> _itestRefGnrcFieldDualOutp = encoders.EncoderFor<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>>();
  public Structured Encode(ItestGnrcFieldDualOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualOutp);

  internal static testGnrcFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldDualOutpEncoder : IEncoder<ItestAltGnrcFieldDualOutpObject>
{
  public Structured Encode(ItestAltGnrcFieldDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcFieldDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_field_dual_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_field_dual_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcFieldDualOutpObject>(testGnrcFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualOutpObject>(testAltGnrcFieldDualOutpEncoder.Factory);
}
