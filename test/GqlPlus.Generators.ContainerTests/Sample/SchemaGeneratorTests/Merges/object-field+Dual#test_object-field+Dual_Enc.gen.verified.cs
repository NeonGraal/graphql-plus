//HintName: test_object-field+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

internal class testObjFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldDualObject>
{
  private readonly IEncoder<ItestFldObjFieldDual> _itestFldObjFieldDual = encoders.EncoderFor<ItestFldObjFieldDual>();
  public Structured Encode(ItestObjFieldDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldDual);

  internal static testObjFieldDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldDualEncoder : IEncoder<ItestFldObjFieldDualObject>
{
  public Structured Encode(ItestFldObjFieldDualObject input)
    => Structured.Empty();

  internal static testFldObjFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldDualObject>(testObjFieldDualEncoder.Factory)
      .AddEncoder<ItestFldObjFieldDualObject>(testFldObjFieldDualEncoder.Factory);
}
