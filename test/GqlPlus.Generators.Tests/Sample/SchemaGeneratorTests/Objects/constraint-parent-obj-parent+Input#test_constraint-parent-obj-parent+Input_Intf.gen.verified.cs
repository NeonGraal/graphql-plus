//HintName: test_constraint-parent-obj-parent+Input_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public interface ItestCnstPrntObjPrntInp
  : ItestRefCnstPrntObjPrntInp
{
  public testCnstPrntObjPrntInp CnstPrntObjPrntInp { get; set; }
}

public interface ItestCnstPrntObjPrntInpField
  : ItestRefCnstPrntObjPrntInpField
{
}

public interface ItestRefCnstPrntObjPrntInp<Tref>
  : Itestref
{
  public testRefCnstPrntObjPrntInp RefCnstPrntObjPrntInp { get; set; }
}

public interface ItestRefCnstPrntObjPrntInpField<Tref>
  : ItestrefField
{
}

public interface ItestPrntCnstPrntObjPrntInp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntObjPrntInp PrntCnstPrntObjPrntInp { get; set; }
}

public interface ItestPrntCnstPrntObjPrntInpField
{
}

public interface ItestAltCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  public testAltCnstPrntObjPrntInp AltCnstPrntObjPrntInp { get; set; }
}

public interface ItestAltCnstPrntObjPrntInpField
  : ItestPrntCnstPrntObjPrntInpField
{
  public testNumber alt { get; set; }
}
