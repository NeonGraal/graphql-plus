//HintName: test_field-simple+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

internal class testFieldSmplDualDecoder : IDecoder<ItestFieldSmplDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldSmplDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_simple_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_simple_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldSmplDualObject>(testFieldSmplDualDecoder.Factory);
}
