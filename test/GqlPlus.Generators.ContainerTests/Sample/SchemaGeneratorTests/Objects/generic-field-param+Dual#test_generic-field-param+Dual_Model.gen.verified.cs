//HintName: test_generic-field-param+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public class testGnrcFieldParamDual
  : GqlpModelBase
  , ItestGnrcFieldParamDual
{
  public ItestGnrcFieldParamDualObject? As_GnrcFieldParamDual { get; set; }
}

public class testGnrcFieldParamDualObject
  : GqlpModelBase
  , ItestGnrcFieldParamDualObject
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }

  public testGnrcFieldParamDualObject
    ( ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> pfield
    )
  {
    Field = pfield;
  }
}

public class testRefGnrcFieldParamDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldParamDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldParamDualObject<TRef>? As_RefGnrcFieldParamDual { get; set; }
}

public class testRefGnrcFieldParamDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldParamDualObject<TRef>
{

  public testRefGnrcFieldParamDualObject
    ()
  {
  }
}

public class testAltGnrcFieldParamDual
  : GqlpModelBase
  , ItestAltGnrcFieldParamDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldParamDualObject? As_AltGnrcFieldParamDual { get; set; }
}

public class testAltGnrcFieldParamDualObject
  : GqlpModelBase
  , ItestAltGnrcFieldParamDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldParamDualObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
