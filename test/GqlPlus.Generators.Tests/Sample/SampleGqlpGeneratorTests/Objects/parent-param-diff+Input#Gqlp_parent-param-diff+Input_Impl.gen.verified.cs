//HintName: Gqlp_parent-param-diff+Input_Impl.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_param_diff_Input;

public class InputPrntParamDiffInp<Ta>
  : InputRefPrntParamDiffInp
  , IPrntParamDiffInp<Ta>
{
  public Ta field { get; set; }
}

public class InputRefPrntParamDiffInp<Tb>
  : IRefPrntParamDiffInp<Tb>
{
  public Tb Asb { get; set; }
}
