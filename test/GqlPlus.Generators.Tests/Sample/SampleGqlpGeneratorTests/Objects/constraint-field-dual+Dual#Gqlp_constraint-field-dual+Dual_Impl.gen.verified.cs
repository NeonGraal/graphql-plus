//HintName: Gqlp_constraint-field-dual+Dual_Impl.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_dual_Dual;

public class DualCnstFieldDualDual
  : DualRefCnstFieldDualDual
  , ICnstFieldDualDual
{
}

public class DualRefCnstFieldDualDual<Tref>
  : IRefCnstFieldDualDual<Tref>
{
  public Tref field { get; set; }
}

public class DualPrntCnstFieldDualDual
  : IPrntCnstFieldDualDual
{
  public String AsString { get; set; }
}

public class DualAltCnstFieldDualDual
  : DualPrntCnstFieldDualDual
  , IAltCnstFieldDualDual
{
  public Number alt { get; set; }
}
