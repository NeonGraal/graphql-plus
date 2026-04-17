//HintName: test_generic-parent-dual-parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public class testGnrcPrntDualPrntDual
  : testRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
  , ItestGnrcPrntDualPrntDual
{
  public ItestGnrcPrntDualPrntDualObject? As_GnrcPrntDualPrntDual { get; set; }
}

public class testGnrcPrntDualPrntDualObject
  : testRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>
  , ItestGnrcPrntDualPrntDualObject
{

  public testGnrcPrntDualPrntDualObject
    ()
  {
  }
}

public class testRefGnrcPrntDualPrntDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntDualPrntDual<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntDualPrntDualObject<TRef>? As_RefGnrcPrntDualPrntDual { get; set; }
}

public class testRefGnrcPrntDualPrntDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntDualPrntDualObject<TRef>
{

  public testRefGnrcPrntDualPrntDualObject
    ()
  {
  }
}

public class testAltGnrcPrntDualPrntDual
  : GqlpModelBase
  , ItestAltGnrcPrntDualPrntDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualPrntDualObject? As_AltGnrcPrntDualPrntDual { get; set; }
}

public class testAltGnrcPrntDualPrntDualObject
  : GqlpModelBase
  , ItestAltGnrcPrntDualPrntDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualPrntDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
