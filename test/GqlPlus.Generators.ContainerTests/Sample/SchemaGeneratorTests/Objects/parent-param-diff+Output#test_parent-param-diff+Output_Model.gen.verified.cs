//HintName: test_parent-param-diff+Output_Model.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public class testPrntParamDiffOutp<TA>
  : testRefPrntParamDiffOutp<TA>
  , ItestPrntParamDiffOutp<TA>
{
  public ItestPrntParamDiffOutpObject<TA>? As_PrntParamDiffOutp { get; set; }
}

public class testPrntParamDiffOutpObject<TA>
  : testRefPrntParamDiffOutpObject<TA>
  , ItestPrntParamDiffOutpObject<TA>
{
  public TA Field { get; set; }

  public testPrntParamDiffOutpObject
    ( TA field
    )
  {
    Field = field;
  }
}

public class testRefPrntParamDiffOutp<TB>
  : GqlpModelBase
  , ItestRefPrntParamDiffOutp<TB>
{
  public TB? Asb { get; set; }
  public ItestRefPrntParamDiffOutpObject<TB>? As_RefPrntParamDiffOutp { get; set; }
}

public class testRefPrntParamDiffOutpObject<TB>
  : GqlpModelBase
  , ItestRefPrntParamDiffOutpObject<TB>
{

  public testRefPrntParamDiffOutpObject
    ()
  {
  }
}
