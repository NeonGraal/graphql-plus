//HintName: test_generic-parent-simple-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public class testGnrcPrntSmplEnumDual
  : testFieldGnrcPrntSmplEnumDual<testEnumGnrcPrntSmplEnumDual>
  , ItestGnrcPrntSmplEnumDual
{
  public ItestGnrcPrntSmplEnumDualObject? As_GnrcPrntSmplEnumDual { get; set; }
}

public class testGnrcPrntSmplEnumDualObject
  : testFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>
  , ItestGnrcPrntSmplEnumDualObject
{

  public testGnrcPrntSmplEnumDualObject
    ( testEnumGnrcPrntSmplEnumDual field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntSmplEnumDual<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntSmplEnumDual<TRef>
{
  public ItestFieldGnrcPrntSmplEnumDualObject<TRef>? As_FieldGnrcPrntSmplEnumDual { get; set; }
}

public class testFieldGnrcPrntSmplEnumDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntSmplEnumDualObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntSmplEnumDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}
