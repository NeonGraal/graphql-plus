//HintName: test_generic-alt-param+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public class testGnrcAltParamInp
  : GqlpModelImplementationBase
  , ItestGnrcAltParamInp
{
  public ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp>? AsRefGnrcAltParamInp { get; set; }
  public ItestGnrcAltParamInpObject? As_GnrcAltParamInp { get; set; }
}

public class testGnrcAltParamInpObject
  : GqlpModelImplementationBase
  , ItestGnrcAltParamInpObject
{

  public testGnrcAltParamInpObject
    ()
  {
  }
}

public class testRefGnrcAltParamInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltParamInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltParamInpObject<TRef>? As_RefGnrcAltParamInp { get; set; }
}

public class testRefGnrcAltParamInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltParamInpObject<TRef>
{

  public testRefGnrcAltParamInpObject
    ()
  {
  }
}

public class testAltGnrcAltParamInp
  : GqlpModelImplementationBase
  , ItestAltGnrcAltParamInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltParamInpObject? As_AltGnrcAltParamInp { get; set; }
}

public class testAltGnrcAltParamInpObject
  : GqlpModelImplementationBase
  , ItestAltGnrcAltParamInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltParamInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
