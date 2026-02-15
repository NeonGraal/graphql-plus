//HintName: test_constraint-parent-obj-parent+Input_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public class testCnstPrntObjPrntInp
  : testRefCnstPrntObjPrntInp<ItestAltCnstPrntObjPrntInp>
  , ItestCnstPrntObjPrntInp
{
}

public class testRefCnstPrntObjPrntInp<TRef>
  : ItestRefCnstPrntObjPrntInp<TRef>
{
}

public class testPrntCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
}

public class testAltCnstPrntObjPrntInp
  : testPrntCnstPrntObjPrntInp
  , ItestAltCnstPrntObjPrntInp
{
  public decimal Alt { get; set; }
}
