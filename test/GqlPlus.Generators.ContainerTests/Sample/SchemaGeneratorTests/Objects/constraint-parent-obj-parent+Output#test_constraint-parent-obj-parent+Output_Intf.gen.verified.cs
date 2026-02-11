//HintName: test_constraint-parent-obj-parent+Output_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public interface ItestCnstPrntObjPrntOutp
  : ItestRefCnstPrntObjPrntOutp
{
  ItestCnstPrntObjPrntOutpObject AsCnstPrntObjPrntOutp { get; }
}

public interface ItestCnstPrntObjPrntOutpObject
  : ItestRefCnstPrntObjPrntOutpObject
{
}

public interface ItestRefCnstPrntObjPrntOutp<Tref>
  : Itestref
{
  ItestRefCnstPrntObjPrntOutpObject AsRefCnstPrntObjPrntOutp { get; }
}

public interface ItestRefCnstPrntObjPrntOutpObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntObjPrntOutp
{
  string AsString { get; }
  ItestPrntCnstPrntObjPrntOutpObject AsPrntCnstPrntObjPrntOutp { get; }
}

public interface ItestPrntCnstPrntObjPrntOutpObject
{
}

public interface ItestAltCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  ItestAltCnstPrntObjPrntOutpObject AsAltCnstPrntObjPrntOutp { get; }
}

public interface ItestAltCnstPrntObjPrntOutpObject
  : ItestPrntCnstPrntObjPrntOutpObject
{
  decimal Alt { get; }
}
