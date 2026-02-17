//HintName: test_field-object+Input_Impl.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

public class testFieldObjInp
  : GqlpModelImplementationBase
  , ItestFieldObjInp
{
  public ItestFieldObjInpObject? As_FieldObjInp { get; set; }
}

public class testFieldObjInpObject
  : GqlpModelImplementationBase
  , ItestFieldObjInpObject
{
  public ItestFldFieldObjInp Field { get; set; }

  public testFieldObjInpObject(ItestFldFieldObjInp field)
  {
    Field = field;
  }
}

public class testFldFieldObjInp
  : GqlpModelImplementationBase
  , ItestFldFieldObjInp
{
  public string? AsString { get; set; }
  public ItestFldFieldObjInpObject? As_FldFieldObjInp { get; set; }
}

public class testFldFieldObjInpObject
  : GqlpModelImplementationBase
  , ItestFldFieldObjInpObject
{
  public decimal Field { get; set; }

  public testFldFieldObjInpObject(decimal field)
  {
    Field = field;
  }
}
