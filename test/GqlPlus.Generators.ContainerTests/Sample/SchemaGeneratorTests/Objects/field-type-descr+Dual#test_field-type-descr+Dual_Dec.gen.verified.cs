//HintName: test_field-type-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Dual;

internal class testFieldTypeDescrDualDecoder : IDecoder<ItestFieldTypeDescrDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldTypeDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldTypeDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_type_descr_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_type_descr_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldTypeDescrDualObject>(testFieldTypeDescrDualDecoder.Factory);
}
