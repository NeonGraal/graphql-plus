//HintName: test_constraint-parent-obj-parent+Output_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public class testCnstPrntObjPrntOutp
  : testRefCnstPrntObjPrntOutp
  , ItestCnstPrntObjPrntOutp
{
}

public class testRefCnstPrntObjPrntOutp<Tref>
  : testref
  , ItestRefCnstPrntObjPrntOutp<Tref>
{
}

public class testPrntCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  public String AsString { get; set; }
}

public class testAltCnstPrntObjPrntOutp
  : testPrntCnstPrntObjPrntOutp
  , ItestAltCnstPrntObjPrntOutp
{
  public Number alt { get; set; }
}
