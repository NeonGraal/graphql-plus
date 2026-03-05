//HintName: test_parent-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public interface ItestPrntDescrDual
  : ItestRefPrntDescrDual
{
  ItestPrntDescrDualObject? As_PrntDescrDual { get; }
}

public interface ItestPrntDescrDualObject
  : ItestRefPrntDescrDualObject
{
}

public interface ItestRefPrntDescrDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestRefPrntDescrDualObject? As_RefPrntDescrDual { get; }
}

public interface ItestRefPrntDescrDualObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
