//HintName: test_object+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_Output;

internal class testObjOutpEncoder : IEncoder<ItestObjOutpObject>
{
  public Structured Encode(ItestObjOutpObject input)
    => Structured.Empty();
}

internal static class test_object_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjOutpObject>(_ => new testObjOutpEncoder());
}
