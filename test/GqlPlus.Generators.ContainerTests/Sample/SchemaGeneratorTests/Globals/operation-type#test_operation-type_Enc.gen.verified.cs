//HintName: test_operation-type_Enc.gen.cs
// Generated from {CurrentDirectory}operation-type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
      .Add("first", input.First)
      .Add("last", input.Last)
      .AddEncoded("address", input.Address, _itestAddrOprType);
}

internal class testAddrOprTypeEncoder : IEncoder<ItestAddrOprTypeObject>
{
  public Structured Encode(ItestAddrOprTypeObject input)
    => Structured.Empty()
      .Add("street", input.Street)
      .Add("city", input.City)
      .Add("country", input.Country);
}

internal static class test_operation_typeEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_typeEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprTypeObject>(r => new testCatOprTypeEncoder(r))
      .AddEncoder<ItestAddrOprTypeObject>(_ => new testAddrOprTypeEncoder());
}
