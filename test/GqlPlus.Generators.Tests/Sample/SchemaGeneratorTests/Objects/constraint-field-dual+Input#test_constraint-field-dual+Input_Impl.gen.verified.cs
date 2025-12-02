//HintName: test_constraint-field-dual+Input_Impl.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public class testCnstFieldDualInp
  : testRefCnstFieldDualInp
  , ItestCnstFieldDualInp
{
  public testCnstFieldDualInp CnstFieldDualInp { get; set; }
}

public class testRefCnstFieldDualInp<Tref>
  : ItestRefCnstFieldDualInp<Tref>
{
  public Tref field { get; set; }
  public testRefCnstFieldDualInp RefCnstFieldDualInp { get; set; }
}

public class testPrntCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  public testString AsString { get; set; }
  public testPrntCnstFieldDualInp PrntCnstFieldDualInp { get; set; }
}

public class testAltCnstFieldDualInp
  : testPrntCnstFieldDualInp
  , ItestAltCnstFieldDualInp
{
  public testNumber alt { get; set; }
  public testAltCnstFieldDualInp AltCnstFieldDualInp { get; set; }
}
