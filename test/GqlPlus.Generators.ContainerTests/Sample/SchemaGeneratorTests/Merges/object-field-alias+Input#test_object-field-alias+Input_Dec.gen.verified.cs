//HintName: test_object-field-alias+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

internal class testObjFieldAliasInpDecoder
{
  public ItestFldObjFieldAliasInp Field { get; set; }
}

internal class testFldObjFieldAliasInpDecoder
{
}

internal static class test_object_field_alias_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_alias_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldAliasInpObject>(_ => new testObjFieldAliasInpDecoder())
      .AddDecoder<ItestFldObjFieldAliasInpObject>(_ => new testFldObjFieldAliasInpDecoder());
}
