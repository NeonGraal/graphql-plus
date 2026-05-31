//HintName: test_operation-selection-inline_Intf.gen.cs
// Generated from {CurrentDirectory}operation-selection-inline.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_inline;

public interface ItestCatOprSlctInln
  : IGqlpInterfaceBase
{
  ItestCatOprSlctInlnObject? As_CatOprSlctInln { get; }
}

public interface ItestCatOprSlctInlnObject
  : IGqlpInterfaceBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprSlctInln Address { get; }
}

public interface ItestAddrOprSlctInln
  : IGqlpInterfaceBase
{
  ItestFullOprSlctInln? AsFullOprSlctInln { get; }
  string? AsString { get; }
  ItestAddrOprSlctInlnObject? As_AddrOprSlctInln { get; }
}

public interface ItestAddrOprSlctInlnObject
  : IGqlpInterfaceBase
{
}

public interface ItestFullOprSlctInln
  : IGqlpInterfaceBase
{
  ItestFullOprSlctInlnObject? As_FullOprSlctInln { get; }
}

public interface ItestFullOprSlctInlnObject
  : IGqlpInterfaceBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
