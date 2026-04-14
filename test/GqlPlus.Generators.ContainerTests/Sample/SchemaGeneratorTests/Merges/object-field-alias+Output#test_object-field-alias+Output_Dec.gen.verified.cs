//HintName: test_object-field-alias+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Output;

internal class testObjFieldAliasOutpDecoder
{
  public ItestFldObjFieldAliasOutp Field { get; set; }
}

internal class testFldObjFieldAliasOutpDecoder
{
}

internal static class test_object_field_alias_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_alias_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldAliasOutpObject>(r => new testObjFieldAliasOutpDecoder(r))
      .AddDecoder<ItestFldObjFieldAliasOutpObject>(_ => new testFldObjFieldAliasOutpDecoder());
}
