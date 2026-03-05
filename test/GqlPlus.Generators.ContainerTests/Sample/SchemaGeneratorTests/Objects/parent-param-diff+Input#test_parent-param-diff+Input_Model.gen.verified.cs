//HintName: test_parent-param-diff+Input_Model.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public class testPrntParamDiffInp<TA>
  : testRefPrntParamDiffInp<TA>
  , ItestPrntParamDiffInp<TA>
{
  public ItestPrntParamDiffInpObject<TA>? As_PrntParamDiffInp { get; set; }
}

public class testPrntParamDiffInpObject<TA>
  : testRefPrntParamDiffInpObject<TA>
  , ItestPrntParamDiffInpObject<TA>
{
  public TA Field { get; set; }

  public testPrntParamDiffInpObject
    ( TA field
    )
  {
    Field = field;
  }
}

public class testRefPrntParamDiffInp<TB>
  : GqlpModelImplementationBase
  , ItestRefPrntParamDiffInp<TB>
{
  public TB? Asb { get; set; }
  public ItestRefPrntParamDiffInpObject<TB>? As_RefPrntParamDiffInp { get; set; }
}

public class testRefPrntParamDiffInpObject<TB>
  : GqlpModelImplementationBase
  , ItestRefPrntParamDiffInpObject<TB>
{

  public testRefPrntParamDiffInpObject
    ()
  {
  }
}
