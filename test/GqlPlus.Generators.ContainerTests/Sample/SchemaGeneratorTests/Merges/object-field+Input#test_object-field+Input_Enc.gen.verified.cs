//HintName: test_object-field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Input;

internal class testObjFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldInpObject>
{
  private readonly IEncoder<ItestFldObjFieldInp> _itestFldObjFieldInp = encoders.EncoderFor<ItestFldObjFieldInp>();
  public Structured Encode(ItestObjFieldInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldInp);

  internal static testObjFieldInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldInpEncoder : IEncoder<ItestFldObjFieldInpObject>
{
  public Structured Encode(ItestFldObjFieldInpObject input)
    => Structured.Empty();

  internal static testFldObjFieldInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldInpObject>(testObjFieldInpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldInpObject>(testFldObjFieldInpEncoder.Factory);
}
