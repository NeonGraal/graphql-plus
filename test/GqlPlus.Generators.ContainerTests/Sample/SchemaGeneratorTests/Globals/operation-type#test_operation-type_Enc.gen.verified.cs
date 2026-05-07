//HintName: test_operation-type_Enc.gen.cs
// Generated from {CurrentDirectory}operation-type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_type;

internal class testCatOprTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprTypeObject>
{
  private readonly IEncoder<ItestAddrOprType> _itestAddrOprType = encoders.EncoderFor<ItestAddrOprType>();
  public Structured Encode(ItestCatOprTypeObject input)
    => Structured.Empty()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprType);

  internal static testCatOprTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprTypeEncoder : IEncoder<ItestAddrOprTypeObject>
{
  public Structured Encode(ItestAddrOprTypeObject input)
    => Structured.Empty()
      .Add("street", input.Street.Encode())
      .Add("city", input.City.Encode())
      .Add("country", input.Country.Encode());

  internal static testAddrOprTypeEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_typeEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_typeEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprTypeObject>(testCatOprTypeEncoder.Factory)
      .AddEncoder<ItestAddrOprTypeObject>(testAddrOprTypeEncoder.Factory);
}
