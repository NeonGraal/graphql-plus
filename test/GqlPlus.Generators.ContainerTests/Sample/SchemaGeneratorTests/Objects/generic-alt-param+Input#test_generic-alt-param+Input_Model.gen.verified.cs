//HintName: test_generic-alt-param+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public class testGnrcAltParamInp
  : GqlpModelBase
  , ItestGnrcAltParamInp
{
  public ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp>? AsRefGnrcAltParamInp { get; set; }
  public ItestGnrcAltParamInpObject? As_GnrcAltParamInp { get; set; }
}

public class testGnrcAltParamInpObject
  : GqlpModelBase
  , ItestGnrcAltParamInpObject
{

  public testGnrcAltParamInpObject
    ()
  {
  }
}

public class testRefGnrcAltParamInp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltParamInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltParamInpObject<TRef>? As_RefGnrcAltParamInp { get; set; }
}

public class testRefGnrcAltParamInpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltParamInpObject<TRef>
{

  public testRefGnrcAltParamInpObject
    ()
  {
  }
}

public class testAltGnrcAltParamInp
  : GqlpModelBase
  , ItestAltGnrcAltParamInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltParamInpObject? As_AltGnrcAltParamInp { get; set; }
}

public class testAltGnrcAltParamInpObject
  : GqlpModelBase
  , ItestAltGnrcAltParamInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltParamInpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
