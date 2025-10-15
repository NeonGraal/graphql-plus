//HintName: test_constraint-field-dual+Input_Impl.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public class InputtestCnstFieldDualInp
  : InputtestRefCnstFieldDualInp
  , ItestCnstFieldDualInp
{
}

public class InputtestRefCnstFieldDualInp<Tref>
  : ItestRefCnstFieldDualInp<Tref>
{
  public Tref field { get; set; }
}

public class DualtestPrntCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  public String AsString { get; set; }
}

public class InputtestAltCnstFieldDualInp
  : InputtestPrntCnstFieldDualInp
  , ItestAltCnstFieldDualInp
{
  public Number alt { get; set; }
}
