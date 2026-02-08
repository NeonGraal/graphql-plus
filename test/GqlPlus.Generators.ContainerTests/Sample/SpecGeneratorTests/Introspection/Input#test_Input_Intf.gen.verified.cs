//HintName: test_Input_Intf.gen.cs
// Generated from Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Input;

public interface Itest_InputField
  : Itest_ObjField
{
  public Itest_InputFieldObject As_InputField { get; set; }
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  public Itest_InputFieldTypeObject As_InputFieldType { get; set; }
}

public interface Itest_InputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  public Itest_Value? Default { get; set; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
  public Itest_InputParamObject As_InputParam { get; set; }
}

public interface Itest_InputParamObject
  : Itest_InputFieldTypeObject
{
}
