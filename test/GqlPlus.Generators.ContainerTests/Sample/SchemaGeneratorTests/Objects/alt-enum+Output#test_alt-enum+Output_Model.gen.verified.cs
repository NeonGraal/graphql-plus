//HintName: test_alt-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Output;

public class testAltEnumOutp
  : GqlpModelBase
  , ItestAltEnumOutp
{
  public testEnumAltEnumOutp? AsEnumAltEnumOutpaltEnumOutp { get; set; }
  public ItestAltEnumOutpObject? As_AltEnumOutp { get; set; }
}

public class testAltEnumOutpObject
  : GqlpModelBase
  , ItestAltEnumOutpObject
{

  public testAltEnumOutpObject
    ()
  {
  }
}
