//HintName: test_alt+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public class testAltDual
  : GqlpModelBase
  , ItestAltDual
{
  public ItestAltAltDual? AsAltAltDual { get; set; }
  public ItestAltDualObject? As_AltDual { get; set; }
}

public class testAltDualObject
  : GqlpModelBase
  , ItestAltDualObject
{

  public testAltDualObject
    ()
  {
  }
}

public class testAltAltDual
  : GqlpModelBase
  , ItestAltAltDual
{
  public string? AsString { get; set; }
  public ItestAltAltDualObject? As_AltAltDual { get; set; }
}

public class testAltAltDualObject
  : GqlpModelBase
  , ItestAltAltDualObject
{
  public decimal Alt { get; set; }

  public testAltAltDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
