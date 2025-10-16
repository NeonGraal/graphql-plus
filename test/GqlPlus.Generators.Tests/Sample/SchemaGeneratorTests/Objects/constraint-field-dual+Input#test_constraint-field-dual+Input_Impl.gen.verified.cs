//HintName: test_constraint-field-dual+Input_Impl.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public class testCnstFieldDualInp
  : testRefCnstFieldDualInp
  , ItestCnstFieldDualInp
{
}

public class testRefCnstFieldDualInp<Tref>
  : ItestRefCnstFieldDualInp<Tref>
{
  public Tref field { get; set; }
}

public class testPrntCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  public String AsString { get; set; }
}

public class testAltCnstFieldDualInp
  : testPrntCnstFieldDualInp
  , ItestAltCnstFieldDualInp
{
  public Number alt { get; set; }
}
