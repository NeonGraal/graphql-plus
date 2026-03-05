//HintName: test_field+Output_Model.gen.cs
// Generated from {CurrentDirectory}field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Output;

public class testFieldOutp
  : GqlpModelImplementationBase
  , ItestFieldOutp
{
  public ItestFieldOutpObject? As_FieldOutp { get; set; }
}

public class testFieldOutpObject
  : GqlpModelImplementationBase
  , ItestFieldOutpObject
{
  public string Field { get; set; }

  public testFieldOutpObject
    ( string field
    )
  {
    Field = field;
  }
}
