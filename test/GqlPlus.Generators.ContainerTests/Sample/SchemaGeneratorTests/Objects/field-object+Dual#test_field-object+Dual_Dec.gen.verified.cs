//HintName: test_field-object+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

internal class testFieldObjDualDecoder : NullDecoder<ItestFieldObjDualObject>
{
  public ItestFldFieldObjDual Field { get; set; } = default!;

  internal static testFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldObjDualDecoder : NullDecoder<ItestFldFieldObjDualObject>
{
  public decimal Field { get; set; } = default!;

  internal static testFldFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_object_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_object_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldObjDualObject>(testFieldObjDualDecoder.Factory)
      .AddDecoder<ItestFldFieldObjDualObject>(testFldFieldObjDualDecoder.Factory);
}
