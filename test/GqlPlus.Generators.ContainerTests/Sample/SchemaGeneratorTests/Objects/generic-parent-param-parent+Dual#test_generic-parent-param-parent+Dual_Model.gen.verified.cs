//HintName: test_generic-parent-param-parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public class testGnrcPrntParamPrntDual
  : testRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
  , ItestGnrcPrntParamPrntDual
{
  public ItestGnrcPrntParamPrntDualObject? As_GnrcPrntParamPrntDual { get; set; }
}

public class testGnrcPrntParamPrntDualObject
  : testRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>
  , ItestGnrcPrntParamPrntDualObject
{

  public testGnrcPrntParamPrntDualObject
    ()
  {
  }
}

public class testRefGnrcPrntParamPrntDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntParamPrntDual<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntParamPrntDualObject<TRef>? As_RefGnrcPrntParamPrntDual { get; set; }
}

public class testRefGnrcPrntParamPrntDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntParamPrntDualObject<TRef>
{

  public testRefGnrcPrntParamPrntDualObject
    ()
  {
  }
}

public class testAltGnrcPrntParamPrntDual
  : GqlpModelBase
  , ItestAltGnrcPrntParamPrntDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamPrntDualObject? As_AltGnrcPrntParamPrntDual { get; set; }
}

public class testAltGnrcPrntParamPrntDualObject
  : GqlpModelBase
  , ItestAltGnrcPrntParamPrntDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamPrntDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
