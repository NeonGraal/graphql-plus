//HintName: test_constraint-parent-obj-parent+Input_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public class testCnstPrntObjPrntInp
  : testRefCnstPrntObjPrntInp<ItestAltCnstPrntObjPrntInp>
  , ItestCnstPrntObjPrntInp
{
  public ItestCnstPrntObjPrntInpObject AsCnstPrntObjPrntInp { get; set; }
}

public class testRefCnstPrntObjPrntInp<TRef>
  : ItestRefCnstPrntObjPrntInp<TRef>
{
  public TRef AsParent { get; set; }
  public ItestRefCnstPrntObjPrntInpObject<TRef> AsRefCnstPrntObjPrntInp { get; set; }
}

public class testPrntCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntObjPrntInpObject AsPrntCnstPrntObjPrntInp { get; set; }
}

public class testAltCnstPrntObjPrntInp
  : testPrntCnstPrntObjPrntInp
  , ItestAltCnstPrntObjPrntInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntObjPrntInpObject AsAltCnstPrntObjPrntInp { get; set; }
}
