//HintName: test_field-value+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

public class testFieldValueOutp
  : GqlpModelBase
  , ItestFieldValueOutp
{
  public ItestFieldValueOutpObject? As_FieldValueOutp { get; set; }
}

public class testFieldValueOutpObject
  : GqlpModelBase
  , ItestFieldValueOutpObject
{
  public testEnumFieldValueOutp Field { get; set; }

  public testFieldValueOutpObject
    ( testEnumFieldValueOutp field
    )
  {
    Field = field;
  }
}
