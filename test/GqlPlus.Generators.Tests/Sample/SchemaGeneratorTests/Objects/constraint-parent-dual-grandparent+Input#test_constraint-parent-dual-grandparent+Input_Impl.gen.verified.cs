//HintName: test_constraint-parent-dual-grandparent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public class InputtestCnstPrntDualGrndInp
  : InputtestRefCnstPrntDualGrndInp
  , ItestCnstPrntDualGrndInp
{
}

public class InputtestRefCnstPrntDualGrndInp<Tref>
  : Inputtestref
  , ItestRefCnstPrntDualGrndInp<Tref>
{
}

public class DualtestGrndCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  public String AsString { get; set; }
}

public class DualtestPrntCnstPrntDualGrndInp
  : DualtestGrndCnstPrntDualGrndInp
  , ItestPrntCnstPrntDualGrndInp
{
}

public class InputtestAltCnstPrntDualGrndInp
  : InputtestPrntCnstPrntDualGrndInp
  , ItestAltCnstPrntDualGrndInp
{
  public Number alt { get; set; }
}
