//HintName: test_parent-alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

internal class testPrntAltOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltOutpObject>
{
  private readonly IEncoder<ItestRefPrntAltOutpObject> _itestRefPrntAltOutp = encoders.EncoderFor<ItestRefPrntAltOutpObject>();
  public Structured Encode(ItestPrntAltOutpObject input)
    => _itestRefPrntAltOutp.Encode(input);

  internal static testPrntAltOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltOutpEncoder : IEncoder<ItestRefPrntAltOutpObject>
{
  public Structured Encode(ItestRefPrntAltOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_alt_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_alt_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntAltOutpObject>(testPrntAltOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntAltOutpObject>(testRefPrntAltOutpEncoder.Factory);
}
