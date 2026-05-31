//HintName: test_operation-selection_Intf.gen.cs
// Generated from {CurrentDirectory}operation-selection.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection;

public interface ItestCatOprSlct
  : IGqlpInterfaceBase
{
  ItestCatOprSlctObject? As_CatOprSlct { get; }
}

public interface ItestCatOprSlctObject
  : IGqlpInterfaceBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprSlct Address { get; }
}

public interface ItestAddrOprSlct
  : IGqlpInterfaceBase
{
  ItestAddrOprSlctObject? As_AddrOprSlct { get; }
}

public interface ItestAddrOprSlctObject
  : IGqlpInterfaceBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
