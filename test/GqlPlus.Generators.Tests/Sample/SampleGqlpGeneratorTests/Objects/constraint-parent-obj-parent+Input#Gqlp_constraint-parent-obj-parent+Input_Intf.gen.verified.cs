//HintName: Gqlp_constraint-parent-obj-parent+Input_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_obj_parent_Input;

public interface ICnstPrntObjPrntInp
  : IRefCnstPrntObjPrntInp
{
}

public interface IRefCnstPrntObjPrntInp<Tref>
  : Iref
{
}

public interface IPrntCnstPrntObjPrntInp
{
  String AsString { get; }
}

public interface IAltCnstPrntObjPrntInp
  : IPrntCnstPrntObjPrntInp
{
  Number alt { get; }
}
