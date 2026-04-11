//HintName: test_alt-mod-Boolean+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public class testAltModBoolDual
  : GqlpModelBase
  , ItestAltModBoolDual
{
  public IDictionary<bool, ItestAltAltModBoolDual>? AsAltAltModBoolDual { get; set; }
  public ItestAltModBoolDualObject? As_AltModBoolDual { get; set; }
}

public class testAltModBoolDualObject
  : GqlpModelBase
  , ItestAltModBoolDualObject
{

  public testAltModBoolDualObject
    ()
  {
  }
}

public class testAltAltModBoolDual
  : GqlpModelBase
  , ItestAltAltModBoolDual
{
  public string? AsString { get; set; }
  public ItestAltAltModBoolDualObject? As_AltAltModBoolDual { get; set; }
}

public class testAltAltModBoolDualObject
  : GqlpModelBase
  , ItestAltAltModBoolDualObject
{
  public decimal Alt { get; set; }

  public testAltAltModBoolDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
