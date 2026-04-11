//HintName: test_Output_Intf.gen.cs
// Generated from {CurrentDirectory}Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Output;

public interface Itest_OutputField
  : Itest_ObjField<Itest_ObjFieldType>
{
  Itest_OutputFieldObject? As__OutputField { get; }
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject<Itest_ObjFieldType>
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  Itest_OutputFieldTypeObject? As__OutputFieldType { get; }
}

public interface Itest_OutputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  Itest_InputFieldType? Parameter { get; }
}
