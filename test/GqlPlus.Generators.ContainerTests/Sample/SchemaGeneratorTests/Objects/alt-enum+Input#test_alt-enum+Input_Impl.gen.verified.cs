//HintName: test_alt-enum+Input_Impl.gen.cs
// Generated from {CurrentDirectory}alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Input;

public class testAltEnumInp
  : GqlpModelImplementationBase
  , ItestAltEnumInp
{
  public testEnumAltEnumInp? AsEnumAltEnumInpaltEnumInp { get; set; }
  public ItestAltEnumInpObject? As_AltEnumInp { get; set; }
}

public class testAltEnumInpObject
  : GqlpModelImplementationBase
  , ItestAltEnumInpObject
{

  public testAltEnumInpObject
    ()
  {
  }
}
