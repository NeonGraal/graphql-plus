//HintName: test_object-field-alias+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

internal class testObjFieldAliasDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasDualObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasDual> _itestFldObjFieldAliasDual = encoders.EncoderFor<ItestFldObjFieldAliasDual>();
  public Structured Encode(ItestObjFieldAliasDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasDual);

  internal static testObjFieldAliasDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasDualEncoder : IEncoder<ItestFldObjFieldAliasDualObject>
{
  public Structured Encode(ItestFldObjFieldAliasDualObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_alias_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_alias_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldAliasDualObject>(testObjFieldAliasDualEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasDualObject>(testFldObjFieldAliasDualEncoder.Factory);
}
