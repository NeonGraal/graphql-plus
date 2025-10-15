//HintName: test_constraint-parent-obj-parent+Output_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public class OutputtestCnstPrntObjPrntOutp
  : OutputtestRefCnstPrntObjPrntOutp
  , ItestCnstPrntObjPrntOutp
{
}

public class OutputtestRefCnstPrntObjPrntOutp<Tref>
  : Outputtestref
  , ItestRefCnstPrntObjPrntOutp<Tref>
{
}

public class OutputtestPrntCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  public String AsString { get; set; }
}

public class OutputtestAltCnstPrntObjPrntOutp
  : OutputtestPrntCnstPrntObjPrntOutp
  , ItestAltCnstPrntObjPrntOutp
{
  public Number alt { get; set; }
}
