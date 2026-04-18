//HintName: test_object-alt-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Dual;

internal class testObjAltEnumDualEncoder : IEncoder<ItestObjAltEnumDualObject>
{
  public Structured Encode(ItestObjAltEnumDualObject input)
    => Structured.Empty();

  internal static testObjAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_alt_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alt_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAltEnumDualObject>(testObjAltEnumDualEncoder.Factory);
}
