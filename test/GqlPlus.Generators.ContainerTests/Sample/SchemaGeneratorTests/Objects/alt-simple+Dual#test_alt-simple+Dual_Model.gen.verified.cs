//HintName: test_alt-simple+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Dual;

public class testAltSmplDual
  : GqlpModelBase
  , ItestAltSmplDual
{
  public string? AsString { get; set; }
  public ItestAltSmplDualObject? As_AltSmplDual { get; set; }
}

public class testAltSmplDualObject
  : GqlpModelBase
  , ItestAltSmplDualObject
{

  public testAltSmplDualObject
    ()
  {
  }
}
