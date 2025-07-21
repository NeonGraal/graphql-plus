//HintName: Gqlp_constraint-parent-dual-parent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_parent_Input;

public interface ICnstPrntDualPrntInp
  : IRefCnstPrntDualPrntInp
{
}

public interface IRefCnstPrntDualPrntInp<Tref>
  : Iref
{
}

public interface IPrntCnstPrntDualPrntInp
{
  String AsString { get; }
}

public interface IAltCnstPrntDualPrntInp
  : IPrntCnstPrntDualPrntInp
{
  Number alt { get; }
}
