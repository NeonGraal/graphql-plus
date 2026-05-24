//HintName: test_operation-selection-frag_Intf.gen.cs
// Generated from {CurrentDirectory}operation-selection-frag.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_frag;

public interface ItestCatOprSlctFrag
  : IGqlpInterfaceBase
{
  ItestCatOprSlctFragObject? As_CatOprSlctFrag { get; }
}

public interface ItestCatOprSlctFragObject
  : IGqlpInterfaceBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprSlctFrag Address { get; }
}

public interface ItestAddrOprSlctFrag
  : IGqlpInterfaceBase
{
  ItestAddrOprSlctFragObject? As_AddrOprSlctFrag { get; }
}

public interface ItestAddrOprSlctFragObject
  : IGqlpInterfaceBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
