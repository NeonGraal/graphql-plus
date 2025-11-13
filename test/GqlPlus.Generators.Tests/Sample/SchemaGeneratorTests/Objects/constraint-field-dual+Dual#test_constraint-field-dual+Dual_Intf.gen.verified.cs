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

public interface ItestCnstFieldDualDualField
  : ItestRefCnstFieldDualDualField
{
}

public interface ItestRefCnstFieldDualDual<Tref>
{
  public testRefCnstFieldDualDual RefCnstFieldDualDual { get; set; }
}

public interface ItestRefCnstFieldDualDualField<Tref>
{
  public Tref field { get; set; }
}

public interface ItestPrntCnstFieldDualDual
{
  public testString AsString { get; set; }
  public testPrntCnstFieldDualDual PrntCnstFieldDualDual { get; set; }
}

public interface ItestPrntCnstFieldDualDualField
{
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  public testAltCnstFieldDualDual AltCnstFieldDualDual { get; set; }
}

public interface ItestAltCnstFieldDualDualField
  : ItestPrntCnstFieldDualDualField
{
  public testNumber alt { get; set; }
}
