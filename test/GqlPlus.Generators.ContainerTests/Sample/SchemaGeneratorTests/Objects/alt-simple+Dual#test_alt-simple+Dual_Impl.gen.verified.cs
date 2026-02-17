//HintName: test_alt-simple+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Dual;

public class testAltSmplDual
  : GqlpModelImplementationBase
  , ItestAltSmplDual
{
  public string? AsString { get; set; }
  public ItestAltSmplDualObject? As_AltSmplDual { get; set; }
}

public class testAltSmplDualObject
  : GqlpModelImplementationBase
  , ItestAltSmplDualObject
{

  public testAltSmplDualObject()
  {
  }
}
