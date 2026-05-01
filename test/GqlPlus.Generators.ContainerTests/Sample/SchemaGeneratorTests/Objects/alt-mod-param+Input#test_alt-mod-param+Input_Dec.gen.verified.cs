//HintName: test_alt-mod-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

internal class testAltModParamInpDecoder<TMod>
{
}

internal class testAltAltModParamInpDecoder : IDecoder<ItestAltAltModParamInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltModParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltModParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_mod_param_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_mod_param_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltAltModParamInpObject>(testAltAltModParamInpDecoder.Factory);
}
