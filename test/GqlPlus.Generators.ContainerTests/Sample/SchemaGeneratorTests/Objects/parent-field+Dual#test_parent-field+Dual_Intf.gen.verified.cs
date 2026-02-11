//HintName: test_parent-field+Dual_Intf.gen.cs
// Generated from parent-field+Dual.graphql+ for Intf
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
{
  string AsString { get; }
  ItestRefPrntFieldDualObject AsRefPrntFieldDual { get; }
}

public interface ItestRefPrntFieldDualObject
{
  decimal Parent { get; }
}
