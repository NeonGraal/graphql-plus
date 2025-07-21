//HintName: Gqlp_constraint-parent-dual-grandparent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_grandparent_Output;

public interface ICnstPrntDualGrndOutp
  : IRefCnstPrntDualGrndOutp
{
}

public interface IRefCnstPrntDualGrndOutp<Tref>
  : Iref
{
}

public interface IGrndCnstPrntDualGrndOutp
{
  String AsString { get; }
}

public interface IPrntCnstPrntDualGrndOutp
  : IGrndCnstPrntDualGrndOutp
{
}

public interface IAltCnstPrntDualGrndOutp
  : IPrntCnstPrntDualGrndOutp
{
  Number alt { get; }
}
