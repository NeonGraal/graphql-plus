//HintName: test_operation-selection-mods_Intf.gen.cs
// Generated from {CurrentDirectory}operation-selection-mods.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_mods;

public interface ItestCatOprSelectionMods
  : IGqlpInterfaceBase
{
  ItestCatOprSelectionModsObject? As_CatOprSelectionMods { get; }
}

public interface ItestCatOprSelectionModsObject
  : IGqlpInterfaceBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprSelectionMods Address { get; }
}

public interface ItestAddrOprSelectionMods
  : IGqlpInterfaceBase
{
  ItestAddrOprSelectionModsObject? As_AddrOprSelectionMods { get; }
}

public interface ItestAddrOprSelectionModsObject
  : IGqlpInterfaceBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
