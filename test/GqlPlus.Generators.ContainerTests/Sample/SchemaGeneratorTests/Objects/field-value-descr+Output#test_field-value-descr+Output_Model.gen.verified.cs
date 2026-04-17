//HintName: test_field-value-descr+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Output;

public class testFieldValueDescrOutp
  : GqlpModelBase
  , ItestFieldValueDescrOutp
{
  public ItestFieldValueDescrOutpObject? As_FieldValueDescrOutp { get; set; }
}

public class testFieldValueDescrOutpObject
  : GqlpModelBase
  , ItestFieldValueDescrOutpObject
{
  public testEnumFieldValueDescrOutp Field { get; set; }

  public testFieldValueDescrOutpObject
    ( testEnumFieldValueDescrOutp field
    )
  {
    Field = field;
  }
}
