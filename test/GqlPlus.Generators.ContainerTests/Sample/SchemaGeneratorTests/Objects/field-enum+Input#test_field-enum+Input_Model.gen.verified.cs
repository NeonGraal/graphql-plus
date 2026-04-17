//HintName: test_field-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

public class testFieldEnumInp
  : GqlpModelBase
  , ItestFieldEnumInp
{
  public ItestFieldEnumInpObject? As_FieldEnumInp { get; set; }
}

public class testFieldEnumInpObject
  : GqlpModelBase
  , ItestFieldEnumInpObject
{
  public testEnumFieldEnumInp Field { get; set; }

  public testFieldEnumInpObject
    ( testEnumFieldEnumInp field
    )
  {
    Field = field;
  }
}
