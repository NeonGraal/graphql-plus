//HintName: test_constraint-field-dual+Dual_Impl.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public class testCnstFieldDualDual
  : testRefCnstFieldDualDual<ItestAltCnstFieldDualDual>
  , ItestCnstFieldDualDual
{
}

public class testRefCnstFieldDualDual<TRef>
  : ItestRefCnstFieldDualDual<TRef>
{
  public TRef Field { get; set; }
}

public class testPrntCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
}

public class testAltCnstFieldDualDual
  : testPrntCnstFieldDualDual
  , ItestAltCnstFieldDualDual
{
  public decimal Alt { get; set; }
}
