//HintName: test_field-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

public class testFieldEnumDual
  : GqlpModelImplementationBase
  , ItestFieldEnumDual
{
  public ItestFieldEnumDualObject? As_FieldEnumDual { get; set; }
}

public class testFieldEnumDualObject
  : GqlpModelImplementationBase
  , ItestFieldEnumDualObject
{
  public testEnumFieldEnumDual Field { get; set; }

  public testFieldEnumDualObject
    ( testEnumFieldEnumDual field
    )
  {
    Field = field;
  }
}
