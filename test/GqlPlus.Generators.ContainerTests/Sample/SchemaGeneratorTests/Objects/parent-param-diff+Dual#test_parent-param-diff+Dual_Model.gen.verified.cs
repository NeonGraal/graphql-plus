//HintName: test_parent-param-diff+Dual_Model.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public class testPrntParamDiffDual<TA>
  : testRefPrntParamDiffDual<TA>
  , ItestPrntParamDiffDual<TA>
{
  public ItestPrntParamDiffDualObject<TA>? As_PrntParamDiffDual { get; set; }
}

public class testPrntParamDiffDualObject<TA>
  : testRefPrntParamDiffDualObject<TA>
  , ItestPrntParamDiffDualObject<TA>
{
  public TA Field { get; set; }

  public testPrntParamDiffDualObject
    ( TA field
    )
  {
    Field = field;
  }
}

public class testRefPrntParamDiffDual<TB>
  : GqlpModelImplementationBase
  , ItestRefPrntParamDiffDual<TB>
{
  public TB? Asb { get; set; }
  public ItestRefPrntParamDiffDualObject<TB>? As_RefPrntParamDiffDual { get; set; }
}

public class testRefPrntParamDiffDualObject<TB>
  : GqlpModelImplementationBase
  , ItestRefPrntParamDiffDualObject<TB>
{

  public testRefPrntParamDiffDualObject
    ()
  {
  }
}
