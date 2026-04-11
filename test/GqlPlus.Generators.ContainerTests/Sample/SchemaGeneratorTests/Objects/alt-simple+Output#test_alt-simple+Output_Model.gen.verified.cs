//HintName: test_alt-simple+Output_Model.gen.cs
// Generated from {CurrentDirectory}alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Output;

public class testAltSmplOutp
  : GqlpModelBase
  , ItestAltSmplOutp
{
  public string? AsString { get; set; }
  public ItestAltSmplOutpObject? As_AltSmplOutp { get; set; }
}

public class testAltSmplOutpObject
  : GqlpModelBase
  , ItestAltSmplOutpObject
{

  public testAltSmplOutpObject
    ()
  {
  }
}
