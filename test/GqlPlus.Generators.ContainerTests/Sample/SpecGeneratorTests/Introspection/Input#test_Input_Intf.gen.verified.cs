//HintName: test_Input_Intf.gen.cs
// Generated from Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Input;

public interface Itest_InputField
  : Itest_ObjField
{
  Itest_InputFieldObject As_InputField { get; }
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  Itest_InputFieldTypeObject As_InputFieldType { get; }
}

public interface Itest_InputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  Itest_Value? Default { get; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
  Itest_InputParamObject As_InputParam { get; }
}

public interface Itest_InputParamObject
  : Itest_InputFieldTypeObject
{
}
