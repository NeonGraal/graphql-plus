//HintName: test_field-value+Output_Impl.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

public class testFieldValueOutp
  : GqlpModelImplementationBase
  , ItestFieldValueOutp
{
  public ItestFieldValueOutpObject? As_FieldValueOutp { get; set; }
}

public class testFieldValueOutpObject
  : GqlpModelImplementationBase
  , ItestFieldValueOutpObject
{
  public testEnumFieldValueOutp Field { get; set; }

  public testFieldValueOutpObject(testEnumFieldValueOutp field)
  {
    Field = field;
  }
}
