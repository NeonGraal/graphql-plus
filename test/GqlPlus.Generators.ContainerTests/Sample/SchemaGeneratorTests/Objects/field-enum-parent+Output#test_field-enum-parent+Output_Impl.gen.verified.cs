//HintName: test_field-enum-parent+Output_Impl.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

public class testFieldEnumPrntOutp
  : GqlpModelImplementationBase
  , ItestFieldEnumPrntOutp
{
  public ItestFieldEnumPrntOutpObject? As_FieldEnumPrntOutp { get; set; }
}

public class testFieldEnumPrntOutpObject
  : GqlpModelImplementationBase
  , ItestFieldEnumPrntOutpObject
{
  public testEnumFieldEnumPrntOutp Field { get; set; }

  public testFieldEnumPrntOutpObject(testEnumFieldEnumPrntOutp field)
  {
    Field = field;
  }
}
