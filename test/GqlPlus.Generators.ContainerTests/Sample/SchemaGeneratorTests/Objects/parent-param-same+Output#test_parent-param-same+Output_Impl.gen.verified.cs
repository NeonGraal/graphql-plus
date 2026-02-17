//HintName: test_parent-param-same+Output_Impl.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public class testPrntParamSameOutp<TA>
  : testRefPrntParamSameOutp<TA>
  , ItestPrntParamSameOutp<TA>
{
  public ItestPrntParamSameOutpObject<TA>? As_PrntParamSameOutp { get; set; }
}

public class testPrntParamSameOutpObject<TA>
  : testRefPrntParamSameOutpObject<TA>
  , ItestPrntParamSameOutpObject<TA>
{
  public TA Field { get; set; }

  public testPrntParamSameOutpObject(TA field)
  {
    Field = field;
  }
}

public class testRefPrntParamSameOutp<TA>
  : GqlpModelImplementationBase
  , ItestRefPrntParamSameOutp<TA>
{
  public TA? Asa { get; set; }
  public ItestRefPrntParamSameOutpObject<TA>? As_RefPrntParamSameOutp { get; set; }
}

public class testRefPrntParamSameOutpObject<TA>
  : GqlpModelImplementationBase
  , ItestRefPrntParamSameOutpObject<TA>
{

  public testRefPrntParamSameOutpObject()
  {
  }
}
