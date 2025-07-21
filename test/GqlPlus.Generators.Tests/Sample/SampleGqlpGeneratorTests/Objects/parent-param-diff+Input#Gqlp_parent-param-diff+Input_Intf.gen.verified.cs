//HintName: Gqlp_parent-param-diff+Input_Intf.gen.cs
// Generated from parent-param-diff+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_param_diff_Input;

public interface IPrntParamDiffInp<Ta>
  : IRefPrntParamDiffInp
{
  Ta field { get; }
}

public interface IRefPrntParamDiffInp<Tb>
{
  Tb Asb { get; }
}
