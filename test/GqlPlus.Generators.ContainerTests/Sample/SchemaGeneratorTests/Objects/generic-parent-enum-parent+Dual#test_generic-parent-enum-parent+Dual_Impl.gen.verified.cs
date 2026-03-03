//HintName: test_generic-parent-enum-parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public class testGnrcPrntEnumPrntDual
  : testFieldGnrcPrntEnumPrntDual<testEnumGnrcPrntEnumPrntDual>
  , ItestGnrcPrntEnumPrntDual
{
  public ItestGnrcPrntEnumPrntDualObject? As_GnrcPrntEnumPrntDual { get; set; }
}

public class testGnrcPrntEnumPrntDualObject
  : testFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>
  , ItestGnrcPrntEnumPrntDualObject
{

  public testGnrcPrntEnumPrntDualObject
    ( testEnumGnrcPrntEnumPrntDual field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumPrntDual<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntEnumPrntDual<TRef>
{
  public ItestFieldGnrcPrntEnumPrntDualObject<TRef>? As_FieldGnrcPrntEnumPrntDual { get; set; }
}

public class testFieldGnrcPrntEnumPrntDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntEnumPrntDualObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumPrntDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}
