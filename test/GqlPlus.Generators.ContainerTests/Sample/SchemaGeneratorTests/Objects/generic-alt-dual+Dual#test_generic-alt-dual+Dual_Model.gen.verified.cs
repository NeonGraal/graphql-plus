//HintName: test_generic-alt-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public class testGnrcAltDualDual
  : GqlpModelBase
  , ItestGnrcAltDualDual
{
  public ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual>? AsRefGnrcAltDualDual { get; set; }
  public ItestGnrcAltDualDualObject? As_GnrcAltDualDual { get; set; }
}

public class testGnrcAltDualDualObject
  : GqlpModelBase
  , ItestGnrcAltDualDualObject
{

  public testGnrcAltDualDualObject
    ()
  {
  }
}

public class testRefGnrcAltDualDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltDualDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltDualDualObject<TRef>? As_RefGnrcAltDualDual { get; set; }
}

public class testRefGnrcAltDualDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltDualDualObject<TRef>
{

  public testRefGnrcAltDualDualObject
    ()
  {
  }
}

public class testAltGnrcAltDualDual
  : GqlpModelBase
  , ItestAltGnrcAltDualDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltDualDualObject? As_AltGnrcAltDualDual { get; set; }
}

public class testAltGnrcAltDualDualObject
  : GqlpModelBase
  , ItestAltGnrcAltDualDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltDualDualObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
