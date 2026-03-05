//HintName: test_alt-simple+Input_Model.gen.cs
// Generated from {CurrentDirectory}alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Input;

public class testAltSmplInp
  : GqlpModelImplementationBase
  , ItestAltSmplInp
{
  public string? AsString { get; set; }
  public ItestAltSmplInpObject? As_AltSmplInp { get; set; }
}

public class testAltSmplInpObject
  : GqlpModelImplementationBase
  , ItestAltSmplInpObject
{

  public testAltSmplInpObject
    ()
  {
  }
}
