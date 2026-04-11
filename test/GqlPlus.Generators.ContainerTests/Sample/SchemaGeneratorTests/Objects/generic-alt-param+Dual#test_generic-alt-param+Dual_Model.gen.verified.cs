//HintName: test_generic-alt-param+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public class testGnrcAltParamDual
  : GqlpModelBase
  , ItestGnrcAltParamDual
{
  public ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual>? AsRefGnrcAltParamDual { get; set; }
  public ItestGnrcAltParamDualObject? As_GnrcAltParamDual { get; set; }
}

public class testGnrcAltParamDualObject
  : GqlpModelBase
  , ItestGnrcAltParamDualObject
{

  public testGnrcAltParamDualObject
    ()
  {
  }
}

public class testRefGnrcAltParamDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltParamDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltParamDualObject<TRef>? As_RefGnrcAltParamDual { get; set; }
}

public class testRefGnrcAltParamDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltParamDualObject<TRef>
{

  public testRefGnrcAltParamDualObject
    ()
  {
  }
}

public class testAltGnrcAltParamDual
  : GqlpModelBase
  , ItestAltGnrcAltParamDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltParamDualObject? As_AltGnrcAltParamDual { get; set; }
}

public class testAltGnrcAltParamDualObject
  : GqlpModelBase
  , ItestAltGnrcAltParamDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltParamDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
