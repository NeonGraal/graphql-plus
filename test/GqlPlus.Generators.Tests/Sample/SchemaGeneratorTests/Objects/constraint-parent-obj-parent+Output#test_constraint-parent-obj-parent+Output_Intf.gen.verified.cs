//HintName: test_constraint-parent-obj-parent+Output_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public interface ItestCnstPrntObjPrntOutp
  : ItestRefCnstPrntObjPrntOutp
{
  public testCnstPrntObjPrntOutp CnstPrntObjPrntOutp { get; set; }
}

public interface ItestCnstPrntObjPrntOutpField
  : ItestRefCnstPrntObjPrntOutpField
{
}

public interface ItestRefCnstPrntObjPrntOutp<Tref>
  : Itestref
{
  public testRefCnstPrntObjPrntOutp RefCnstPrntObjPrntOutp { get; set; }
}

public interface ItestRefCnstPrntObjPrntOutpField<Tref>
  : ItestrefField
{
}

public interface ItestPrntCnstPrntObjPrntOutp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntObjPrntOutp PrntCnstPrntObjPrntOutp { get; set; }
}

public interface ItestPrntCnstPrntObjPrntOutpField
{
}

public interface ItestAltCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  public testAltCnstPrntObjPrntOutp AltCnstPrntObjPrntOutp { get; set; }
}

public interface ItestAltCnstPrntObjPrntOutpField
  : ItestPrntCnstPrntObjPrntOutpField
{
  public testNumber alt { get; set; }
}
