//HintName: test_field+Output_Model.gen.cs
// Generated from {CurrentDirectory}field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Output;

public class testFieldOutp
  : GqlpModelBase
  , ItestFieldOutp
{
  public ItestFieldOutpObject? As_FieldOutp { get; set; }
}

public class testFieldOutpObject
  : GqlpModelBase
  , ItestFieldOutpObject
{
  public string Field { get; set; }

  public testFieldOutpObject
    ( string pfield
    )
  {
    Field = pfield;
  }
}
