//HintName: test_object-field-type-alias+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Input;

internal class testObjFieldTypeAliasInpDecoder : IDecoder<ItestObjFieldTypeAliasInpObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldTypeAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldTypeAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_field_type_alias_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_type_alias_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldTypeAliasInpObject>(testObjFieldTypeAliasInpDecoder.Factory);
}
