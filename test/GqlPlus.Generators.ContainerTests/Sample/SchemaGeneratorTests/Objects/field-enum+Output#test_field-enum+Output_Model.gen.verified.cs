//HintName: test_field-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

public class testFieldEnumOutp
  : GqlpModelBase
  , ItestFieldEnumOutp
{
  public ItestFieldEnumOutpObject? As_FieldEnumOutp { get; set; }
}

public class testFieldEnumOutpObject
  : GqlpModelBase
  , ItestFieldEnumOutpObject
{
  public testEnumFieldEnumOutp Field { get; set; }

  public testFieldEnumOutpObject
    ( testEnumFieldEnumOutp field
    )
  {
    Field = field;
  }
}
