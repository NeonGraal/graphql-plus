//HintName: test_constraint-field-dual+Output_Impl.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public class testCnstFieldDualOutp
  : testRefCnstFieldDualOutp<ItestAltCnstFieldDualOutp>
  , ItestCnstFieldDualOutp
{
  public ItestCnstFieldDualOutpObject AsCnstFieldDualOutp { get; set; }
}

public class testRefCnstFieldDualOutp<TRef>
  : ItestRefCnstFieldDualOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDualOutpObject AsRefCnstFieldDualOutp { get; set; }
}

public class testPrntCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldDualOutpObject AsPrntCnstFieldDualOutp { get; set; }
}

public class testAltCnstFieldDualOutp
  : testPrntCnstFieldDualOutp
  , ItestAltCnstFieldDualOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldDualOutpObject AsAltCnstFieldDualOutp { get; set; }
}
