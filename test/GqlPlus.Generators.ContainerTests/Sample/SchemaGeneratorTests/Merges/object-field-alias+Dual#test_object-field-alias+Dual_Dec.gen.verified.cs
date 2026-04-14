//HintName: test_object-field-alias+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

internal class testObjFieldAliasDualDecoder
{
  public ItestFldObjFieldAliasDual Field { get; set; }
}

internal class testFldObjFieldAliasDualDecoder
{
}

internal static class test_object_field_alias_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_alias_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldAliasDualObject>(r => new testObjFieldAliasDualDecoder(r))
      .AddDecoder<ItestFldObjFieldAliasDualObject>(_ => new testFldObjFieldAliasDualDecoder());
}
