//HintName: test_parent-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public interface ItestPrntDualDual
  : ItestRefPrntDualDual
{
  ItestPrntDualDualObject? As_PrntDualDual { get; }
}

public interface ItestPrntDualDualObject
  : ItestRefPrntDualDualObject
{
}

public interface ItestRefPrntDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDualDualObject? As_RefPrntDualDual { get; }
}

public interface ItestRefPrntDualDualObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}
