//HintName: test_field-object+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-object+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

public class testFieldObjOutp
  : GqlpModelImplementationBase
  , ItestFieldObjOutp
{
  public ItestFieldObjOutpObject? As_FieldObjOutp { get; set; }
}

public class testFieldObjOutpObject
  : GqlpModelImplementationBase
  , ItestFieldObjOutpObject
{
  public ItestFldFieldObjOutp Field { get; set; }

  public testFieldObjOutpObject
    ( ItestFldFieldObjOutp field
    )
  {
    Field = field;
  }
}

public class testFldFieldObjOutp
  : GqlpModelImplementationBase
  , ItestFldFieldObjOutp
{
  public string? AsString { get; set; }
  public ItestFldFieldObjOutpObject? As_FldFieldObjOutp { get; set; }
}

public class testFldFieldObjOutpObject
  : GqlpModelImplementationBase
  , ItestFldFieldObjOutpObject
{
  public decimal Field { get; set; }

  public testFldFieldObjOutpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
