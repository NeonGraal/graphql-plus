//HintName: test_object-alias+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alias_Dual;

internal class testObjAliasDualDecoder
{

  internal static testObjAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_alias_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alias_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAliasDualObject>(testObjAliasDualDecoder.Factory);
}
