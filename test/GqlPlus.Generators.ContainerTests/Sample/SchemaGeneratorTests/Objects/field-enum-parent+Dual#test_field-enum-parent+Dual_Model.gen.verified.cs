//HintName: test_field-enum-parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

public class testFieldEnumPrntDual
  : GqlpModelImplementationBase
  , ItestFieldEnumPrntDual
{
  public ItestFieldEnumPrntDualObject? As_FieldEnumPrntDual { get; set; }
}

public class testFieldEnumPrntDualObject
  : GqlpModelImplementationBase
  , ItestFieldEnumPrntDualObject
{
  public testEnumFieldEnumPrntDual Field { get; set; }

  public testFieldEnumPrntDualObject
    ( testEnumFieldEnumPrntDual field
    )
  {
    Field = field;
  }
}
