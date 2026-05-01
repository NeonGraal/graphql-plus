//HintName: test_field-mod-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

internal class testFieldModParamDualDecoder<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamDual>? Field { get; set; }
}

internal class testFldFieldModParamDualDecoder : IDecoder<ItestFldFieldModParamDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldModParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldModParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_mod_param_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_mod_param_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldFieldModParamDualObject>(testFldFieldModParamDualDecoder.Factory);
}
