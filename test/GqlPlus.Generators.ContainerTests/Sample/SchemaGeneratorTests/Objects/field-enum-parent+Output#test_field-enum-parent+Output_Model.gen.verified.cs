//HintName: test_field-enum-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

public class testFieldEnumPrntOutp
  : GqlpModelBase
  , ItestFieldEnumPrntOutp
{
  public ItestFieldEnumPrntOutpObject? As_FieldEnumPrntOutp { get; set; }
}

public class testFieldEnumPrntOutpObject
  : GqlpModelBase
  , ItestFieldEnumPrntOutpObject
{
  public testEnumFieldEnumPrntOutp Field { get; set; }

  public testFieldEnumPrntOutpObject
    ( testEnumFieldEnumPrntOutp field
    )
  {
    Field = field;
  }
}
