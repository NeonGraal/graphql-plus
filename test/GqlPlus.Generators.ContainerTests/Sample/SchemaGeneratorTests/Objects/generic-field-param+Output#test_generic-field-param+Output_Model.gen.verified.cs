//HintName: test_generic-field-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public class testGnrcFieldParamOutp
  : GqlpModelBase
  , ItestGnrcFieldParamOutp
{
  public ItestGnrcFieldParamOutpObject? As_GnrcFieldParamOutp { get; set; }
}

public class testGnrcFieldParamOutpObject
  : GqlpModelBase
  , ItestGnrcFieldParamOutpObject
{
  public ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; set; }

  public testGnrcFieldParamOutpObject
    ( ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldParamOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldParamOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldParamOutpObject<TRef>? As_RefGnrcFieldParamOutp { get; set; }
}

public class testRefGnrcFieldParamOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldParamOutpObject<TRef>
{

  public testRefGnrcFieldParamOutpObject
    ()
  {
  }
}

public class testAltGnrcFieldParamOutp
  : GqlpModelBase
  , ItestAltGnrcFieldParamOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldParamOutpObject? As_AltGnrcFieldParamOutp { get; set; }
}

public class testAltGnrcFieldParamOutpObject
  : GqlpModelBase
  , ItestAltGnrcFieldParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldParamOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
