//HintName: test_constraint-parent-dual-parent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public class OutputtestCnstPrntDualPrntOutp
  : OutputtestRefCnstPrntDualPrntOutp
  , ItestCnstPrntDualPrntOutp
{
}

public class OutputtestRefCnstPrntDualPrntOutp<Tref>
  : Outputtestref
  , ItestRefCnstPrntDualPrntOutp<Tref>
{
}

public class DualtestPrntCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  public String AsString { get; set; }
}

public class OutputtestAltCnstPrntDualPrntOutp
  : OutputtestPrntCnstPrntDualPrntOutp
  , ItestAltCnstPrntDualPrntOutp
{
  public Number alt { get; set; }
}
