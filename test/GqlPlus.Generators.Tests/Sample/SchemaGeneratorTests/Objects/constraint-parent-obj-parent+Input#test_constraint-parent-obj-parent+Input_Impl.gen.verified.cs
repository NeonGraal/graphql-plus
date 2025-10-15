//HintName: test_constraint-parent-obj-parent+Input_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public class InputtestCnstPrntObjPrntInp
  : InputtestRefCnstPrntObjPrntInp
  , ItestCnstPrntObjPrntInp
{
}

public class InputtestRefCnstPrntObjPrntInp<Tref>
  : Inputtestref
  , ItestRefCnstPrntObjPrntInp<Tref>
{
}

public class InputtestPrntCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  public String AsString { get; set; }
}

public class InputtestAltCnstPrntObjPrntInp
  : InputtestPrntCnstPrntObjPrntInp
  , ItestAltCnstPrntObjPrntInp
{
  public Number alt { get; set; }
}
