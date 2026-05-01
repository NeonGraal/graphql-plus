//HintName: test_alt-mod-Boolean+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

internal class testAltModBoolInpDecoder : IDecoder<ItestAltModBoolInpObject>
{

  public IMessages Decode(IValue input, out ItestAltModBoolInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltModBoolInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltModBoolInpDecoder : IDecoder<ItestAltAltModBoolInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltModBoolInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltModBoolInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_mod_Boolean_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_mod_Boolean_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltModBoolInpObject>(testAltModBoolInpDecoder.Factory)
      .AddDecoder<ItestAltAltModBoolInpObject>(testAltAltModBoolInpDecoder.Factory);
}
