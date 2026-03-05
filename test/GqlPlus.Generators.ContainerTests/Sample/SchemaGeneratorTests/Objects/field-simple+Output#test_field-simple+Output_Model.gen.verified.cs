//HintName: test_field-simple+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Output;

public class testFieldSmplOutp
  : GqlpModelImplementationBase
  , ItestFieldSmplOutp
{
  public ItestFieldSmplOutpObject? As_FieldSmplOutp { get; set; }
}

public class testFieldSmplOutpObject
  : GqlpModelImplementationBase
  , ItestFieldSmplOutpObject
{
  public decimal Field { get; set; }

  public testFieldSmplOutpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
