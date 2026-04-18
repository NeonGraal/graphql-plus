//HintName: test_constraint-alt+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Input;

public class testCnstAltInp<TType>
  : GqlpModelBase
  , ItestCnstAltInp<TType>
{
  public TType? Astype { get; set; }
  public ItestCnstAltInpObject<TType>? As_CnstAltInp { get; set; }
}

public class testCnstAltInpObject<TType>
  : GqlpModelBase
  , ItestCnstAltInpObject<TType>
{

  public testCnstAltInpObject
    ()
  {
  }
}
