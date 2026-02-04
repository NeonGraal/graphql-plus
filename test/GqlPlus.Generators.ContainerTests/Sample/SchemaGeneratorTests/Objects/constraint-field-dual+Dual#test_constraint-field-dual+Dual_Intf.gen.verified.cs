//HintName: test_constraint-field-dual+Dual_Intf.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public interface ItestCnstFieldDualDual
  : ItestRefCnstFieldDualDual
{
  public testCnstFieldDualDual CnstFieldDualDual { get; set; }
}

public interface ItestCnstFieldDualDualObject
  : ItestRefCnstFieldDualDualObject
{
}

public interface ItestRefCnstFieldDualDual<Tref>
{
  public testRefCnstFieldDualDual RefCnstFieldDualDual { get; set; }
}

public interface ItestRefCnstFieldDualDualObject<Tref>
{
  public Tref field { get; set; }
}

public interface ItestPrntCnstFieldDualDual
{
  public testString AsString { get; set; }
  public testPrntCnstFieldDualDual PrntCnstFieldDualDual { get; set; }
}

public interface ItestPrntCnstFieldDualDualObject
{
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  public testAltCnstFieldDualDual AltCnstFieldDualDual { get; set; }
}

public interface ItestAltCnstFieldDualDualObject
  : ItestPrntCnstFieldDualDualObject
{
  public testNumber alt { get; set; }
}
