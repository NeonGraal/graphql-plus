//HintName: test_field-type-descr+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Output;

public class testFieldTypeDescrOutp
  : GqlpModelBase
  , ItestFieldTypeDescrOutp
{
  public ItestFieldTypeDescrOutpObject? As_FieldTypeDescrOutp { get; set; }
}

public class testFieldTypeDescrOutpObject
  : GqlpModelBase
  , ItestFieldTypeDescrOutpObject
{
  public decimal Field { get; set; }

  public testFieldTypeDescrOutpObject
    ( decimal pfield
    )
  {
    Field = pfield;
  }
}
