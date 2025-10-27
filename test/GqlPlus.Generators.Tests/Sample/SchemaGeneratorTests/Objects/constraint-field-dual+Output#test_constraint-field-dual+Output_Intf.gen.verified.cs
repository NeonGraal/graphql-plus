//HintName: test_constraint-field-dual+Output_Intf.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public interface ItestCnstFieldDualOutp
  : ItestRefCnstFieldDualOutp
{
}

public interface ItestRefCnstFieldDualOutp<Tref>
{
  Tref field { get; }
}

public interface ItestPrntCnstFieldDualOutp
{
  String AsString { get; }
}

public interface ItestAltCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  Number alt { get; }
}
