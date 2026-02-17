//HintName: test_parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public interface ItestPrntDual
  : ItestRefPrntDual
{
  ItestPrntDualObject? As_PrntDual { get; }
}

public interface ItestPrntDualObject
  : ItestRefPrntDualObject
{
}

public interface ItestRefPrntDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestRefPrntDualObject? As_RefPrntDual { get; }
}

public interface ItestRefPrntDualObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
