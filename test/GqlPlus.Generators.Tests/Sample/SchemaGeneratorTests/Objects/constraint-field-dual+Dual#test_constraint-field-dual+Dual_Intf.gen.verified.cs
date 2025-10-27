//HintName: test_constraint-field-dual+Dual_Intf.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public interface ItestCnstFieldDualDual
  : ItestRefCnstFieldDualDual
{
}

public interface ItestRefCnstFieldDualDual<Tref>
{
  Tref field { get; }
}

public interface ItestPrntCnstFieldDualDual
{
  String AsString { get; }
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  Number alt { get; }
}
