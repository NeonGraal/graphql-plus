//HintName: test_parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

internal class testPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpObject>
{
  private readonly IEncoder<ItestRefPrntOutpObject> _itestRefPrntOutp = encoders.EncoderFor<ItestRefPrntOutpObject>();
  public Structured Encode(ItestPrntOutpObject input)
    => _itestRefPrntOutp.Encode(input);

  internal static testPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntOutpEncoder : IEncoder<ItestRefPrntOutpObject>
{
  public Structured Encode(ItestRefPrntOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

  internal static testRefPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntOutpObject>(testPrntOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntOutpObject>(testRefPrntOutpEncoder.Factory);
}
