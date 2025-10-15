//HintName: test_constraint-field-dual+Dual_Impl.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public class DualtestCnstFieldDualDual
  : DualtestRefCnstFieldDualDual
  , ItestCnstFieldDualDual
{
}

public class DualtestRefCnstFieldDualDual<Tref>
  : ItestRefCnstFieldDualDual<Tref>
{
  public Tref field { get; set; }
}

public class DualtestPrntCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  public String AsString { get; set; }
}

public class DualtestAltCnstFieldDualDual
  : DualtestPrntCnstFieldDualDual
  , ItestAltCnstFieldDualDual
{
  public Number alt { get; set; }
}
