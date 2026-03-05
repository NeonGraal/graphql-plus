//HintName: test_generic-alt-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public class testGnrcAltDualDual
  : GqlpModelImplementationBase
  , ItestGnrcAltDualDual
{
  public ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual>? AsRefGnrcAltDualDual { get; set; }
  public ItestGnrcAltDualDualObject? As_GnrcAltDualDual { get; set; }
}

public class testGnrcAltDualDualObject
  : GqlpModelImplementationBase
  , ItestGnrcAltDualDualObject
{

  public testGnrcAltDualDualObject
    ()
  {
  }
}

public class testRefGnrcAltDualDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltDualDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltDualDualObject<TRef>? As_RefGnrcAltDualDual { get; set; }
}

public class testRefGnrcAltDualDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltDualDualObject<TRef>
{

  public testRefGnrcAltDualDualObject
    ()
  {
  }
}

public class testAltGnrcAltDualDual
  : GqlpModelImplementationBase
  , ItestAltGnrcAltDualDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltDualDualObject? As_AltGnrcAltDualDual { get; set; }
}

public class testAltGnrcAltDualDualObject
  : GqlpModelImplementationBase
  , ItestAltGnrcAltDualDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltDualDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
