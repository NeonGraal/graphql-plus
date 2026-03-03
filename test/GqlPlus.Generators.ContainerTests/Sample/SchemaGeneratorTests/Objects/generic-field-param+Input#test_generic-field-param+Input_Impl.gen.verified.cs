//HintName: test_generic-field-param+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public class testGnrcFieldParamInp
  : GqlpModelImplementationBase
  , ItestGnrcFieldParamInp
{
  public ItestGnrcFieldParamInpObject? As_GnrcFieldParamInp { get; set; }
}

public class testGnrcFieldParamInpObject
  : GqlpModelImplementationBase
  , ItestGnrcFieldParamInpObject
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }

  public testGnrcFieldParamInpObject
    ( ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldParamInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcFieldParamInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldParamInpObject<TRef>? As_RefGnrcFieldParamInp { get; set; }
}

public class testRefGnrcFieldParamInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcFieldParamInpObject<TRef>
{

  public testRefGnrcFieldParamInpObject
    ()
  {
  }
}

public class testAltGnrcFieldParamInp
  : GqlpModelImplementationBase
  , ItestAltGnrcFieldParamInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldParamInpObject? As_AltGnrcFieldParamInp { get; set; }
}

public class testAltGnrcFieldParamInpObject
  : GqlpModelImplementationBase
  , ItestAltGnrcFieldParamInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldParamInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
