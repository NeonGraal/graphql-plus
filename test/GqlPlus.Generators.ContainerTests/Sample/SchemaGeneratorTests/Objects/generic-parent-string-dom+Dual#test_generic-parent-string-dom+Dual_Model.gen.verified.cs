//HintName: test_generic-parent-string-dom+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public class testGnrcPrntStrDomDual
  : testFieldGnrcPrntStrDomDual<ItestDomGnrcPrntStrDomDual>
  , ItestGnrcPrntStrDomDual
{
  public ItestGnrcPrntStrDomDualObject? As_GnrcPrntStrDomDual { get; set; }
}

public class testGnrcPrntStrDomDualObject
  : testFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>
  , ItestGnrcPrntStrDomDualObject
{

  public testGnrcPrntStrDomDualObject
    ( ItestDomGnrcPrntStrDomDual field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntStrDomDual<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntStrDomDual<TRef>
{
  public ItestFieldGnrcPrntStrDomDualObject<TRef>? As_FieldGnrcPrntStrDomDual { get; set; }
}

public class testFieldGnrcPrntStrDomDualObject<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntStrDomDualObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntStrDomDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testDomGnrcPrntStrDomDual
  : GqlpDomainString
  , ItestDomGnrcPrntStrDomDual
{
}
