//HintName: test_object-alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Output;

internal class testObjAltOutpEncoder : IEncoder<ItestObjAltOutpObject>
{
  public IGqlpValue Encode(ItestObjAltOutpObject input)
    => new GqlpUnit();

  internal static testObjAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltOutpTypeEncoder : IEncoder<ItestObjAltOutpTypeObject>
{
  public IGqlpValue Encode(ItestObjAltOutpTypeObject input)
    => new GqlpUnit();

  internal static testObjAltOutpTypeEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_alt_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alt_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAltOutpObject>(testObjAltOutpEncoder.Factory)
      .AddEncoder<ItestObjAltOutpTypeObject>(testObjAltOutpTypeEncoder.Factory);
}
