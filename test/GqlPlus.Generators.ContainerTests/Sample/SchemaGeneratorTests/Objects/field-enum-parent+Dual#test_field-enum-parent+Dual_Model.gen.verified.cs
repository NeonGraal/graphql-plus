//HintName: test_field-enum-parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

public class testFieldEnumPrntDual
  : GqlpModelBase
  , ItestFieldEnumPrntDual
{
  public ItestFieldEnumPrntDualObject? As_FieldEnumPrntDual { get; set; }
}

public class testFieldEnumPrntDualObject
  : GqlpModelBase
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
