//HintName: test_operation-selection-spread_Intf.gen.cs
// Generated from {CurrentDirectory}operation-selection-spread.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_spread;

public interface ItestCatOprSlctSprd
  : IGqlpInterfaceBase
{
  ItestCatOprSlctSprdObject? As_CatOprSlctSprd { get; }
}

public interface ItestCatOprSlctSprdObject
  : IGqlpInterfaceBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprSlctSprd Address { get; }
}

public interface ItestAddrOprSlctSprd
  : IGqlpInterfaceBase
{
  ItestAddrOprSlctSprdObject? As_AddrOprSlctSprd { get; }
}

public interface ItestAddrOprSlctSprdObject
  : IGqlpInterfaceBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
