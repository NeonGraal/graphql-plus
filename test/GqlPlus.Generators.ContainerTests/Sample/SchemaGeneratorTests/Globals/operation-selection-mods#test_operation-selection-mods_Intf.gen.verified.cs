//HintName: test_operation-selection-mods_Intf.gen.cs
// Generated from {CurrentDirectory}operation-selection-mods.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_mods;

public interface ItestCatOprSlctMods
  : IGqlpInterfaceBase
{
  ItestCatOprSlctModsObject? As_CatOprSlctMods { get; }
}

public interface ItestCatOprSlctModsObject
  : IGqlpInterfaceBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprSlctMods Address { get; }
}

public interface ItestAddrOprSlctMods
  : IGqlpInterfaceBase
{
  ItestAddrOprSlctModsObject? As_AddrOprSlctMods { get; }
}

public interface ItestAddrOprSlctModsObject
  : IGqlpInterfaceBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
