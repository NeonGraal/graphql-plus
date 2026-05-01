//HintName: test_object-alt-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Dual;

internal class testObjAltEnumDualDecoder : IDecoder<ItestObjAltEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestObjAltEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_alt_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alt_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAltEnumDualObject>(testObjAltEnumDualDecoder.Factory);
}
