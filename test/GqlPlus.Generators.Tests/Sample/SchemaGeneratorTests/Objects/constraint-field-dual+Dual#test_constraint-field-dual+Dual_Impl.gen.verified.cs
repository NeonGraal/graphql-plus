//HintName: test_constraint-field-dual+Dual_Impl.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public class testCnstFieldDualDual
  : testRefCnstFieldDualDual
  , ItestCnstFieldDualDual
{
  public testCnstFieldDualDual CnstFieldDualDual { get; set; }
}

public class testRefCnstFieldDualDual<Tref>
  : ItestRefCnstFieldDualDual<Tref>
{
  public Tref field { get; set; }
  public testRefCnstFieldDualDual RefCnstFieldDualDual { get; set; }
}

public class testPrntCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  public testString AsString { get; set; }
  public testPrntCnstFieldDualDual PrntCnstFieldDualDual { get; set; }
}

public class testAltCnstFieldDualDual
  : testPrntCnstFieldDualDual
  , ItestAltCnstFieldDualDual
{
  public testNumber alt { get; set; }
  public testAltCnstFieldDualDual AltCnstFieldDualDual { get; set; }
}
