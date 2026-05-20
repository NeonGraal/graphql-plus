//HintName: test_operation-selection_Intf.gen.cs
// Generated from {CurrentDirectory}operation-selection.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection;

public interface ItestCatOprSelection
  : IGqlpInterfaceBase
{
  ItestCatOprSelectionObject? As_CatOprSelection { get; }
}

public interface ItestCatOprSelectionObject
  : IGqlpInterfaceBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprSelection Address { get; }
}

public interface ItestAddrOprSelection
  : IGqlpInterfaceBase
{
  ItestAddrOprSelectionObject? As_AddrOprSelection { get; }
}

public interface ItestAddrOprSelectionObject
  : IGqlpInterfaceBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
