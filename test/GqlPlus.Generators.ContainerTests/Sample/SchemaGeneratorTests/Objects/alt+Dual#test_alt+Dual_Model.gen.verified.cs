//HintName: test_alt+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public class testAltDual
  : GqlpModelImplementationBase
  , ItestAltDual
{
  public ItestAltAltDual? AsAltAltDual { get; set; }
  public ItestAltDualObject? As_AltDual { get; set; }
}

public class testAltDualObject
  : GqlpModelImplementationBase
  , ItestAltDualObject
{
}

public class testAltAltDual
  : GqlpModelImplementationBase
  , ItestAltAltDual
{
  public string? AsString { get; set; }
  public ItestAltAltDualObject? As_AltAltDual { get; set; }
}

public class testAltAltDualObject
  : GqlpModelImplementationBase
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
