//HintName: test_constraint-field-dual+Dual_Impl.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public class testCnstFieldDualDual
  : testRefCnstFieldDualDual
  , ItestCnstFieldDualDual
{
}

public class testRefCnstFieldDualDual<Tref>
  : ItestRefCnstFieldDualDual<Tref>
{
  public Tref Field { get; set; }
}

public class testPrntCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  public ItestString AsString { get; set; }
}

public class testAltCnstFieldDualDual
  : testPrntCnstFieldDualDual
  , ItestAltCnstFieldDualDual
{
  public ItestNumber Alt { get; set; }
}
