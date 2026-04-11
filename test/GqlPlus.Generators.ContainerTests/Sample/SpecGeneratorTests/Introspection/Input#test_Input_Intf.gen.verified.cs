//HintName: test_Input_Intf.gen.cs
// Generated from {CurrentDirectory}Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Input;

public interface Itest_InputField
  : Itest_ObjField<Itest_InputFieldType>
{
  Itest_InputFieldObject? As__InputField { get; }
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject<Itest_InputFieldType>
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  Itest_InputFieldTypeObject? As__InputFieldType { get; }
}

public interface Itest_InputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  GqlpValue? DefaultValue { get; }
}
