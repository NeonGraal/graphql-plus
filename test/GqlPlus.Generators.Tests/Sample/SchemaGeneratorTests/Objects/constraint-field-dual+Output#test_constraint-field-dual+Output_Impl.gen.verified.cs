//HintName: test_constraint-field-dual+Output_Impl.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public class testCnstFieldDualOutp
  : testRefCnstFieldDualOutp
  , ItestCnstFieldDualOutp
{
  public testCnstFieldDualOutp CnstFieldDualOutp { get; set; }
}

public class testRefCnstFieldDualOutp<Tref>
  : ItestRefCnstFieldDualOutp<Tref>
{
  public Tref field { get; set; }
  public testRefCnstFieldDualOutp RefCnstFieldDualOutp { get; set; }
}

public class testPrntCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  public testString AsString { get; set; }
  public testPrntCnstFieldDualOutp PrntCnstFieldDualOutp { get; set; }
}

public class testAltCnstFieldDualOutp
  : testPrntCnstFieldDualOutp
  , ItestAltCnstFieldDualOutp
{
  public testNumber alt { get; set; }
  public testAltCnstFieldDualOutp AltCnstFieldDualOutp { get; set; }
}
