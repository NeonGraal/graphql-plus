//HintName: test_constraint-parent-obj-parent+Input_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public class testCnstPrntObjPrntInp
  : testRefCnstPrntObjPrntInp
  , ItestCnstPrntObjPrntInp
{
  public ItestCnstPrntObjPrntInpObject AsCnstPrntObjPrntInp { get; set; }
}

public class testRefCnstPrntObjPrntInp<Tref>
  : testref
  , ItestRefCnstPrntObjPrntInp<Tref>
{
  public ItestRefCnstPrntObjPrntInpObject AsRefCnstPrntObjPrntInp { get; set; }
}

public class testPrntCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstPrntObjPrntInpObject AsPrntCnstPrntObjPrntInp { get; set; }
}

public class testAltCnstPrntObjPrntInp
  : testPrntCnstPrntObjPrntInp
  , ItestAltCnstPrntObjPrntInp
{
  public ItestNumber Alt { get; set; }
  public ItestAltCnstPrntObjPrntInpObject AsAltCnstPrntObjPrntInp { get; set; }
}
