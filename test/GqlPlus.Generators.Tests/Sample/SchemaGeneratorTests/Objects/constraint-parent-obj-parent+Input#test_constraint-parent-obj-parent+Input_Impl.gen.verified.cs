//HintName: test_constraint-parent-obj-parent+Input_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public class testCnstPrntObjPrntInp
  : testRefCnstPrntObjPrntInp
  , ItestCnstPrntObjPrntInp
{
  public testCnstPrntObjPrntInp CnstPrntObjPrntInp { get; set; }
}

public class testRefCnstPrntObjPrntInp<Tref>
  : testref
  , ItestRefCnstPrntObjPrntInp<Tref>
{
  public testRefCnstPrntObjPrntInp RefCnstPrntObjPrntInp { get; set; }
}

public class testPrntCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntObjPrntInp PrntCnstPrntObjPrntInp { get; set; }
}

public class testAltCnstPrntObjPrntInp
  : testPrntCnstPrntObjPrntInp
  , ItestAltCnstPrntObjPrntInp
{
  public testNumber alt { get; set; }
  public testAltCnstPrntObjPrntInp AltCnstPrntObjPrntInp { get; set; }
}
