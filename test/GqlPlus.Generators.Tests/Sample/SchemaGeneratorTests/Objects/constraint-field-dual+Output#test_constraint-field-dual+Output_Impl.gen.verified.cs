//HintName: test_constraint-field-dual+Output_Impl.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public class OutputtestCnstFieldDualOutp
  : OutputtestRefCnstFieldDualOutp
  , ItestCnstFieldDualOutp
{
}

public class OutputtestRefCnstFieldDualOutp<Tref>
  : ItestRefCnstFieldDualOutp<Tref>
{
  public Tref field { get; set; }
}

public class DualtestPrntCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  public String AsString { get; set; }
}

public class OutputtestAltCnstFieldDualOutp
  : OutputtestPrntCnstFieldDualOutp
  , ItestAltCnstFieldDualOutp
{
  public Number alt { get; set; }
}
