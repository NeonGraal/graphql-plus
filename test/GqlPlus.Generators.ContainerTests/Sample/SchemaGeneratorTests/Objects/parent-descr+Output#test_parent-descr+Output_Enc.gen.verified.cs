//HintName: test_parent-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

internal class testPrntDescrOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrOutpObject>
{
  private readonly IEncoder<ItestRefPrntDescrOutpObject> _itestRefPrntDescrOutp = encoders.EncoderFor<ItestRefPrntDescrOutpObject>();
  public Structured Encode(ItestPrntDescrOutpObject input)
    => _itestRefPrntDescrOutp.Encode(input);

  internal static testPrntDescrOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDescrOutpEncoder : IEncoder<ItestRefPrntDescrOutpObject>
{
  public Structured Encode(ItestRefPrntDescrOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

  internal static testRefPrntDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_descr_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_descr_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntDescrOutpObject>(testPrntDescrOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntDescrOutpObject>(testRefPrntDescrOutpEncoder.Factory);
}
