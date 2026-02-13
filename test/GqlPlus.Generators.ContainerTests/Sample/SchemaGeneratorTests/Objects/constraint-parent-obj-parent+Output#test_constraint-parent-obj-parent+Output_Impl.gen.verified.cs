//HintName: test_constraint-parent-obj-parent+Output_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public class testCnstPrntObjPrntOutp
  : testRefCnstPrntObjPrntOutp<ItestAltCnstPrntObjPrntOutp>
  , ItestCnstPrntObjPrntOutp
{
  public ItestCnstPrntObjPrntOutpObject AsCnstPrntObjPrntOutp { get; set; }
}

public class testRefCnstPrntObjPrntOutp<TRef>
  : ItestRefCnstPrntObjPrntOutp<TRef>
{
  public TRef AsParent { get; set; }
  public ItestRefCnstPrntObjPrntOutpObject<TRef> AsRefCnstPrntObjPrntOutp { get; set; }
}

public class testPrntCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntObjPrntOutpObject AsPrntCnstPrntObjPrntOutp { get; set; }
}

public class testAltCnstPrntObjPrntOutp
  : testPrntCnstPrntObjPrntOutp
  , ItestAltCnstPrntObjPrntOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntObjPrntOutpObject AsAltCnstPrntObjPrntOutp { get; set; }
}
