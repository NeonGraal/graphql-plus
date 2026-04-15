//HintName: test_object-alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Output;

internal class testObjAltOutpEncoder : IEncoder<ItestObjAltOutpObject>
{
  public Structured Encode(ItestObjAltOutpObject input)
    => Structured.Empty();
}

internal class testObjAltOutpTypeEncoder : IEncoder<ItestObjAltOutpTypeObject>
{
  public Structured Encode(ItestObjAltOutpTypeObject input)
    => Structured.Empty();
}

internal static class test_object_alt_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alt_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAltOutpObject>(_ => new testObjAltOutpEncoder())
      .AddEncoder<ItestObjAltOutpTypeObject>(_ => new testObjAltOutpTypeEncoder());
}
