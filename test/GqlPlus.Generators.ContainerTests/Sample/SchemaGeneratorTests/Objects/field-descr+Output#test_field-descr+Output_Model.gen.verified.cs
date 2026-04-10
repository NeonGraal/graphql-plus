//HintName: test_field-descr+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Output;

public class testFieldDescrOutp
  : GqlpModelBase
  , ItestFieldDescrOutp
{
  public ItestFieldDescrOutpObject? As_FieldDescrOutp { get; set; }
}

public class testFieldDescrOutpObject
  : GqlpModelBase
  , ItestFieldDescrOutpObject
{
  public string Field { get; set; }

  public testFieldDescrOutpObject
    ( string field
    )
  {
    Field = field;
  }
}
