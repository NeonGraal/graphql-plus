//HintName: test_operation-type_Intf.gen.cs
// Generated from {CurrentDirectory}operation-type.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_type;

public interface ItestCatOprType
  : IGqlpInterfaceBase
{
  ItestCatOprTypeObject? As_CatOprType { get; }
}

public interface ItestCatOprTypeObject
  : IGqlpInterfaceBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprType Address { get; }
}

public interface ItestAddrOprType
  : IGqlpInterfaceBase
{
  ItestAddrOprTypeObject? As_AddrOprType { get; }
}

public interface ItestAddrOprTypeObject
  : IGqlpInterfaceBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
