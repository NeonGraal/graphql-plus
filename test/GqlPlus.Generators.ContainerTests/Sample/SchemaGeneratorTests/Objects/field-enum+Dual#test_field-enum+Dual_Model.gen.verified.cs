//HintName: test_field-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

public class testFieldEnumDual
  : GqlpModelBase
  , ItestFieldEnumDual
{
  public ItestFieldEnumDualObject? As_FieldEnumDual { get; set; }
}

public class testFieldEnumDualObject
  : GqlpModelBase
  , ItestFieldEnumDualObject
{
  public testEnumFieldEnumDual Field { get; set; }

  public testFieldEnumDualObject
    ( testEnumFieldEnumDual pfield
    )
  {
    Field = pfield;
  }
}
