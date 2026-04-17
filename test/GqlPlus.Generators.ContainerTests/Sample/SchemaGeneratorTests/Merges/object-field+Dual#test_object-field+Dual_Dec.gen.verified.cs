//HintName: test_object-field+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

internal class testObjFieldDualDecoder
{
  public ItestFldObjFieldDual Field { get; set; }

  internal static testObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldDualDecoder
{

  internal static testFldObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_field_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldDualObject>(testObjFieldDualDecoder.Factory)
      .AddDecoder<ItestFldObjFieldDualObject>(testFldObjFieldDualDecoder.Factory);
}
