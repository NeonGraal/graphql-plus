//HintName: test_alt-simple+Input_Model.gen.cs
// Generated from {CurrentDirectory}alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Input;

public class testAltSmplInp
  : GqlpModelBase
  , ItestAltSmplInp
{
  public string? AsString { get; set; }
  public ItestAltSmplInpObject? As_AltSmplInp { get; set; }
}

public class testAltSmplInpObject
  : GqlpModelBase
  , ItestAltSmplInpObject
{

  public testAltSmplInpObject
    ()
  {
  }
}
