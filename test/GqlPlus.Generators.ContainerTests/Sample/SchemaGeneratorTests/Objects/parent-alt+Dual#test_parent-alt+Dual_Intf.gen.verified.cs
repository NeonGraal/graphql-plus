//HintName: test_parent-alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  decimal? AsNumber { get; }
  ItestPrntAltDualObject? As_PrntAltDual { get; }
}

public interface ItestPrntAltDualObject
  : ItestRefPrntAltDualObject
{
}

public interface ItestRefPrntAltDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntAltDualObject? As_RefPrntAltDual { get; }
}

public interface ItestRefPrntAltDualObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}
