//HintName: test_constraint-parent-obj-parent+Output_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public interface ItestCnstPrntObjPrntOutp
  : ItestRefCnstPrntObjPrntOutp
{
  public ItestCnstPrntObjPrntOutpObject AsCnstPrntObjPrntOutp { get; set; }
}

public interface ItestCnstPrntObjPrntOutpObject
  : ItestRefCnstPrntObjPrntOutpObject
{
}

public interface ItestRefCnstPrntObjPrntOutp<Tref>
  : Itestref
{
  public ItestRefCnstPrntObjPrntOutpObject AsRefCnstPrntObjPrntOutp { get; set; }
}

public interface ItestRefCnstPrntObjPrntOutpObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntObjPrntOutp
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstPrntObjPrntOutpObject AsPrntCnstPrntObjPrntOutp { get; set; }
}

public interface ItestPrntCnstPrntObjPrntOutpObject
{
}

public interface ItestAltCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  public ItestAltCnstPrntObjPrntOutpObject AsAltCnstPrntObjPrntOutp { get; set; }
}

public interface ItestAltCnstPrntObjPrntOutpObject
  : ItestPrntCnstPrntObjPrntOutpObject
{
  public ItestNumber Alt { get; set; }
}
