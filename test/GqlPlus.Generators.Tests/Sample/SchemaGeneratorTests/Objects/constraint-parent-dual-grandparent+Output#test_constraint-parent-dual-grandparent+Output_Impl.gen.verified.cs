//HintName: test_constraint-parent-dual-grandparent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public class OutputtestCnstPrntDualGrndOutp
  : OutputtestRefCnstPrntDualGrndOutp
  , ItestCnstPrntDualGrndOutp
{
}

public class OutputtestRefCnstPrntDualGrndOutp<Tref>
  : Outputtestref
  , ItestRefCnstPrntDualGrndOutp<Tref>
{
}

public class DualtestGrndCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  public String AsString { get; set; }
}

public class DualtestPrntCnstPrntDualGrndOutp
  : DualtestGrndCnstPrntDualGrndOutp
  , ItestPrntCnstPrntDualGrndOutp
{
}

public class OutputtestAltCnstPrntDualGrndOutp
  : OutputtestPrntCnstPrntDualGrndOutp
  , ItestAltCnstPrntDualGrndOutp
{
  public Number alt { get; set; }
}
