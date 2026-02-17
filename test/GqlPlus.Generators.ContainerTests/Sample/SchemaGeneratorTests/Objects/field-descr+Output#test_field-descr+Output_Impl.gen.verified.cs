//HintName: test_field-descr+Output_Impl.gen.cs
// Generated from {CurrentDirectory}field-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Output;

public class testFieldDescrOutp
  : GqlpModelImplementationBase
  , ItestFieldDescrOutp
{
  public ItestFieldDescrOutpObject? As_FieldDescrOutp { get; set; }
}

public class testFieldDescrOutpObject
  : GqlpModelImplementationBase
  , ItestFieldDescrOutpObject
{
  public string Field { get; set; }

  public testFieldDescrOutpObject(string field)
  {
    Field = field;
  }
}
