//HintName: test_parent-param-same+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public class testPrntParamSameDual<TA>
  : testRefPrntParamSameDual<TA>
  , ItestPrntParamSameDual<TA>
{
  public ItestPrntParamSameDualObject<TA>? As_PrntParamSameDual { get; set; }
}

public class testPrntParamSameDualObject<TA>
  : testRefPrntParamSameDualObject<TA>
  , ItestPrntParamSameDualObject<TA>
{
  public TA Field { get; set; }

  public testPrntParamSameDualObject(TA field)
  {
    Field = field;
  }
}

public class testRefPrntParamSameDual<TA>
  : GqlpModelImplementationBase
  , ItestRefPrntParamSameDual<TA>
{
  public TA? Asa { get; set; }
  public ItestRefPrntParamSameDualObject<TA>? As_RefPrntParamSameDual { get; set; }
}

public class testRefPrntParamSameDualObject<TA>
  : GqlpModelImplementationBase
  , ItestRefPrntParamSameDualObject<TA>
{

  public testRefPrntParamSameDualObject()
  {
  }
}
