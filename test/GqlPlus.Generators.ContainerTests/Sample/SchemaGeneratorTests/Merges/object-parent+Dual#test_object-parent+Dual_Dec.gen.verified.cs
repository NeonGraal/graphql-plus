//HintName: test_object-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

internal class testObjPrntDualDecoder : IDecoder<ItestObjPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntDualDecoder : IDecoder<ItestRefObjPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestRefObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjPrntDualObject>(testObjPrntDualDecoder.Factory)
      .AddDecoder<ItestRefObjPrntDualObject>(testRefObjPrntDualDecoder.Factory);
}
