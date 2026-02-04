//HintName: test_constraint-parent-obj-parent+Output_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public class testCnstPrntObjPrntOutp
  : testRefCnstPrntObjPrntOutp
  , ItestCnstPrntObjPrntOutp
{
  public testCnstPrntObjPrntOutp CnstPrntObjPrntOutp { get; set; }
}

public class testRefCnstPrntObjPrntOutp<Tref>
  : testref
  , ItestRefCnstPrntObjPrntOutp<Tref>
{
  public testRefCnstPrntObjPrntOutp RefCnstPrntObjPrntOutp { get; set; }
}

public class testPrntCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntObjPrntOutp PrntCnstPrntObjPrntOutp { get; set; }
}

public class testAltCnstPrntObjPrntOutp
  : testPrntCnstPrntObjPrntOutp
  , ItestAltCnstPrntObjPrntOutp
{
  public testNumber alt { get; set; }
  public testAltCnstPrntObjPrntOutp AltCnstPrntObjPrntOutp { get; set; }
}
