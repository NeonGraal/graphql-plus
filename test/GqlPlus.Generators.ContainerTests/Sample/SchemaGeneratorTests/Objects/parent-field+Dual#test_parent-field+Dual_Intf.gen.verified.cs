//HintName: test_parent-field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public interface ItestPrntFieldDual
  : ItestRefPrntFieldDual
{
  ItestPrntFieldDualObject AsPrntFieldDual { get; }
}

public interface ItestPrntFieldDualObject
  : ItestRefPrntFieldDualObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestRefPrntFieldDualObject AsRefPrntFieldDual { get; }
}

public interface ItestRefPrntFieldDualObject
{
  decimal Parent { get; }
}
