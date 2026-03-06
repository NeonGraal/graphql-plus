//HintName: test_operation-type_Intf.gen.cs
// Generated from {CurrentDirectory}operation-type.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_type;

public interface ItestCatOprType
  : IGqlpModelImplementationBase
{
  ItestCatOprTypeObject? As_CatOprType { get; }
}

public interface ItestCatOprTypeObject
  : IGqlpModelImplementationBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprType Address { get; }
}

public interface ItestAddrOprType
  : IGqlpModelImplementationBase
{
  ItestAddrOprTypeObject? As_AddrOprType { get; }
}

public interface ItestAddrOprTypeObject
  : IGqlpModelImplementationBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
