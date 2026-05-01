//HintName: test_alt-mod-Boolean+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

internal class testAltModBoolDualDecoder : IDecoder<ItestAltModBoolDualObject>
{

  public IMessages Decode(IValue input, out ItestAltModBoolDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltModBoolDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltModBoolDualDecoder : IDecoder<ItestAltAltModBoolDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltModBoolDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltModBoolDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_mod_Boolean_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_mod_Boolean_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltModBoolDualObject>(testAltModBoolDualDecoder.Factory)
      .AddDecoder<ItestAltAltModBoolDualObject>(testAltAltModBoolDualDecoder.Factory);
}
