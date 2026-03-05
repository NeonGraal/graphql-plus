//HintName: test_generic-parent-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public class testGnrcPrntDualDual
  : testRefGnrcPrntDualDual<ItestAltGnrcPrntDualDual>
  , ItestGnrcPrntDualDual
{
  public ItestGnrcPrntDualDualObject? As_GnrcPrntDualDual { get; set; }
}

public class testGnrcPrntDualDualObject
  : testRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>
  , ItestGnrcPrntDualDualObject
{

  public testGnrcPrntDualDualObject
    ()
  {
  }
}

public class testRefGnrcPrntDualDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntDualDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntDualDualObject<TRef>? As_RefGnrcPrntDualDual { get; set; }
}

public class testRefGnrcPrntDualDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntDualDualObject<TRef>
{

  public testRefGnrcPrntDualDualObject
    ()
  {
  }
}

public class testAltGnrcPrntDualDual
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntDualDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualDualObject? As_AltGnrcPrntDualDual { get; set; }
}

public class testAltGnrcPrntDualDualObject
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntDualDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
