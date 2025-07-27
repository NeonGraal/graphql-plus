//HintName: Gqlp_constraint-parent-obj-parent+Input_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_obj_parent_Input;

public class InputCnstPrntObjPrntInp
  : InputRefCnstPrntObjPrntInp
  , ICnstPrntObjPrntInp
{
}

public class InputRefCnstPrntObjPrntInp<Tref>
  : Inputref
  , IRefCnstPrntObjPrntInp<Tref>
{
}

public class InputPrntCnstPrntObjPrntInp
  : IPrntCnstPrntObjPrntInp
{
  public String AsString { get; set; }
}

public class InputAltCnstPrntObjPrntInp
  : InputPrntCnstPrntObjPrntInp
  , IAltCnstPrntObjPrntInp
{
  public Number alt { get; set; }
}
