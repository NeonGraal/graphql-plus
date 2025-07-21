//HintName: Gqlp_constraint-parent-dual-grandparent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_grandparent_Input;

public interface ICnstPrntDualGrndInp
  : IRefCnstPrntDualGrndInp
{
}

public interface IRefCnstPrntDualGrndInp<Tref>
  : Iref
{
}

public interface IGrndCnstPrntDualGrndInp
{
  String AsString { get; }
}

public interface IPrntCnstPrntDualGrndInp
  : IGrndCnstPrntDualGrndInp
{
}

public interface IAltCnstPrntDualGrndInp
  : IPrntCnstPrntDualGrndInp
{
  Number alt { get; }
}
