//HintName: test_object-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Output;

internal class testObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefObjPrntOutpObject> _itestRefObjPrntOutp = encoders.EncoderFor<ItestRefObjPrntOutpObject>();
  public Structured Encode(ItestObjPrntOutpObject input)
    => _itestRefObjPrntOutp.Encode(input);
}

internal class testRefObjPrntOutpEncoder : IEncoder<ItestRefObjPrntOutpObject>
{
  public Structured Encode(ItestRefObjPrntOutpObject input)
    => Structured.Empty();
}

internal static class test_object_parent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_parent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjPrntOutpObject>(r => new testObjPrntOutpEncoder(r))
      .AddEncoder<ItestRefObjPrntOutpObject>(_ => new testRefObjPrntOutpEncoder());
}
