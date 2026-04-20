//HintName: test_generic-parent-enum-dom+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public class testGnrcPrntEnumDomDual
  : testFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
  , ItestGnrcPrntEnumDomDual
{
  public ItestGnrcPrntEnumDomDualObject? As_GnrcPrntEnumDomDual { get; set; }
}

public class testGnrcPrntEnumDomDualObject
  : testFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>
  , ItestGnrcPrntEnumDomDualObject
{

  public testGnrcPrntEnumDomDualObject
    ( ItestDomGnrcPrntEnumDomDual pfield
    ) : base(pfield)
  {
  }
}

public class testFieldGnrcPrntEnumDomDual<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumDomDual<TRef>
{
  public ItestFieldGnrcPrntEnumDomDualObject<TRef>? As_FieldGnrcPrntEnumDomDual { get; set; }
}

public class testFieldGnrcPrntEnumDomDualObject<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumDomDualObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumDomDualObject
    ( TRef pfield
    )
  {
    Field = pfield;
  }
}

public class testDomGnrcPrntEnumDomDual
  : GqlpDomainEnum
  , ItestDomGnrcPrntEnumDomDual
{
  public new testEnumGnrcPrntEnumDomDual? Value { get; set; }
}
