//HintName: test_alt-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

public class testAltEnumDual
  : GqlpModelBase
  , ItestAltEnumDual
{
  public testEnumAltEnumDual? AsEnumAltEnumDualaltEnumDual { get; set; }
  public ItestAltEnumDualObject? As_AltEnumDual { get; set; }
}

public class testAltEnumDualObject
  : GqlpModelBase
  , ItestAltEnumDualObject
{

  public testAltEnumDualObject
    ()
  {
  }
}
