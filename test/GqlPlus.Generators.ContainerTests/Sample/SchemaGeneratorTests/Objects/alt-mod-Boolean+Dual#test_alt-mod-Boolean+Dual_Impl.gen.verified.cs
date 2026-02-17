//HintName: test_alt-mod-Boolean+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public class testAltModBoolDual
  : GqlpModelImplementationBase
  , ItestAltModBoolDual
{
  public IDictionary<bool, ItestAltAltModBoolDual>? AsAltAltModBoolDual { get; set; }
  public ItestAltModBoolDualObject? As_AltModBoolDual { get; set; }
}

public class testAltModBoolDualObject
  : GqlpModelImplementationBase
  , ItestAltModBoolDualObject
{

  public testAltModBoolDualObject()
  {
  }
}

public class testAltAltModBoolDual
  : GqlpModelImplementationBase
  , ItestAltAltModBoolDual
{
  public string? AsString { get; set; }
  public ItestAltAltModBoolDualObject? As_AltAltModBoolDual { get; set; }
}

public class testAltAltModBoolDualObject
  : GqlpModelImplementationBase
  , ItestAltAltModBoolDualObject
{
  public decimal Alt { get; set; }

  public testAltAltModBoolDualObject(decimal alt)
  {
    Alt = alt;
  }
}
