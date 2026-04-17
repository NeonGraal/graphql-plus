//HintName: test_generic-value+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public class testGnrcValueInp
  : GqlpModelBase
  , ItestGnrcValueInp
{
  public ItestRefGnrcValueInp<testEnumGnrcValueInp>? AsEnumGnrcValueInpgnrcValueInp { get; set; }
  public ItestGnrcValueInpObject? As_GnrcValueInp { get; set; }
}

public class testGnrcValueInpObject
  : GqlpModelBase
  , ItestGnrcValueInpObject
{

  public testGnrcValueInpObject
    ()
  {
  }
}

public class testRefGnrcValueInp<TType>
  : GqlpModelBase
  , ItestRefGnrcValueInp<TType>
{
  public ItestRefGnrcValueInpObject<TType>? As_RefGnrcValueInp { get; set; }
}

public class testRefGnrcValueInpObject<TType>
  : GqlpModelBase
  , ItestRefGnrcValueInpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueInpObject
    ( TType field
    )
  {
    Field = field;
  }
}
