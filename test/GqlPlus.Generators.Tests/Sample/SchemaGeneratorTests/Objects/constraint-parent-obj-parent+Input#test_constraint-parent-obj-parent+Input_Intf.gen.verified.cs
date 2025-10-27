//HintName: test_constraint-parent-obj-parent+Input_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public interface ItestCnstPrntObjPrntInp
  : ItestRefCnstPrntObjPrntInp
{
}

public interface ItestRefCnstPrntObjPrntInp<Tref>
  : Itestref
{
}

public interface ItestPrntCnstPrntObjPrntInp
{
  String AsString { get; }
}

public interface ItestAltCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  Number alt { get; }
}
