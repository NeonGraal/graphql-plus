//HintName: Gqlp_constraint-parent-obj-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_obj_parent_Dual;

public interface ICnstPrntObjPrntDual
  : IRefCnstPrntObjPrntDual
{
}

public interface IRefCnstPrntObjPrntDual<Tref>
  : Iref
{
}

public interface IPrntCnstPrntObjPrntDual
{
  String AsString { get; }
}

public interface IAltCnstPrntObjPrntDual
  : IPrntCnstPrntObjPrntDual
{
  Number alt { get; }
}
