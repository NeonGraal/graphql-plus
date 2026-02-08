//HintName: test_constraint-field-dual+Output_Impl.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public class testCnstFieldDualOutp
  : testRefCnstFieldDualOutp
  , ItestCnstFieldDualOutp
{
}

public class testRefCnstFieldDualOutp<Tref>
  : ItestRefCnstFieldDualOutp<Tref>
{
  public Tref Field { get; set; }
}

public class testPrntCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  public ItestString AsString { get; set; }
}

public class testAltCnstFieldDualOutp
  : testPrntCnstFieldDualOutp
  , ItestAltCnstFieldDualOutp
{
  public ItestNumber Alt { get; set; }
}
