//HintName: test_object-field-alias+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Output;

internal class testObjFieldAliasOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasOutp> _itestFldObjFieldAliasOutp = encoders.EncoderFor<ItestFldObjFieldAliasOutp>();
  public Structured Encode(ItestObjFieldAliasOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasOutp);

  internal static testObjFieldAliasOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasOutpEncoder : IEncoder<ItestFldObjFieldAliasOutpObject>
{
  public Structured Encode(ItestFldObjFieldAliasOutpObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_alias_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_alias_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldAliasOutpObject>(testObjFieldAliasOutpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasOutpObject>(testFldObjFieldAliasOutpEncoder.Factory);
}
