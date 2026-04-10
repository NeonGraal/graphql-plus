//HintName: test_Dual_Model.gen.cs
// Generated from {CurrentDirectory}Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Dual;

public class test_DualField
  : test_ObjField<Itest_ObjFieldType>
  , Itest_DualField
{
  public Itest_DualFieldObject? As__DualField { get; set; }
}

public class test_DualFieldObject
  : test_ObjFieldObject<Itest_ObjFieldType>
  , Itest_DualFieldObject
{

  public test_DualFieldObject
    ()
  {
  }
}
