//HintName: test_alt-descr+Input_Model.gen.cs
// Generated from {CurrentDirectory}alt-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_descr_Input;

public class testAltDescrInp
  : GqlpModelBase
  , ItestAltDescrInp
{
  public string? AsString { get; set; }
  public ItestAltDescrInpObject? As_AltDescrInp { get; set; }
}

public class testAltDescrInpObject
  : GqlpModelBase
  , ItestAltDescrInpObject
{

  public testAltDescrInpObject
    ()
  {
  }
}
