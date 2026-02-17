//HintName: test_generic-field-dual+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public class testGnrcFieldDualDual
  : GqlpModelImplementationBase
  , ItestGnrcFieldDualDual
{
  public ItestGnrcFieldDualDualObject? As_GnrcFieldDualDual { get; set; }
}

public class testGnrcFieldDualDualObject
  : GqlpModelImplementationBase
  , ItestGnrcFieldDualDualObject
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }

  public testGnrcFieldDualDualObject(ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> field)
  {
    Field = field;
  }
}

public class testRefGnrcFieldDualDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcFieldDualDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldDualDualObject<TRef>? As_RefGnrcFieldDualDual { get; set; }
}

public class testRefGnrcFieldDualDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcFieldDualDualObject<TRef>
{

  public testRefGnrcFieldDualDualObject()
  {
  }
}

public class testAltGnrcFieldDualDual
  : GqlpModelImplementationBase
  , ItestAltGnrcFieldDualDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldDualDualObject? As_AltGnrcFieldDualDual { get; set; }
}

public class testAltGnrcFieldDualDualObject
  : GqlpModelImplementationBase
  , ItestAltGnrcFieldDualDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldDualDualObject(decimal alt)
  {
    Alt = alt;
  }
}
