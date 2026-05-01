//HintName: test_object-field-enum-alias+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Input;

internal class testObjFieldEnumAliasInpDecoder : IDecoder<ItestObjFieldEnumAliasInpObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_field_enum_alias_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_enum_alias_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldEnumAliasInpObject>(testObjFieldEnumAliasInpDecoder.Factory);
}
