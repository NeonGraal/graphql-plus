//HintName: test_object-alt+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Dual;

internal class testObjAltDualDecoder : IDecoder<ItestObjAltDualObject>
{

  public IMessages Decode(IValue input, out ItestObjAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualTypeDecoder : IDecoder<ItestObjAltDualTypeObject>
{

  public IMessages Decode(IValue input, out ItestObjAltDualTypeObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltDualTypeDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_alt_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alt_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAltDualObject>(testObjAltDualDecoder.Factory)
      .AddDecoder<ItestObjAltDualTypeObject>(testObjAltDualTypeDecoder.Factory);
}
