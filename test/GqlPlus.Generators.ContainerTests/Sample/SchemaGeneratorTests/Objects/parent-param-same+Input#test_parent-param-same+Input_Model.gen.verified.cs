//HintName: test_parent-param-same+Input_Model.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public class testPrntParamSameInp<TA>
  : testRefPrntParamSameInp<TA>
  , ItestPrntParamSameInp<TA>
{
  public ItestPrntParamSameInpObject<TA>? As_PrntParamSameInp { get; set; }
}

public class testPrntParamSameInpObject<TA>
  : testRefPrntParamSameInpObject<TA>
  , ItestPrntParamSameInpObject<TA>
{
  public TA Field { get; set; }

  public testPrntParamSameInpObject
    ( TA field
    )
  {
    Field = field;
  }
}

public class testRefPrntParamSameInp<TA>
  : GqlpModelBase
  , ItestRefPrntParamSameInp<TA>
{
  public TA? Asa { get; set; }
  public ItestRefPrntParamSameInpObject<TA>? As_RefPrntParamSameInp { get; set; }
}

public class testRefPrntParamSameInpObject<TA>
  : GqlpModelBase
  , ItestRefPrntParamSameInpObject<TA>
{

  public testRefPrntParamSameInpObject
    ()
  {
  }
}
