//HintName: test_operation-type_Enc.gen.cs
// Generated from {CurrentDirectory}operation-type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_type;

internal class testCatOprTypeEncoder
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprType Address { get; set; }
}

internal class testAddrOprTypeEncoder
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }
}
