//HintName: test_generic-field-dual+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public class testGnrcFieldDualInp
  : GqlpModelBase
  , ItestGnrcFieldDualInp
{
  public ItestGnrcFieldDualInpObject? As_GnrcFieldDualInp { get; set; }
}

public class testGnrcFieldDualInpObject
  : GqlpModelBase
  , ItestGnrcFieldDualInpObject
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; set; }

  public testGnrcFieldDualInpObject
    ( ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldDualInp<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldDualInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldDualInpObject<TRef>? As_RefGnrcFieldDualInp { get; set; }
}

public class testRefGnrcFieldDualInpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldDualInpObject<TRef>
{

  public testRefGnrcFieldDualInpObject
    ()
  {
  }
}

public class testAltGnrcFieldDualInp
  : GqlpModelBase
  , ItestAltGnrcFieldDualInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldDualInpObject? As_AltGnrcFieldDualInp { get; set; }
}

public class testAltGnrcFieldDualInpObject
  : GqlpModelBase
  , ItestAltGnrcFieldDualInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldDualInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
