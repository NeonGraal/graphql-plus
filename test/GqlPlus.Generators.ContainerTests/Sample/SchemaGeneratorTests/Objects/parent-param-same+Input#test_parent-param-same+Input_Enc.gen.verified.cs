//HintName: test_parent-param-same+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
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
  : GqlpEncoderBase
  , ItestRefPrntParamSameInp<TA>
{
  public TA? Asa { get; set; }
  public ItestRefPrntParamSameInpObject<TA>? As_RefPrntParamSameInp { get; set; }
}

public class testRefPrntParamSameInpObject<TA>
  : GqlpEncoderBase
  , ItestRefPrntParamSameInpObject<TA>
{

  public testRefPrntParamSameInpObject
    ()
  {
  }
}
