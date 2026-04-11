//HintName: test_generic-field-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public class testGnrcFieldDualDual
  : GqlpModelBase
  , ItestGnrcFieldDualDual
{
  public ItestGnrcFieldDualDualObject? As_GnrcFieldDualDual { get; set; }
}

public class testGnrcFieldDualDualObject
  : GqlpModelBase
  , ItestGnrcFieldDualDualObject
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }

  public testGnrcFieldDualDualObject
    ( ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldDualDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldDualDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldDualDualObject<TRef>? As_RefGnrcFieldDualDual { get; set; }
}

public class testRefGnrcFieldDualDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldDualDualObject<TRef>
{

  public testRefGnrcFieldDualDualObject
    ()
  {
  }
}

public class testAltGnrcFieldDualDual
  : GqlpModelBase
  , ItestAltGnrcFieldDualDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldDualDualObject? As_AltGnrcFieldDualDual { get; set; }
}

public class testAltGnrcFieldDualDualObject
  : GqlpModelBase
  , ItestAltGnrcFieldDualDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldDualDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
