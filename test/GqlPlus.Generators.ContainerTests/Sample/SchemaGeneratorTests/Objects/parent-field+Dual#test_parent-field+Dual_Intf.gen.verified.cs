//HintName: test_parent-field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public interface ItestPrntFieldDual
  : ItestRefPrntFieldDual
{
  ItestPrntFieldDualObject? As_PrntFieldDual { get; }
}

public interface ItestPrntFieldDualObject
  : ItestRefPrntFieldDualObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntFieldDualObject? As_RefPrntFieldDual { get; }
}

public interface ItestRefPrntFieldDualObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}
