//HintName: test_generic-parent-param+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public class testGnrcPrntParamDual
  : testRefGnrcPrntParamDual<ItestAltGnrcPrntParamDual>
  , ItestGnrcPrntParamDual
{
  public ItestGnrcPrntParamDualObject? As_GnrcPrntParamDual { get; set; }
}

public class testGnrcPrntParamDualObject
  : testRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>
  , ItestGnrcPrntParamDualObject
{

  public testGnrcPrntParamDualObject
    ()
  {
  }
}

public class testRefGnrcPrntParamDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntParamDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntParamDualObject<TRef>? As_RefGnrcPrntParamDual { get; set; }
}

public class testRefGnrcPrntParamDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntParamDualObject<TRef>
{

  public testRefGnrcPrntParamDualObject
    ()
  {
  }
}

public class testAltGnrcPrntParamDual
  : GqlpModelBase
  , ItestAltGnrcPrntParamDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamDualObject? As_AltGnrcPrntParamDual { get; set; }
}

public class testAltGnrcPrntParamDualObject
  : GqlpModelBase
  , ItestAltGnrcPrntParamDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
