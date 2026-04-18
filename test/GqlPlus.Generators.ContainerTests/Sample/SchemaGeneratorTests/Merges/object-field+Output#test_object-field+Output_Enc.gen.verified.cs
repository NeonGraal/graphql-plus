//HintName: test_object-field+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Output;

internal class testObjFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldOutp> _itestFldObjFieldOutp = encoders.EncoderFor<ItestFldObjFieldOutp>();
  public Structured Encode(ItestObjFieldOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldOutp);

  internal static testObjFieldOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldOutpEncoder : IEncoder<ItestFldObjFieldOutpObject>
{
  public Structured Encode(ItestFldObjFieldOutpObject input)
    => Structured.Empty();

  internal static testFldObjFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldOutpObject>(testObjFieldOutpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldOutpObject>(testFldObjFieldOutpEncoder.Factory);
}
