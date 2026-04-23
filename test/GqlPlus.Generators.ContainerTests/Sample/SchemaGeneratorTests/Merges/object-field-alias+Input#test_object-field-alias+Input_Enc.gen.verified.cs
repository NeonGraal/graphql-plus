//HintName: test_object-field-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

internal class testObjFieldAliasInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasInpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasInp> _itestFldObjFieldAliasInp = encoders.EncoderFor<ItestFldObjFieldAliasInp>();
  public Structured Encode(ItestObjFieldAliasInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasInp);

  internal static testObjFieldAliasInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasInpEncoder : IEncoder<ItestFldObjFieldAliasInpObject>
{
  public Structured Encode(ItestFldObjFieldAliasInpObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_alias_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_alias_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldAliasInpObject>(testObjFieldAliasInpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasInpObject>(testFldObjFieldAliasInpEncoder.Factory);
}
