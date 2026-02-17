//HintName: test_parent-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public interface ItestPrntDualDual
  : ItestRefPrntDualDual
{
  ItestPrntDualDualObject AsPrntDualDual { get; }
}

public interface ItestPrntDualDualObject
  : ItestRefPrntDualDualObject
{
}

public interface ItestRefPrntDualDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestRefPrntDualDualObject AsRefPrntDualDual { get; }
}

public interface ItestRefPrntDualDualObject
{
  decimal Parent { get; }
}
