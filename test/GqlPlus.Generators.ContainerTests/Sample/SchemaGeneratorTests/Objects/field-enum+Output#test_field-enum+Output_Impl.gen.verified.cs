//HintName: test_field-enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

public class testFieldEnumOutp
  : GqlpModelImplementationBase
  , ItestFieldEnumOutp
{
  public ItestFieldEnumOutpObject? As_FieldEnumOutp { get; set; }
}

public class testFieldEnumOutpObject
  : GqlpModelImplementationBase
  , ItestFieldEnumOutpObject
{
  public testEnumFieldEnumOutp Field { get; set; }

  public testFieldEnumOutpObject(testEnumFieldEnumOutp field)
  {
    Field = field;
  }
}
