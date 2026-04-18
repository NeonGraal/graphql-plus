//HintName: test_generic-parent-enum-child+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public class testGnrcPrntEnumChildDual
  : testFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
  , ItestGnrcPrntEnumChildDual
{
  public ItestGnrcPrntEnumChildDualObject? As_GnrcPrntEnumChildDual { get; set; }
}

public class testGnrcPrntEnumChildDualObject
  : testFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>
  , ItestGnrcPrntEnumChildDualObject
{

  public testGnrcPrntEnumChildDualObject
    ( testParentGnrcPrntEnumChildDual field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumChildDual<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumChildDual<TRef>
{
  public ItestFieldGnrcPrntEnumChildDualObject<TRef>? As_FieldGnrcPrntEnumChildDual { get; set; }
}

public class testFieldGnrcPrntEnumChildDualObject<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumChildDualObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumChildDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}
