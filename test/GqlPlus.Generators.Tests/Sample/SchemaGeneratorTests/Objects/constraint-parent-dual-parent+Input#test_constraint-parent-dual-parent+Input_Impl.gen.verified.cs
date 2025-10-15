//HintName: test_constraint-parent-dual-parent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public class InputtestCnstPrntDualPrntInp
  : InputtestRefCnstPrntDualPrntInp
  , ItestCnstPrntDualPrntInp
{
}

public class InputtestRefCnstPrntDualPrntInp<Tref>
  : Inputtestref
  , ItestRefCnstPrntDualPrntInp<Tref>
{
}

public class DualtestPrntCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  public String AsString { get; set; }
}

public class InputtestAltCnstPrntDualPrntInp
  : InputtestPrntCnstPrntDualPrntInp
  , ItestAltCnstPrntDualPrntInp
{
  public Number alt { get; set; }
}
