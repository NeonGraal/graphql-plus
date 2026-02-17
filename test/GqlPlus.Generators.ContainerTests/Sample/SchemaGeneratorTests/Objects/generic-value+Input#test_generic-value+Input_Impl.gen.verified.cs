//HintName: test_generic-value+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public class testGnrcValueInp
  : GqlpModelImplementationBase
  , ItestGnrcValueInp
{
  public ItestRefGnrcValueInp<testEnumGnrcValueInp>? AsEnumGnrcValueInpgnrcValueInp { get; set; }
  public ItestGnrcValueInpObject? As_GnrcValueInp { get; set; }
}

public class testGnrcValueInpObject
  : GqlpModelImplementationBase
  , ItestGnrcValueInpObject
{

  public testGnrcValueInpObject()
  {
  }
}

public class testRefGnrcValueInp<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcValueInp<TType>
{
  public ItestRefGnrcValueInpObject<TType>? As_RefGnrcValueInp { get; set; }
}

public class testRefGnrcValueInpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcValueInpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueInpObject(TType field)
  {
    Field = field;
  }
}
