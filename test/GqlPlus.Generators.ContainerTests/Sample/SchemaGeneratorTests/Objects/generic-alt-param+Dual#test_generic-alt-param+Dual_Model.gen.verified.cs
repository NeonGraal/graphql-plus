//HintName: test_generic-alt-param+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public class testGnrcAltParamDual
  : GqlpModelImplementationBase
  , ItestGnrcAltParamDual
{
  public ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual>? AsRefGnrcAltParamDual { get; set; }
  public ItestGnrcAltParamDualObject? As_GnrcAltParamDual { get; set; }
}

public class testGnrcAltParamDualObject
  : GqlpModelImplementationBase
  , ItestGnrcAltParamDualObject
{
}

public class testRefGnrcAltParamDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltParamDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltParamDualObject<TRef>? As_RefGnrcAltParamDual { get; set; }
}

public class testRefGnrcAltParamDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltParamDualObject<TRef>
{
}

public class testAltGnrcAltParamDual
  : GqlpModelImplementationBase
  , ItestAltGnrcAltParamDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltParamDualObject? As_AltGnrcAltParamDual { get; set; }
}

public class testAltGnrcAltParamDualObject
  : GqlpModelImplementationBase
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
