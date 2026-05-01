//HintName: test_alt-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

internal class testAltDualInpDecoder : IDecoder<ItestAltDualInpObject>
{

  public IMessages Decode(IValue input, out ItestAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualAltDualInpDecoder : IDecoder<ItestObjDualAltDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestObjDualAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjDualAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDualInpObject>(testAltDualInpDecoder.Factory)
      .AddDecoder<ItestObjDualAltDualInpObject>(testObjDualAltDualInpDecoder.Factory);
}
